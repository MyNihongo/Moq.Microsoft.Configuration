using System.Dynamic;

namespace Moq.Microsoft.Configuration;

internal static class ConfigurationSetupEx
{
	private static readonly SectionInfoProvider SectionInfoProvider = new();

	public static void SetupConfigurationTree<T>(this ConfigurationSetup<T> @this, object configuration)
		where T : class, IConfiguration
	{
		var type = configuration.GetType();

		if (IsPrimitive(type) || configuration is IEnumerable and not ExpandoObject)
			throw new InvalidOperationException($"`{type.FullName}` must not be a primitive type or enumerable");

		@this.MockConfiguration.SetupDefaultSection();

		var props = SectionInfoProvider.Resolve(type, configuration);

		if (props.Count == 0)
			return;

		var children = new IConfigurationSection[props.Count];
		for (var i = 0; i < props.Count; i++)
		{
			foreach (var nestedValueConfig in SetupSection(props[i], string.Empty))
			{
				@this.MockConfiguration.SetupSection(nestedValueConfig.Value, nestedValueConfig.Key);

				if (nestedValueConfig.Value.Path == props[i].Name)
					children[i] = nestedValueConfig.Value;
			}
		}

		@this.MockConfiguration.SetupChildren(children);
	}

	private static IReadOnlyDictionary<string, IConfigurationSection> SetupSection(SectionInfo sectionInfo, string basePath)
	{
		var mockSection = new Mock<IConfigurationSection>();
		mockSection.SetupDefaultSection();
		mockSection.SetupKeyAndPath(sectionInfo.Name, basePath);

		var valueConfigs = new Dictionary<string, IConfigurationSection>
		{
			{sectionInfo.Name, mockSection.Object}
		};

		if (IsPrimitive(sectionInfo.SectionType))
		{
			mockSection.SetupValue(sectionInfo.Value, sectionInfo.Name);
		}
		else if (typeof(IDictionary).IsAssignableFrom(sectionInfo.SectionType))
		{
			var children = new List<IConfigurationSection>();
			foreach (DictionaryEntry keyValue in (IDictionary)sectionInfo.Value)
			{
				var itemName = keyValue.Key.ToString();
				var item = keyValue.Value;

				SetupCollectionItem(item, itemName, children);
			}

			mockSection.SetupChildren(children);
		}
		else if (typeof(IEnumerable).IsAssignableFrom(sectionInfo.SectionType))
		{
			var children = new List<IConfigurationSection>();

			var i = 0;
			foreach (var item in (IEnumerable)sectionInfo.Value)
			{
				var itemName = i.ToString();

				if (item == null)
				{
					var emptySection = mockSection.SetupEmptySection(itemName);
					children.Add(emptySection);
				}
				else
				{
					SetupCollectionItem(item, itemName, children);
				}

				i++;
			}

			mockSection.SetupChildren(children);
		}
		else
		{
			var nestedProps = SectionInfoProvider.Resolve(sectionInfo.SectionType, sectionInfo.Value);

			if (nestedProps.Count == 0)
				return valueConfigs;

			var children = new IConfigurationSection[nestedProps.Count];
			for (var i = 0; i < nestedProps.Count; i++)
			{
				var nestedBasePath = PathUtils.Append(basePath, sectionInfo.Name);

				foreach (var nestedValueConfig in SetupSection(nestedProps[i], nestedBasePath))
				{
					mockSection.SetupSection(nestedValueConfig.Value, nestedValueConfig.Key);

					var pathToNestedValue = PathUtils.Append(sectionInfo.Name, nestedValueConfig.Key);
					valueConfigs.Add(pathToNestedValue, nestedValueConfig.Value);

					if (nestedValueConfig.IsChild(nestedBasePath))
						children[i] = nestedValueConfig.Value;
				}
			}

			mockSection.SetupChildren(children);
		}

		return valueConfigs;

		void SetupCollectionItem(object item, string itemName, ICollection<IConfigurationSection> children)
		{
			var nestedBasePath = PathUtils.Append(basePath, sectionInfo.Name);
			var nestedSectionInfo = new SectionInfo(itemName, item, item.GetType());

			foreach (var nestedValueConfig in SetupSection(nestedSectionInfo, nestedBasePath))
			{
				mockSection.SetupSection(nestedValueConfig.Value, nestedValueConfig.Key);

				var pathToNestedValue = PathUtils.Append(sectionInfo.Name, nestedValueConfig.Key);
				valueConfigs.Add(pathToNestedValue, nestedValueConfig.Value);

				if (nestedValueConfig.IsChild(nestedBasePath))
					children.Add(nestedValueConfig.Value);
			}
		}
	}

	private static bool IsPrimitive(Type type)
	{
		static bool IsPrimitiveType(Type type) =>
			type.IsPrimitive
			|| type.IsEnum
			|| type == typeof(string)
			|| type == typeof(decimal);

		if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
			return IsPrimitiveType(type.GetGenericArguments()[0]);

		return IsPrimitiveType(type);
	}
		
	private static bool IsChild(this KeyValuePair<string, IConfigurationSection> nestedValueConfig, string nestedBasePath) =>
		nestedValueConfig.Value.Path == PathUtils.Append(nestedBasePath, nestedValueConfig.Value.Key);
}
using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace Moq.Microsoft.Configuration
{
	internal static class ConfigurationSetupExtensions
	{
		public static void SetupConfigurationTree(this ConfigurationSetup @this, object configuration)
		{
			var type = configuration.GetType();

			if (IsPrimitive(type) || typeof(IEnumerable).IsAssignableFrom(type))
				throw new InvalidOperationException($"A {type.FullName} cannot be set as the root because it does not have a root property");

			var props = type.GetProperties();

			if (props.Length == 0)
				throw new InvalidOperationException("The root element has no properties");

			var children = new IConfigurationSection[props.Length];
			for (var i = 0; i < props.Length; i++)
			{
				foreach (var nestedValueConfig in SetupSection(props[i].ToSectionInfo(configuration), string.Empty))
				{
					@this.MockConfiguration.SetupSection(nestedValueConfig.Value, nestedValueConfig.Key);

					if (nestedValueConfig.Value.Path == props[i].Name)
						children[i] = nestedValueConfig.Value;
				}
			}

			@this.MockConfiguration.SetupChildren(children);
		}

		// TODO: cache types in a dictionary
		private static IReadOnlyDictionary<string, IConfigurationSection> SetupSection(SectionInfo sectionInfo, string basePath)
		{
			var mockSection = new Mock<IConfigurationSection>();
			mockSection.SetupKeyAndPath(sectionInfo.Name, basePath);

			var valueConfigs = new Dictionary<string, IConfigurationSection>
			{
				{sectionInfo.Name, mockSection.Object}
			};

			if (IsPrimitive(sectionInfo.SectionType))
			{
				mockSection.SetupValue(sectionInfo.Value, sectionInfo.Name);
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
						
						goto Continue;
					}
					
					var nestedBasePath = PathUtils.Append(basePath, sectionInfo.Name);
					var nestedSectionInfo = new SectionInfo(itemName, item, item.GetType());

					// TODO: looks like copy-paste?
					foreach (var nestedValueConfig in SetupSection(nestedSectionInfo, nestedBasePath))
					{
						mockSection.SetupSection(nestedValueConfig.Value, nestedValueConfig.Key);

						var pathToNestedValue = PathUtils.Append(sectionInfo.Name, nestedValueConfig.Key);
						valueConfigs.Add(pathToNestedValue, nestedValueConfig.Value);

						if (nestedValueConfig.Value.Path == PathUtils.Append(nestedBasePath, nestedValueConfig.Value.Key))
							children.Add(nestedValueConfig.Value);
					}

					Continue:
					i++;
				}

				mockSection.SetupChildren(children);
			}
			else
			{
				var nestedProps = sectionInfo.SectionType
					.GetProperties();

				if (nestedProps.Length == 0)
					return valueConfigs;

				var children = new IConfigurationSection[nestedProps.Length];
				for (var i = 0; i < nestedProps.Length; i++)
				{
					var nestedBasePath = PathUtils.Append(basePath, sectionInfo.Name);

					foreach (var nestedValueConfig in SetupSection(nestedProps[i].ToSectionInfo(sectionInfo.Value), nestedBasePath))
					{
						mockSection.SetupSection(nestedValueConfig.Value, nestedValueConfig.Key);

						var pathToNestedValue = PathUtils.Append(sectionInfo.Name, nestedValueConfig.Key);
						valueConfigs.Add(pathToNestedValue, nestedValueConfig.Value);

						if (nestedValueConfig.Value.Path == PathUtils.Append(nestedBasePath, nestedValueConfig.Value.Key))
							children[i] = nestedValueConfig.Value;
					}
				}

				mockSection.SetupChildren(children);
			}

			return valueConfigs;
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
	}
}

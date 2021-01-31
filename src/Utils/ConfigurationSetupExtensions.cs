using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
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
				foreach (var nestedValueConfig in SetupSection(props[i], configuration, string.Empty))
				{
					// TODO: combine
					@this.MockConfiguration.SetupPathAccess(nestedValueConfig.Key, nestedValueConfig.Value.Value);
					@this.MockConfiguration.SetupSection(nestedValueConfig.Value, nestedValueConfig.Value.Path);

					if (nestedValueConfig.Value.Path == props[i].Name)
						children[i] = nestedValueConfig.Value;
				}
			}

			@this.MockConfiguration.SetupChildren(children);
		}

		// TODO: cache types in a dictionary
		private static IReadOnlyDictionary<string, IConfigurationSection> SetupSection(PropertyInfo prop, object configObject, string basePath)
		{
			var mockSection = new Mock<IConfigurationSection>();
			mockSection.SetupKeyAndPath(prop.Name, basePath);

			var valueConfigs = new Dictionary<string, IConfigurationSection>
			{
				{prop.Name, mockSection.Object}
			};

			var value = prop.GetValue(configObject)!;

			if (IsPrimitive(prop.PropertyType))
			{
				mockSection.SetupValue(value, prop.Name, basePath);
			}
			else if (typeof(IEnumerable).IsAssignableFrom(prop.PropertyType))
			{
				throw new NotImplementedException();
			}
			else
			{
				var nestedProps = prop.PropertyType
					.GetProperties();

				if (nestedProps.Length == 0)
					return valueConfigs;

				var children = new IConfigurationSection[nestedProps.Length];
				for (var i = 0; i < nestedProps.Length; i++)
				{
					var nestedBasePath = PathUtils.Append(basePath, prop.Name);

					foreach (var nestedValueConfig in SetupSection(nestedProps[i], value, nestedBasePath))
					{
						mockSection.SetupPathAccess(nestedValueConfig.Key, nestedValueConfig.Value.Value);
						mockSection.SetupSection(nestedValueConfig.Value, nestedValueConfig.Key);

						var pathToNestedValue = PathUtils.Append(prop.Name, nestedValueConfig.Key);
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

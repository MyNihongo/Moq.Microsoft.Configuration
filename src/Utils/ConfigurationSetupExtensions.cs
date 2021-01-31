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

			foreach (var prop in props)
				foreach (var nestedValueConfig in SetupSection(prop, configuration, string.Empty))
					@this.MockConfiguration.SetupPathAccess(nestedValueConfig.Key, nestedValueConfig.Value.Value);
		}

		// TODO: cache types in a dictionary
		private static IReadOnlyDictionary<string, IConfigurationSection> SetupSection(PropertyInfo prop, object configObject, string basePath)
		{
			var mockSection = new Mock<IConfigurationSection>();
			var valueConfigs = new Dictionary<string, IConfigurationSection>();
			var value = prop.GetValue(configObject)!;

			if (IsPrimitive(prop.PropertyType))
			{
				var valueConfig = mockSection.SetupValue(value, prop.Name, basePath);
				valueConfigs.Add(prop.Name, valueConfig);
			}
			else if (typeof(IEnumerable).IsAssignableFrom(prop.PropertyType))
			{
				throw new NotImplementedException();
			}
			else
			{
				var nestedProps = prop.PropertyType
					.GetProperties();

				foreach (var nestedProp in nestedProps)
					foreach (var nestedValueConfig in SetupSection(nestedProp, value, prop.Name))
					{
						var pathToNestedValue = PathUtils.Append(prop.Name, nestedValueConfig.Key);
						mockSection.SetupPathAccess(pathToNestedValue, nestedValueConfig.Value.Value);

						valueConfigs.Add(pathToNestedValue, nestedValueConfig.Value);
					}
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

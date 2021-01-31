using System;
using System.Collections;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace Moq.Microsoft.Configuration
{
	internal static class ConfigurationSetupExtensions
	{
		public static void SetupConfigurationTree(this ConfigurationSetup @this, object configuration)
		{
			var props = configuration
				.GetType()
				.GetProperties();

			if (props.Length == 0)
				throw new InvalidOperationException("The root element has no properties");
			
			foreach (var prop in props)
			{
				var a = SetupSection(prop, configuration, string.Empty);
			}
		}

		// TODO: cache types in a dictionary
		private static string SetupSection(PropertyInfo prop, object configObject, string basePath)
		{
			var mockSection = new Mock<IConfigurationSection>();
			var value = prop.GetValue(configObject)!;

			if (IsPrimitive(prop.PropertyType))
			{
				var valueConfig = mockSection.SetupValue(value, prop.Name, basePath);
				var a = "aa";
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
					SetupSection(nestedProp, value, prop.Name);
			}	
			
			return "aa";
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

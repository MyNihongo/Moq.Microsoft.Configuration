using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace Moq.Microsoft.Configuration
{
	internal sealed class SectionSetup : SetupBase, ISetup<ConfigurationNode>
	{
		public SectionSetup(Mock<IConfiguration> mock, string path)
			: base(mock, path)
		{
		}

		public void Returns(ConfigurationNode param)
		{
			var rootNode = string.IsNullOrEmpty(Path)
				? param
				: new ConfigurationNode(Path)
				{
					Children =
					{
						param
					}
				};

			this.SetupConfigurationTree(rootNode);

			//var props = GetProperties(param.GetType());

			//if (props.Count == 0)
			//{
			//	if (MockConfigurationSection == null)
			//		throw new InvalidOperationException("Cannot setup a primitive value as the root element");

			//	MockConfiguration.SetValue(MockConfigurationSection, param);
			//	return;
			//}

			//var children = new IConfigurationSection[props.Count];

			//if (MockConfigurationSection == null)
			//{
			//	MockConfiguration
			//		.Setup(x => x.GetChildren())
			//		.Returns(children);
			//}
			//else
			//{
			//	MockConfigurationSection
			//		.Setup(x => x.GetChildren())
			//		.Returns(children);
			//}

			//for (var i = 0; i < props.Count; i++)
			//{
			//	var prop = props[i];
			//	var value = prop.GetValue(param);

			//	var mockSection = new Mock<IConfigurationSection>();
			//	children[i] = mockSection.Object;

			//	mockSection
			//		.SetupGet(x => x.Path)
			//		.Returns(prop.Name);

			//	if (IsPrimitive(prop.PropertyType))
			//	{
			//		if (MockConfigurationSection == null)
			//		{
			//			MockConfiguration.SetValue(mockSection, value);
			//		}
			//		else
			//		{
			//			MockConfigurationSection
			//				.SetValue(mockSection, value)
			//				.BindTo(MockConfiguration);
			//		}
			//	}
			//	else if (typeof(IEnumerable).IsAssignableFrom(prop.PropertyType))
			//	{
			//		if (MockConfigurationSection == null)
			//		{
			//			MockConfiguration.SetChildren(mockSection, (IEnumerable) value);
			//		}
			//		else
			//		{
			//			MockConfigurationSection
			//				.SetChildren(mockSection, (IEnumerable)value)
			//				.BindTo(MockConfiguration);
			//		}
			//	}
			//	else
			//	{
			//		continue;
			//	}

			//	if (MockConfigurationSection == null)
			//	{
			//		MockConfiguration
			//			.Setup(x => x.GetSection(prop.Name))
			//			.Returns(mockSection.Object);
			//	}
			//	else
			//	{
			//		MockConfigurationSection
			//			.Setup(x => x.GetSection(prop.Name))
			//			.Returns(mockSection.Object);
			//	}
			//}
		}

		private static IReadOnlyList<PropertyInfo> GetProperties(Type type) =>
			type == typeof(string)
				? Array.Empty<PropertyInfo>()
				: type.GetProperties();

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

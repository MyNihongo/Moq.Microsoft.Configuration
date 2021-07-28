using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace Moq.Microsoft.Configuration
{
	internal static class MockConfigurationSectionEx
	{
		public static void SetupValue(this Mock<IConfigurationSection> @this, object value, string key)
		{
			var stringValue = value.SerialiseValue()!;

			@this
				.SetupGet(x => x.Value)
				.Returns(stringValue);

			@this.SetupPathAccess(key, stringValue);
		}

		public static void SetupKeyAndPath(this Mock<IConfigurationSection> @this, string key, string basePath)
		{
			@this
				.SetupGet(x => x.Key)
				.Returns(key);

			@this
				.SetupGet(x => x.Path)
				.Returns(PathUtils.Append(basePath, key));
		}

		public static void SetupChildren<T>(this Mock<T> @this, IReadOnlyList<IConfigurationSection> children)
			where T : class, IConfiguration
		{
			@this
				.Setup(x => x.GetChildren())
				.Returns(children);
		}

		public static void SetupSection<T>(this Mock<T> @this, IConfigurationSection configurationSection, string relativePath)
			where T : class, IConfiguration
		{
			@this
				.Setup(x => x.GetSection(relativePath))
				.Returns(configurationSection);

			@this.SetupPathAccess(relativePath, configurationSection.Value);
		}

		public static IConfigurationSection SetupEmptySection(this Mock<IConfigurationSection> @this, string relativePath)
		{
			var section = Mock.Of<IConfigurationSection>();

			@this
				.Setup(x => x.GetSection(relativePath))
				.Returns(section);

			return section;
		}

		private static void SetupPathAccess<T>(this Mock<T> @this, string relativePath, string value)
			where T : class, IConfiguration
		{
			@this
				.Setup(x => x[relativePath])
				.Returns(value);
		}
	}
}

using Microsoft.Extensions.Configuration;

namespace Moq.Microsoft.Configuration
{
	internal static class MockConfigurationSectionExtensions
	{
		public static void SetupValue(this Mock<IConfigurationSection> @this, object value, string key, string basePath)
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

		public static void SetupPathAccess<T>(this Mock<T> @this, string path, string value)
			where T : class, IConfiguration
		{
			@this
				.Setup(x => x[path])
				.Returns(value);
		}

		public static void SetupSection<T>(this Mock<T> @this, IConfigurationSection configurationSection, string name)
			where T : class, IConfiguration
		{
			@this
				.Setup(x => x.GetSection(name))
				.Returns(configurationSection);
		}
	}
}

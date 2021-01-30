using Microsoft.Extensions.Configuration;

namespace Moq.Microsoft.Configuration
{
	internal static class MockConfigurationExtensions
	{
		public static void SetupValueForPath<TConfiguration, TValue>(this Mock<TConfiguration> @this, Mock<IConfigurationSection> mockConfigurationSection, TValue value, string path, string basePath = "")
			where TConfiguration : class, IConfiguration
		{
			var returnsValue = mockConfigurationSection.SetupValue(value);
			@this.SetupValueForPath(returnsValue, path, basePath);
		}

		public static void SetupValueForPath<T>(this Mock<T> @this, string value, string path, string basePath = "")
			where T : class, IConfiguration
		{
			if (!string.IsNullOrEmpty(basePath))
				path = $"{basePath}:{path}";

			@this
				.Setup(x => x[path])
				.Returns(value);
		}
	}
}

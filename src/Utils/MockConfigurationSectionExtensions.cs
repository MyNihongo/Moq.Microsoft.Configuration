using Microsoft.Extensions.Configuration;

namespace Moq.Microsoft.Configuration
{
	internal static class MockConfigurationSectionExtensions
	{
		public static IConfigurationSection SetupValue(this Mock<IConfigurationSection> @this, object value, string key, string basePath)
		{
			var mockValue = new Mock<IConfigurationSection>();
			var stringValue = value.SerialiseValue()!;

			@this
				.Setup(x => x[key])
				.Returns(stringValue);

			mockValue
				.SetupGet(x => x.Value)
				.Returns(stringValue);

			mockValue
				.SetupGet(x => x.Key)
				.Returns(key);

			mockValue
				.SetupGet(x => x.Path)
				.Returns(PathUtils.Append(basePath, key));

			return mockValue.Object;
		}
	}
}

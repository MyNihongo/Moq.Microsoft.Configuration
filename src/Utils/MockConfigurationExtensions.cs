using Microsoft.Extensions.Configuration;

namespace Moq.Microsoft.Configuration
{
	internal static class MockConfigurationExtensions
	{
		public static void SetupValue<T, TValue>(this Mock<T> @this, Mock<IConfigurationSection> mockConfigurationSection, TValue value, string path)
			where T : class, IConfiguration
		{
			var returnsValue = value.SerialiseValue()!;

			mockConfigurationSection
				.SetupGet(x => x.Value)
				.Returns(returnsValue);

			@this
				.Setup(x => x[path])
				.Returns(returnsValue);
		}
	}
}

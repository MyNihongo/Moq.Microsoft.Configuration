using Microsoft.Extensions.Configuration;

namespace Moq.Microsoft.Configuration
{
	internal sealed class ValueSetup<T> : SetupBase, ISetup<T>
	{
		public ValueSetup(Mock<IConfiguration> mock, string path)
			: base(mock, path)
		{
		}

		public void Returns(T param)
		{
			var mockConfigurationSection = new Mock<IConfigurationSection>();

			MockConfiguration
				.Setup(x => x.GetSection(Path))
				.Returns(mockConfigurationSection.Object);

			mockConfigurationSection
				.SetupGet(x => x.Value)
				.Returns(param.SerialiseValue());
		}
	}
}

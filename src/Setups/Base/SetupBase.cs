using Microsoft.Extensions.Configuration;

namespace Moq.Microsoft.Configuration
{
	internal abstract class SetupBase
	{
		protected SetupBase(Mock<IConfiguration> mock, string path)
		{
			MockConfiguration = mock;

			MockConfiguration
				.Setup(x => x.GetSection(path))
				.Returns(MockConfigurationSection.Object);

			MockConfigurationSection
				.SetupGet(x => x.Path)
				.Returns(path);
		}

		internal Mock<IConfiguration> MockConfiguration { get; }

		internal Mock<IConfigurationSection> MockConfigurationSection { get; } = new();
	}
}

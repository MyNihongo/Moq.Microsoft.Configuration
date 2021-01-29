using Microsoft.Extensions.Configuration;

namespace Moq.Microsoft.Configuration
{
	internal abstract class SetupBase
	{
		protected SetupBase(Mock<IConfiguration> mock, string path)
		{
			MockConfiguration = mock;
			Path = path;

			MockConfiguration
				.Setup(x => x.GetSection(Path))
				.Returns(MockConfigurationSection.Object);
		}

		protected Mock<IConfiguration> MockConfiguration { get; }

		protected Mock<IConfigurationSection> MockConfigurationSection { get; } = new();

		public string Path { get; }
	}
}

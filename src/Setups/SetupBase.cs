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
		
		public string Path { get; }

		internal Mock<IConfiguration> MockConfiguration { get; }

		internal Mock<IConfigurationSection> MockConfigurationSection { get; } = new();
	}
}

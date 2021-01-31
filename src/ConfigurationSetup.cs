using Microsoft.Extensions.Configuration;

namespace Moq.Microsoft.Configuration
{
	internal sealed class ConfigurationSetup : ISetup<object>
	{
		public ConfigurationSetup(Mock<IConfiguration> mockConfiguration)
		{
			MockConfiguration = mockConfiguration;
		}

		internal Mock<IConfiguration> MockConfiguration { get; }

		public void Returns(object? param)
		{
			if (param == null)
				return;
			
			this.SetupConfigurationTree(param);
		}
	}
}

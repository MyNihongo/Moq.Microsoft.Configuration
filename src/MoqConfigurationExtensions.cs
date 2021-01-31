using Microsoft.Extensions.Configuration;

namespace Moq.Microsoft.Configuration
{
	public static class MoqConfigurationExtensions
	{
		public static ISetup<object> SetupConfiguration(this Mock<IConfiguration> @this)
			=> new ConfigurationSetup(@this);
	}
}

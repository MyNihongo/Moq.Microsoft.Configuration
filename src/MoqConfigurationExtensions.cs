using Microsoft.Extensions.Configuration;

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("Moq.Microsoft.Configuration.Tests")]
namespace Moq.Microsoft.Configuration
{
	public static class MoqConfigurationExtensions
	{
		public static ISetup<object> SetupConfiguration(this Mock<IConfiguration> @this)
			=> new ConfigurationSetup(@this);
	}
}

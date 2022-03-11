namespace Moq.Microsoft.Configuration;

public static class MoqConfigurationExtensions
{
	public static ISetup<object> SetupConfiguration<T>(this Mock<T> @this)
		where T : class, IConfiguration
	{
		return new ConfigurationSetup<T>(@this);
	}
}
namespace Moq.Microsoft.Configuration;

public static class MoqConfigurationEx
{
	public static ISetup<object> SetupConfiguration<T>(this Mock<T> @this)
		where T : class, IConfiguration
	{
		return new ConfigurationSetup<T>(@this);
	}
}

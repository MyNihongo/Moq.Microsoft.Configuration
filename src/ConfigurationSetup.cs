using Microsoft.Extensions.Configuration;

namespace Moq.Microsoft.Configuration;

internal sealed class ConfigurationSetup<T> : ISetup<object>
	where T : class, IConfiguration
{
	public ConfigurationSetup(Mock<T> mockConfiguration)
	{
		MockConfiguration = mockConfiguration;
	}

	internal Mock<T> MockConfiguration { get; }

	public void Returns(object? param)
	{
		if (param == null)
			return;
			
		this.SetupConfigurationTree(param);
	}

	void ISetup<object>.ReturnsEmpty() =>
		this.SetupConfigurationTree(EmptyModel.Instance);
}
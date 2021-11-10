using Microsoft.Extensions.Configuration;

namespace Moq.Microsoft.Configuration;

public sealed class EmptyMockConfiguration<T> : Mock<T>
	where T : class, IConfiguration
{
	public EmptyMockConfiguration()
	{
		this.SetupConfiguration()
			.ReturnsEmpty();
	}
}
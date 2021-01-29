using Microsoft.Extensions.Configuration;

namespace Moq.Microsoft.Configuration.Tests
{
	public abstract class MockTestsBase
	{
		protected Mock<IConfiguration> CreateClass() =>
			new Mock<IConfiguration>();
	}
}

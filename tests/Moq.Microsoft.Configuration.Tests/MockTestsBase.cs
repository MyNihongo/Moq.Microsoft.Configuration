using Microsoft.Extensions.Configuration;

namespace Moq.Microsoft.Configuration.Tests
{
	public abstract class MockTestsBase
	{
		protected static Mock<IConfiguration> CreateClass() =>
			new();
	}
}

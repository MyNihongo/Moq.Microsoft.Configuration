using Microsoft.Extensions.Configuration;

namespace Moq.Microsoft.Configuration.Tests
{
	public abstract class MockEmptyTestsBase
	{
		protected static EmptyMockConfiguration<IConfiguration> CreateClass() =>
			new();
	}
}

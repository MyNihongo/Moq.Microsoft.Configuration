using Microsoft.Extensions.Configuration;

namespace Moq.Microsoft.Configuration.Tests
{
	public abstract class MockTestsBase
	{
		protected Mock<IConfiguration> CreateClass() =>
			new Mock<IConfiguration>();

		protected class Test
		{
			public int Index { get; set; }

			public string Text { get; set; }
		}
	}
}

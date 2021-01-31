using Xunit;

namespace Moq.Microsoft.Configuration.Tests.ConfigurationSetupTests
{
	public sealed class ReturnsShould : MockTestsBase
	{
		[Fact]
		public void A()
		{
			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(new
				{
					Int = 123,
					Obj = new
					{
						Int = 1234,
						Double = 12.4d
					}
				});
		}
	}
}

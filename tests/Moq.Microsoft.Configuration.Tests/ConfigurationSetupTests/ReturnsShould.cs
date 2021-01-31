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
					Obj = new
					{
						Obj1 = new
						{
							Int = 123
						}
					}
				});
		}
	}
}

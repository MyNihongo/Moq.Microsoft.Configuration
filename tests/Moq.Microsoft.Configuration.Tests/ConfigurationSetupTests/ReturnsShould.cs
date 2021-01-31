using System.Linq;
using FluentAssertions;
using Xunit;

namespace Moq.Microsoft.Configuration.Tests.ConfigurationSetupTests
{
	public sealed class ReturnsShould : MockTestsBase
	{
		[Fact]
		public void SetupChildrenRoot()
		{
			var value = new
			{
				RootObject1 = new
				{
					RootObject1 = "string",
					Object1 = new
					{
						RootObject1 = "string",
					}
				},
				RootObject2 = new
				{
					String = "string",
					RootObject2 = 12.34d
				},
				RootObject3 = new
				{
					RootObject3 = new
					{
						RootObject3 = new
						{
							RootObject3 = "string"
						}
					}
				}
			};

			var expectedResult = new[]
			{
				nameof(value.RootObject1),
				nameof(value.RootObject2),
				nameof(value.RootObject3)
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetChildren()
				.Select(x => x.Path);

			result
				.Should()
				.BeEquivalentTo(expectedResult);
		}

		[Fact]
		public void SetupChildrenClassNode()
		{
			var value = new
			{
				RootObject1 = new
				{
					RootObject1 = "string",
					Object1 = new
					{
						RootObject1 = "string",
					}
				},
				RootObject2 = new
				{
					String = "string",
					RootObject2 = 12.34d
				},
				RootObject3 = new
				{
					RootObject3 = new
					{
						RootObject3 = new
						{
							RootObject3 = "string"
						}
					}
				}
			};

			var expectedResult = new[]
			{
				$"{nameof(value.RootObject1)}:{nameof(value.RootObject1.RootObject1)}",
				$"{nameof(value.RootObject1)}:{nameof(value.RootObject1.Object1)}"
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.RootObject1))
				.GetChildren()
				.Select(x => x.Path);

			result
				.Should()
				.BeEquivalentTo(expectedResult);
		}
	}
}

using System.Linq;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
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

		[Fact]
		public void SetupEnumerableWithClass()
		{
			var value = new
			{
				Items = new[]
				{
					new {Int = 1, String = "string1"},
					new {Int = 2, String = "string2"}
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var section = fixture.Object
				.GetSection(nameof(value.Items));

			for (var i = 0; i < value.Items.Length; i++)
			{
				var intResult = section.GetValue<int>($"{i}:Int");
				var stringResult = section.GetValue<string>($"{i}:String");

				new { Int = intResult, String = stringResult }
					.Should()
					.BeEquivalentTo(value.Items[i]);
			}
		}

		[Fact]
		public void SetupEnumerableWithClassFull()
		{
			var value = new
			{
				Items = new[]
				{
					new {Int = 1, String = "string1"},
					new {Int = 2, String = "string2"}
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			for (var i = 0; i < value.Items.Length; i++)
			{
				var intResult = fixture.Object.GetValue<int>($"{nameof(value.Items)}:{i}:Int");
				var stringResult = fixture.Object.GetValue<string>($"{nameof(value.Items)}:{i}:String");

				new { Int = intResult, String = stringResult }
					.Should()
					.BeEquivalentTo(value.Items[i]);
			}
		}

		[Fact]
		public void NotThrowNullRefForUnspecifiedSections()
		{
			const int intValue = 123, fallbackValue = -1234;

			var value = new
			{
				Set = intValue
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			fixture.Object
				.GetValue<int>(nameof(value.Set))
				.Should()
				.Be(intValue);

			fixture.Object
				.GetValue<int>("NotSet")
				.Should()
				.Be(0);

			fixture.Object
				.GetValue("NotSet", fallbackValue)
				.Should()
				.Be(fallbackValue);
		}
	}
}

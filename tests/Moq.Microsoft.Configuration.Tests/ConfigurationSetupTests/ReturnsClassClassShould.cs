using System;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Moq.Microsoft.Configuration.Tests.ConfigurationSetupTests
{
	public sealed class ReturnsClassClassShould : MockTestsBase
	{
		[Fact]
		public void ExistValueNode()
		{
			throw new Exception();
		}

		[Fact]
		public void ExistClassNode()
		{
			throw new Exception();
		}

		[Fact]
		public void ExistsRootNode()
		{
			throw new Exception();
		}
		
		[Theory]
		[InlineData(null)]
		[InlineData("value")]
		public void SetupClassWithString(string input)
		{
			var value = new
			{
				Key = new
				{
					Value = input
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Key))
				.GetValue<string>(nameof(value.Key.Value));

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("value")]
		public void SetupClassWithStringSection(string input)
		{
			var value = new
			{
				Key = new
				{
					Value = input
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Key))
				.GetSection(nameof(value.Key.Value))
				.Get<string>();

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("value")]
		public void SetupClassWithStringBrackets(string input)
		{
			var value = new
			{
				Key = new
				{
					Value = input
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Key))[nameof(value.Key.Value)];

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("value")]
		public void SetupClassWithStringBracketsFull(string input)
		{
			var value = new
			{
				Key = new
				{
					Value = input
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object[$"{nameof(value.Key)}:{nameof(value.Key.Value)}"];

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Fact]
		public void SetupClassWithBool()
		{
			var value = new
			{
				Key = new
				{
					Value = true
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Key))
				.GetValue<bool>(nameof(value.Key.Value));

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Fact]
		public void SetupClassWithBoolBrackets()
		{
			var value = new
			{
				Key = new
				{
					Value = true
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = bool.Parse(
				fixture.Object.GetSection(nameof(value.Key))[nameof(value.Key.Value)]);

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Fact]
		public void SetupClassWithBoolBracketsFull()
		{
			var value = new
			{
				Key = new
				{
					Value = true
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = bool.Parse(
				fixture.Object[$"{nameof(value.Key)}:{nameof(value.Key.Value)}"]);

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(true)]
		public void SetupClassWithNullableBool(bool? input)
		{
			var value = new
			{
				Key = new
				{
					Value = input
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Key))
				.GetValue<bool?>(nameof(value.Key.Value));

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(true)]
		public void SetupClassWithNullableBoolBrackets(bool? input)
		{
			var value = new
			{
				Key = new
				{
					Value = input
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var stringResult = fixture.Object
				.GetSection(nameof(value.Key))[nameof(value.Key.Value)];

			var result = input switch
			{
				null => string.IsNullOrEmpty(stringResult) ? (bool?)null : throw new Exception(),
				_ => bool.Parse(stringResult)
			};

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(true)]
		public void SetupClassWithNullableBoolBracketsFull(bool? input)
		{
			var value = new
			{
				Key = new
				{
					Value = input
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var stringResult = fixture.Object[$"{nameof(value.Key)}:{nameof(value.Key.Value)}"];

			var result = input switch
			{
				null => string.IsNullOrEmpty(stringResult) ? (bool?)null : throw new Exception(),
				_ => bool.Parse(stringResult)
			};

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Fact]
		public void SetupClassWithByte()
		{
			var value = new
			{
				Key = new
				{
					Value = (byte)123
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Key))
				.GetValue<byte>(nameof(value.Key.Value));

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Fact]
		public void SetupClassWithByteBrackets()
		{
			var value = new
			{
				Key = new
				{
					Value = (byte)123
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = byte.Parse(
				fixture.Object.GetSection(nameof(value.Key))[nameof(value.Key.Value)]);

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Fact]
		public void SetupClassWithByteBracketsFull()
		{
			var value = new
			{
				Key = new
				{
					Value = (byte)123
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = byte.Parse(
				fixture.Object[$"{nameof(value.Key)}:{nameof(value.Key.Value)}"]);

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData((byte)123)]
		public void SetupClassWithNullableByte(byte? input)
		{
			var value = new
			{
				Key = new
				{
					Value = input
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Key))
				.GetValue<byte?>(nameof(value.Key.Value));

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData((byte)123)]
		public void SetupClassWithNullableByteBrackets(byte? input)
		{
			var value = new
			{
				Key = new
				{
					Value = input
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var stringResult = fixture.Object
				.GetSection(nameof(value.Key))[nameof(value.Key.Value)];

			var result = input switch
			{
				null => string.IsNullOrEmpty(stringResult) ? (byte?)null : throw new Exception(),
				_ => byte.Parse(stringResult)
			};

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData((byte)123)]
		public void SetupClassWithNullableByteBracketsFull(byte? input)
		{
			var value = new
			{
				Key = new
				{
					Value = input
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var stringResult = fixture.Object[$"{nameof(value.Key)}:{nameof(value.Key.Value)}"];

			var result = input switch
			{
				null => string.IsNullOrEmpty(stringResult) ? (byte?)null : throw new Exception(),
				_ => byte.Parse(stringResult)
			};

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Fact]
		public void SetupClassWithSbyte()
		{
			var value = new
			{
				Key = new
				{
					Value = (sbyte)123
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Key))
				.GetValue<sbyte>(nameof(value.Key.Value));

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Fact]
		public void SetupClassWithSbyteBrackets()
		{
			var value = new
			{
				Key = new
				{
					Value = (sbyte)123
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = sbyte.Parse(
				fixture.Object.GetSection(nameof(value.Key))[nameof(value.Key.Value)]);

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Fact]
		public void SetupClassWithSbyteBracketsFull()
		{
			var value = new
			{
				Key = new
				{
					Value = (sbyte)123
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = sbyte.Parse(
				fixture.Object[$"{nameof(value.Key)}:{nameof(value.Key.Value)}"]);

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData((sbyte)123)]
		public void SetupClassWithNullableSbyte(sbyte? input)
		{
			var value = new
			{
				Key = new
				{
					Value = input
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Key))
				.GetValue<sbyte?>(nameof(value.Key.Value));

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData((sbyte)123)]
		public void SetupClassWithNullableSbyteBrackets(sbyte? input)
		{
			var value = new
			{
				Key = new
				{
					Value = input
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var stringResult = fixture.Object
				.GetSection(nameof(value.Key))[nameof(value.Key.Value)];

			var result = input switch
			{
				null => string.IsNullOrEmpty(stringResult) ? (sbyte?)null : throw new Exception(),
				_ => sbyte.Parse(stringResult)
			};

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData((sbyte)123)]
		public void SetupClassWithNullableSbyteBracketsFull(sbyte? input)
		{
			var value = new
			{
				Key = new
				{
					Value = input
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var stringResult = fixture.Object[$"{nameof(value.Key)}:{nameof(value.Key.Value)}"];

			var result = input switch
			{
				null => string.IsNullOrEmpty(stringResult) ? (sbyte?)null : throw new Exception(),
				_ => sbyte.Parse(stringResult)
			};

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Fact]
		public void SetupClassWithChar()
		{
			var value = new
			{
				Key = new
				{
					Value = '日'
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Key))
				.GetValue<char>(nameof(value.Key.Value));

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Fact]
		public void SetupClassWithCharBrackets()
		{
			var value = new
			{
				Key = new
				{
					Value = '日'
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = char.Parse(
				fixture.Object.GetSection(nameof(value.Key))[nameof(value.Key.Value)]);

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Fact]
		public void SetupClassWithCharBracketsFull()
		{
			var value = new
			{
				Key = new
				{
					Value = '日'
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = char.Parse(
				fixture.Object[$"{nameof(value.Key)}:{nameof(value.Key.Value)}"]);

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData('日')]
		public void SetupClassWithNullableChar(char? input)
		{
			var value = new
			{
				Key = new
				{
					Value = input
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Key))
				.GetValue<char?>(nameof(value.Key.Value));

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData('日')]
		public void SetupClassWithNullableCharBrackets(char? input)
		{
			var value = new
			{
				Key = new
				{
					Value = input
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var stringResult = fixture.Object
				.GetSection(nameof(value.Key))[nameof(value.Key.Value)];

			var result = input switch
			{
				null => string.IsNullOrEmpty(stringResult) ? (char?)null : throw new Exception(),
				_ => char.Parse(stringResult)
			};

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData('日')]
		public void SetupClassWithNullableCharBracketsFull(char? input)
		{
			var value = new
			{
				Key = new
				{
					Value = input
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var stringResult = fixture.Object[$"{nameof(value.Key)}:{nameof(value.Key.Value)}"];

			var result = input switch
			{
				null => string.IsNullOrEmpty(stringResult) ? (char?)null : throw new Exception(),
				_ => char.Parse(stringResult)
			};

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Fact]
		public void SetupClassWithDecimal()
		{
			var value = new
			{
				Key = new
				{
					Value = 123m
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Key))
				.GetValue<decimal>(nameof(value.Key.Value));

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Fact]
		public void SetupClassWithDecimalBrackets()
		{
			var value = new
			{
				Key = new
				{
					Value = 123m
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = decimal.Parse(
				fixture.Object.GetSection(nameof(value.Key))[nameof(value.Key.Value)]);

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Fact]
		public void SetupClassWithDecimalBracketsFull()
		{
			var value = new
			{
				Key = new
				{
					Value = 123m
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = decimal.Parse(
				fixture.Object[$"{nameof(value.Key)}:{nameof(value.Key.Value)}"]);

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(123)]
		public void SetupClassWithNullableDecimal(int? intInput)
		{
			var value = new
			{
				Key = new
				{
					Value = intInput switch
					{
						null => (decimal?)null,
						not null => Convert.ToDecimal(intInput)
					}
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Key))
				.GetValue<decimal?>(nameof(value.Key.Value));

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(123)]
		public void SetupClassWithNullableDecimalBrackets(int? intInput)
		{
			var value = new
			{
				Key = new
				{
					Value = intInput switch
					{
						null => (decimal?)null,
						not null => Convert.ToDecimal(intInput)
					}
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var stringResult = fixture.Object
				.GetSection(nameof(value.Key))[nameof(value.Key.Value)];

			var result = intInput switch
			{
				null => string.IsNullOrEmpty(stringResult) ? (decimal?)null : throw new Exception(),
				_ => decimal.Parse(stringResult)
			};

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(123)]
		public void SetupClassWithNullableDecimalBracketsFull(int? intInput)
		{
			var value = new
			{
				Key = new
				{
					Value = intInput switch
					{
						null => (decimal?)null,
						not null => Convert.ToDecimal(intInput)
					}
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var stringResult = fixture.Object[$"{nameof(value.Key)}:{nameof(value.Key.Value)}"];

			var result = intInput switch
			{
				null => string.IsNullOrEmpty(stringResult) ? (decimal?)null : throw new Exception(),
				_ => decimal.Parse(stringResult)
			};

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Fact]
		public void SetupClassWithDouble()
		{
			var value = new
			{
				Key = new
				{
					Value = 123d
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Key))
				.GetValue<double>(nameof(value.Key.Value));

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Fact]
		public void SetupClassWithDoubleBrackets()
		{
			var value = new
			{
				Key = new
				{
					Value = 123d
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = double.Parse(
				fixture.Object.GetSection(nameof(value.Key))[nameof(value.Key.Value)]);

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Fact]
		public void SetupClassWithDoubleBracketsFull()
		{
			var value = new
			{
				Key = new
				{
					Value = 123d
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = double.Parse(
				fixture.Object[$"{nameof(value.Key)}:{nameof(value.Key.Value)}"]);

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(123d)]
		public void SetupClassWithNullableDouble(double? input)
		{
			var value = new
			{
				Key = new
				{
					Value = input
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Key))
				.GetValue<double?>(nameof(value.Key.Value));

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(123d)]
		public void SetupClassWithNullableDoubleBrackets(double? input)
		{
			var value = new
			{
				Key = new
				{
					Value = input
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var stringResult = fixture.Object
				.GetSection(nameof(value.Key))[nameof(value.Key.Value)];

			var result = input switch
			{
				null => string.IsNullOrEmpty(stringResult) ? (double?)null : throw new Exception(),
				_ => double.Parse(stringResult)
			};

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(123d)]
		public void SetupClassWithNullableDoubleBracketsFull(double? input)
		{
			var value = new
			{
				Key = new
				{
					Value = input
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var stringResult = fixture.Object[$"{nameof(value.Key)}:{nameof(value.Key.Value)}"];

			var result = input switch
			{
				null => string.IsNullOrEmpty(stringResult) ? (double?)null : throw new Exception(),
				_ => double.Parse(stringResult)
			};

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Fact]
		public void SetupClassWithFloat()
		{
			var value = new
			{
				Key = new
				{
					Value = 123f
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Key))
				.GetValue<float>(nameof(value.Key.Value));

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Fact]
		public void SetupClassWithFloatBrackets()
		{
			var value = new
			{
				Key = new
				{
					Value = 123f
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = float.Parse(
				fixture.Object.GetSection(nameof(value.Key))[nameof(value.Key.Value)]);

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Fact]
		public void SetupClassWithFloatBracketsFull()
		{
			var value = new
			{
				Key = new
				{
					Value = 123f
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = float.Parse(
				fixture.Object[$"{nameof(value.Key)}:{nameof(value.Key.Value)}"]);

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(123f)]
		public void SetupClassWithNullableFloat(float? input)
		{
			var value = new
			{
				Key = new
				{
					Value = input
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Key))
				.GetValue<float?>(nameof(value.Key.Value));

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(123f)]
		public void SetupClassWithNullableFloatBrackets(float? input)
		{
			var value = new
			{
				Key = new
				{
					Value = input
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var stringResult = fixture.Object
				.GetSection(nameof(value.Key))[nameof(value.Key.Value)];

			var result = input switch
			{
				null => string.IsNullOrEmpty(stringResult) ? (float?)null : throw new Exception(),
				_ => float.Parse(stringResult)
			};

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(123f)]
		public void SetupClassWithNullableFloatBracketsFull(float? input)
		{
			var value = new
			{
				Key = new
				{
					Value = input
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var stringResult = fixture.Object[$"{nameof(value.Key)}:{nameof(value.Key.Value)}"];

			var result = input switch
			{
				null => string.IsNullOrEmpty(stringResult) ? (float?)null : throw new Exception(),
				_ => float.Parse(stringResult)
			};

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Fact]
		public void SetupClassWithInt()
		{
			var value = new
			{
				Key = new
				{
					Value = 123
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Key))
				.GetValue<int>(nameof(value.Key.Value));

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Fact]
		public void SetupClassWithIntBrackets()
		{
			var value = new
			{
				Key = new
				{
					Value = 123
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = int.Parse(
				fixture.Object.GetSection(nameof(value.Key))[nameof(value.Key.Value)]);

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Fact]
		public void SetupClassWithIntBracketsFull()
		{
			var value = new
			{
				Key = new
				{
					Value = 123
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = int.Parse(
				fixture.Object[$"{nameof(value.Key)}:{nameof(value.Key.Value)}"]);

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(123)]
		public void SetupClassWithNullableInt(int? input)
		{
			var value = new
			{
				Key = new
				{
					Value = input
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Key))
				.GetValue<int?>(nameof(value.Key.Value));

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(123)]
		public void SetupClassWithNullableIntBrackets(int? input)
		{
			var value = new
			{
				Key = new
				{
					Value = input
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var stringResult = fixture.Object
				.GetSection(nameof(value.Key))[nameof(value.Key.Value)];

			var result = input switch
			{
				null => string.IsNullOrEmpty(stringResult) ? (int?)null : throw new Exception(),
				_ => int.Parse(stringResult)
			};

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(123)]
		public void SetupClassWithNullableIntBracketsFull(int? input)
		{
			var value = new
			{
				Key = new
				{
					Value = input
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var stringResult = fixture.Object[$"{nameof(value.Key)}:{nameof(value.Key.Value)}"];

			var result = input switch
			{
				null => string.IsNullOrEmpty(stringResult) ? (int?)null : throw new Exception(),
				_ => int.Parse(stringResult)
			};

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Fact]
		public void SetupClassWithUint()
		{
			var value = new
			{
				Key = new
				{
					Value = 123u
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Key))
				.GetValue<uint>(nameof(value.Key.Value));

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Fact]
		public void SetupClassWithUintBrackets()
		{
			var value = new
			{
				Key = new
				{
					Value = 123u
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = uint.Parse(
				fixture.Object.GetSection(nameof(value.Key))[nameof(value.Key.Value)]);

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Fact]
		public void SetupClassWithUintBracketsFull()
		{
			var value = new
			{
				Key = new
				{
					Value = 123u
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = uint.Parse(
				fixture.Object[$"{nameof(value.Key)}:{nameof(value.Key.Value)}"]);

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(123u)]
		public void SetupClassWithNullableUint(uint? input)
		{
			var value = new
			{
				Key = new
				{
					Value = input
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Key))
				.GetValue<uint?>(nameof(value.Key.Value));

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(123u)]
		public void SetupClassWithNullableUintBrackets(uint? input)
		{
			var value = new
			{
				Key = new
				{
					Value = input
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var stringResult = fixture.Object
				.GetSection(nameof(value.Key))[nameof(value.Key.Value)];

			var result = input switch
			{
				null => string.IsNullOrEmpty(stringResult) ? (uint?)null : throw new Exception(),
				_ => uint.Parse(stringResult)
			};

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(123u)]
		public void SetupClassWithNullableUintBracketsFull(uint? input)
		{
			var value = new
			{
				Key = new
				{
					Value = input
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var stringResult = fixture.Object[$"{nameof(value.Key)}:{nameof(value.Key.Value)}"];

			var result = input switch
			{
				null => string.IsNullOrEmpty(stringResult) ? (uint?)null : throw new Exception(),
				_ => uint.Parse(stringResult)
			};

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Fact]
		public void SetupClassWithLong()
		{
			var value = new
			{
				Key = new
				{
					Value = 123L
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Key))
				.GetValue<long>(nameof(value.Key.Value));

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Fact]
		public void SetupClassWithLongBrackets()
		{
			var value = new
			{
				Key = new
				{
					Value = 123L
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = long.Parse(
				fixture.Object.GetSection(nameof(value.Key))[nameof(value.Key.Value)]);

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Fact]
		public void SetupClassWithLongBracketsFull()
		{
			var value = new
			{
				Key = new
				{
					Value = 123L
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = long.Parse(
				fixture.Object[$"{nameof(value.Key)}:{nameof(value.Key.Value)}"]);

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(123L)]
		public void SetupClassWithNullableLong(long? input)
		{
			var value = new
			{
				Key = new
				{
					Value = input
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Key))
				.GetValue<long?>(nameof(value.Key.Value));

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(123L)]
		public void SetupClassWithNullableLongBrackets(long? input)
		{
			var value = new
			{
				Key = new
				{
					Value = input
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var stringResult = fixture.Object
				.GetSection(nameof(value.Key))[nameof(value.Key.Value)];

			var result = input switch
			{
				null => string.IsNullOrEmpty(stringResult) ? (long?)null : throw new Exception(),
				_ => long.Parse(stringResult)
			};

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(123L)]
		public void SetupClassWithNullableLongBracketsFull(long? input)
		{
			var value = new
			{
				Key = new
				{
					Value = input
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var stringResult = fixture.Object[$"{nameof(value.Key)}:{nameof(value.Key.Value)}"];

			var result = input switch
			{
				null => string.IsNullOrEmpty(stringResult) ? (long?)null : throw new Exception(),
				_ => long.Parse(stringResult)
			};

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Fact]
		public void SetupClassWithUlong()
		{
			var value = new
			{
				Key = new
				{
					Value = 123UL
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Key))
				.GetValue<ulong>(nameof(value.Key.Value));

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Fact]
		public void SetupClassWithUlongBrackets()
		{
			var value = new
			{
				Key = new
				{
					Value = 123UL
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = ulong.Parse(
				fixture.Object.GetSection(nameof(value.Key))[nameof(value.Key.Value)]);

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Fact]
		public void SetupClassWithUlongBracketsFull()
		{
			var value = new
			{
				Key = new
				{
					Value = 123UL
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = ulong.Parse(
				fixture.Object[$"{nameof(value.Key)}:{nameof(value.Key.Value)}"]);

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(123UL)]
		public void SetupClassWithNullableUlong(ulong? input)
		{
			var value = new
			{
				Key = new
				{
					Value = input
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Key))
				.GetValue<ulong?>(nameof(value.Key.Value));

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(123UL)]
		public void SetupClassWithNullableUlongBrackets(ulong? input)
		{
			var value = new
			{
				Key = new
				{
					Value = input
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var stringResult = fixture.Object
				.GetSection(nameof(value.Key))[nameof(value.Key.Value)];

			var result = input switch
			{
				null => string.IsNullOrEmpty(stringResult) ? (ulong?)null : throw new Exception(),
				_ => ulong.Parse(stringResult)
			};

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(123UL)]
		public void SetupClassWithNullableUlongBracketsFull(ulong? input)
		{
			var value = new
			{
				Key = new
				{
					Value = input
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var stringResult = fixture.Object[$"{nameof(value.Key)}:{nameof(value.Key.Value)}"];

			var result = input switch
			{
				null => string.IsNullOrEmpty(stringResult) ? (ulong?)null : throw new Exception(),
				_ => ulong.Parse(stringResult)
			};

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Fact]
		public void SetupClassWithShort()
		{
			var value = new
			{
				Key = new
				{
					Value = (short)123
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Key))
				.GetValue<short>(nameof(value.Key.Value));

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Fact]
		public void SetupClassWithShortBrackets()
		{
			var value = new
			{
				Key = new
				{
					Value = (short)123
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = short.Parse(
				fixture.Object.GetSection(nameof(value.Key))[nameof(value.Key.Value)]);

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Fact]
		public void SetupClassWithShortBracketsFull()
		{
			var value = new
			{
				Key = new
				{
					Value = (short)123
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = short.Parse(
				fixture.Object[$"{nameof(value.Key)}:{nameof(value.Key.Value)}"]);

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData((short)123)]
		public void SetupClassWithNullableShort(short? input)
		{
			var value = new
			{
				Key = new
				{
					Value = input
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Key))
				.GetValue<short?>(nameof(value.Key.Value));

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData((short)123)]
		public void SetupClassWithNullableShortBrackets(short? input)
		{
			var value = new
			{
				Key = new
				{
					Value = input
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var stringResult = fixture.Object
				.GetSection(nameof(value.Key))[nameof(value.Key.Value)];

			var result = input switch
			{
				null => string.IsNullOrEmpty(stringResult) ? (short?)null : throw new Exception(),
				_ => short.Parse(stringResult)
			};

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData((short)123)]
		public void SetupClassWithNullableShortBracketsFull(short? input)
		{
			var value = new
			{
				Key = new
				{
					Value = input
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var stringResult = fixture.Object[$"{nameof(value.Key)}:{nameof(value.Key.Value)}"];

			var result = input switch
			{
				null => string.IsNullOrEmpty(stringResult) ? (short?)null : throw new Exception(),
				_ => short.Parse(stringResult)
			};

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Fact]
		public void SetupClassWithUshort()
		{
			var value = new
			{
				Key = new
				{
					Value = (ushort)123
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Key))
				.GetValue<ushort>(nameof(value.Key.Value));

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Fact]
		public void SetupClassWithUshortBrackets()
		{
			var value = new
			{
				Key = new
				{
					Value = (ushort)123
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = ushort.Parse(
				fixture.Object.GetSection(nameof(value.Key))[nameof(value.Key.Value)]);

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Fact]
		public void SetupClassWithUshortBracketsFull()
		{
			var value = new
			{
				Key = new
				{
					Value = (ushort)123
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = ushort.Parse(
				fixture.Object[$"{nameof(value.Key)}:{nameof(value.Key.Value)}"]);

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData((ushort)123)]
		public void SetupClassWithNullableUshort(ushort? input)
		{
			var value = new
			{
				Key = new
				{
					Value = input
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Key))
				.GetValue<ushort?>(nameof(value.Key.Value));

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData((ushort)123)]
		public void SetupClassWithNullableUshortBrackets(ushort? input)
		{
			var value = new
			{
				Key = new
				{
					Value = input
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var stringResult = fixture.Object
				.GetSection(nameof(value.Key))[nameof(value.Key.Value)];

			var result = input switch
			{
				null => string.IsNullOrEmpty(stringResult) ? (ushort?)null : throw new Exception(),
				_ => ushort.Parse(stringResult)
			};

			result
				.Should()
				.Be(value.Key.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData((ushort)123)]
		public void SetupClassWithNullableUshortBracketsFull(ushort? input)
		{
			var value = new
			{
				Key = new
				{
					Value = input
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var stringResult = fixture.Object[$"{nameof(value.Key)}:{nameof(value.Key.Value)}"];

			var result = input switch
			{
				null => string.IsNullOrEmpty(stringResult) ? (ushort?)null : throw new Exception(),
				_ => ushort.Parse(stringResult)
			};

			result
				.Should()
				.Be(value.Key.Value);
		}
	}
}

using System;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Moq.Microsoft.Configuration.Tests.Setups.SectionSetupTests
{
	public sealed class ReturnsClassShould : MockTestsBase
	{
		[Theory]
		[InlineData(null)]
		[InlineData("value")]
		public void SetupClassWithString(string input)
		{
			const string key = nameof(key);
			var value = new
			{
				Value = input
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = fixture.Object
				.GetSection(key)
				.GetValue<string>(nameof(value.Value));

			result
				.Should()
				.Be(value.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("value")]
		public void SetupClassWithStringBrackets(string input)
		{
			const string key = nameof(key);
			var value = new
			{
				Value = input
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = fixture.Object
				.GetSection(key)[nameof(value.Value)];

			result
				.Should()
				.Be(value.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("value")]
		public void SetupClassWithStringBracketsFull(string input)
		{
			const string key = nameof(key);
			var value = new
			{
				Value = input
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = fixture.Object[$"{key}:{nameof(value.Value)}"];

			result
				.Should()
				.Be(value.Value);
		}

		[Fact]
		public void SetupClassWithBool()
		{
			const string key = nameof(key);
			var value = new
			{
				Value = true
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = fixture.Object
				.GetSection(key)
				.GetValue<bool>(nameof(value.Value));

			result
				.Should()
				.Be(value.Value);
		}

		[Fact]
		public void SetupClassWithBoolBrackets()
		{
			const string key = nameof(key);
			var value = new
			{
				Value = true
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = bool.Parse(
				fixture.Object.GetSection(key)[nameof(value.Value)]);

			result
				.Should()
				.Be(value.Value);
		}

		[Fact]
		public void SetupClassWithBoolBracketsFull()
		{
			const string key = nameof(key);
			var value = new
			{
				Value = true
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = bool.Parse(
				fixture.Object[$"{key}:{nameof(value.Value)}"]);

			result
				.Should()
				.Be(value.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(true)]
		public void SetupClassWithNullableBool(bool? input)
		{
			const string key = nameof(key);
			var value = new
			{
				Value = input
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = fixture.Object
				.GetSection(key)
				.GetValue<bool?>(nameof(value.Value));

			result
				.Should()
				.Be(value.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(true)]
		public void SetupClassWithNullableBoolBrackets(bool? input)
		{
			const string key = nameof(key);
			var value = new
			{
				Value = input
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var stringResult = fixture.Object
				.GetSection(key)[nameof(value.Value)];

			var result = input switch
			{
				null => string.IsNullOrEmpty(stringResult) ? (bool?)null : throw new Exception(),
				_ => bool.Parse(stringResult)
			};

			result
				.Should()
				.Be(value.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(true)]
		public void SetupClassWithNullableBoolBracketsFull(bool? input)
		{
			const string key = nameof(key);
			var value = new
			{
				Value = input
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var stringResult = fixture.Object[$"{key}:{nameof(value.Value)}"];

			var result = input switch
			{
				null => string.IsNullOrEmpty(stringResult) ? (bool?)null : throw new Exception(),
				_ => bool.Parse(stringResult)
			};

			result
				.Should()
				.Be(value.Value);
		}

		[Fact]
		public void SetupClassWithByte()
		{
			const string key = nameof(key);
			var value = new
			{
				Value = (byte)123
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = fixture.Object
				.GetSection(key)
				.GetValue<byte>(nameof(value.Value));

			result
				.Should()
				.Be(value.Value);
		}

		[Fact]
		public void SetupClassWithByteBrackets()
		{
			const string key = nameof(key);
			var value = new
			{
				Value = (byte)123
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = byte.Parse(
				fixture.Object.GetSection(key)[nameof(value.Value)]);

			result
				.Should()
				.Be(value.Value);
		}

		[Fact]
		public void SetupClassWithByteBracketsFull()
		{
			const string key = nameof(key);
			var value = new
			{
				Value = (byte)123
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = byte.Parse(
				fixture.Object[$"{key}:{nameof(value.Value)}"]);

			result
				.Should()
				.Be(value.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData((byte)123)]
		public void SetupClassWithNullableByte(byte? input)
		{
			const string key = nameof(key);
			var value = new
			{
				Value = input
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = fixture.Object
				.GetSection(key)
				.GetValue<byte?>(nameof(value.Value));

			result
				.Should()
				.Be(value.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData((byte)123)]
		public void SetupClassWithNullableByteBrackets(byte? input)
		{
			const string key = nameof(key);
			var value = new
			{
				Value = input
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var stringResult = fixture.Object
				.GetSection(key)[nameof(value.Value)];

			var result = input switch
			{
				null => string.IsNullOrEmpty(stringResult) ? (byte?)null : throw new Exception(),
				_ => byte.Parse(stringResult)
			};

			result
				.Should()
				.Be(value.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData((byte)123)]
		public void SetupClassWithNullableByteBracketsFull(byte? input)
		{
			const string key = nameof(key);
			var value = new
			{
				Value = input
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var stringResult = fixture.Object[$"{key}:{nameof(value.Value)}"];

			var result = input switch
			{
				null => string.IsNullOrEmpty(stringResult) ? (byte?)null : throw new Exception(),
				_ => byte.Parse(stringResult)
			};

			result
				.Should()
				.Be(value.Value);
		}

		[Fact]
		public void SetupClassWithSbyte()
		{
			const string key = nameof(key);
			var value = new
			{
				Value = (sbyte)123
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = fixture.Object
				.GetSection(key)
				.GetValue<sbyte>(nameof(value.Value));

			result
				.Should()
				.Be(value.Value);
		}

		[Fact]
		public void SetupClassWithSbyteBrackets()
		{
			const string key = nameof(key);
			var value = new
			{
				Value = (sbyte)123
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = sbyte.Parse(
				fixture.Object.GetSection(key)[nameof(value.Value)]);

			result
				.Should()
				.Be(value.Value);
		}

		[Fact]
		public void SetupClassWithSbyteBracketsFull()
		{
			const string key = nameof(key);
			var value = new
			{
				Value = (sbyte)123
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = sbyte.Parse(
				fixture.Object[$"{key}:{nameof(value.Value)}"]);

			result
				.Should()
				.Be(value.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData((sbyte)123)]
		public void SetupClassWithNullableSbyte(sbyte? input)
		{
			const string key = nameof(key);
			var value = new
			{
				Value = input
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = fixture.Object
				.GetSection(key)
				.GetValue<sbyte?>(nameof(value.Value));

			result
				.Should()
				.Be(value.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData((sbyte)123)]
		public void SetupClassWithNullableSbyteBrackets(sbyte? input)
		{
			const string key = nameof(key);
			var value = new
			{
				Value = input
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var stringResult = fixture.Object
				.GetSection(key)[nameof(value.Value)];

			var result = input switch
			{
				null => string.IsNullOrEmpty(stringResult) ? (sbyte?)null : throw new Exception(),
				_ => sbyte.Parse(stringResult)
			};

			result
				.Should()
				.Be(value.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData((sbyte)123)]
		public void SetupClassWithNullableSbyteBracketsFull(sbyte? input)
		{
			const string key = nameof(key);
			var value = new
			{
				Value = input
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var stringResult = fixture.Object[$"{key}:{nameof(value.Value)}"];

			var result = input switch
			{
				null => string.IsNullOrEmpty(stringResult) ? (sbyte?)null : throw new Exception(),
				_ => sbyte.Parse(stringResult)
			};

			result
				.Should()
				.Be(value.Value);
		}

		[Fact]
		public void SetupClassWithChar()
		{
			const string key = nameof(key);
			var value = new
			{
				Value = '日'
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = fixture.Object
				.GetSection(key)
				.GetValue<char>(nameof(value.Value));

			result
				.Should()
				.Be(value.Value);
		}

		[Fact]
		public void SetupClassWithCharBrackets()
		{
			const string key = nameof(key);
			var value = new
			{
				Value = '日'
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = char.Parse(
				fixture.Object.GetSection(key)[nameof(value.Value)]);

			result
				.Should()
				.Be(value.Value);
		}

		[Fact]
		public void SetupClassWithCharBracketsFull()
		{
			const string key = nameof(key);
			var value = new
			{
				Value = '日'
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = char.Parse(
				fixture.Object[$"{key}:{nameof(value.Value)}"]);

			result
				.Should()
				.Be(value.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData('日')]
		public void SetupClassWithNullableChar(char? input)
		{
			const string key = nameof(key);
			var value = new
			{
				Value = input
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = fixture.Object
				.GetSection(key)
				.GetValue<char?>(nameof(value.Value));

			result
				.Should()
				.Be(value.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData('日')]
		public void SetupClassWithNullableCharBrackets(char? input)
		{
			const string key = nameof(key);
			var value = new
			{
				Value = input
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var stringResult = fixture.Object
				.GetSection(key)[nameof(value.Value)];

			var result = input switch
			{
				null => string.IsNullOrEmpty(stringResult) ? (char?)null : throw new Exception(),
				_ => char.Parse(stringResult)
			};

			result
				.Should()
				.Be(value.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData('日')]
		public void SetupClassWithNullableCharBracketsFull(char? input)
		{
			const string key = nameof(key);
			var value = new
			{
				Value = input
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var stringResult = fixture.Object[$"{key}:{nameof(value.Value)}"];

			var result = input switch
			{
				null => string.IsNullOrEmpty(stringResult) ? (char?)null : throw new Exception(),
				_ => char.Parse(stringResult)
			};

			result
				.Should()
				.Be(value.Value);
		}

		[Fact]
		public void SetupClassWithDecimal()
		{
			const string key = nameof(key);
			var value = new
			{
				Value = 123m
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = fixture.Object
				.GetSection(key)
				.GetValue<decimal>(nameof(value.Value));

			result
				.Should()
				.Be(value.Value);
		}

		[Fact]
		public void SetupClassWithDecimalBrackets()
		{
			const string key = nameof(key);
			var value = new
			{
				Value = 123m
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = decimal.Parse(
				fixture.Object.GetSection(key)[nameof(value.Value)]);

			result
				.Should()
				.Be(value.Value);
		}

		[Fact]
		public void SetupClassWithDecimalBracketsFull()
		{
			const string key = nameof(key);
			var value = new
			{
				Value = 123m
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = decimal.Parse(
				fixture.Object[$"{key}:{nameof(value.Value)}"]);

			result
				.Should()
				.Be(value.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(123)]
		public void SetupClassWithNullableDecimal(int? intInput)
		{
			const string key = nameof(key);
			var value = new
			{
				Value = intInput switch
				{
					null => (decimal?)null,
					not null => Convert.ToDecimal(intInput)
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = fixture.Object
				.GetSection(key)
				.GetValue<decimal?>(nameof(value.Value));

			result
				.Should()
				.Be(value.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(123)]
		public void SetupClassWithNullableDecimalBrackets(int? intInput)
		{
			const string key = nameof(key);
			var value = new
			{
				Value = intInput switch
				{
					null => (decimal?)null,
					not null => Convert.ToDecimal(intInput)
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var stringResult = fixture.Object
				.GetSection(key)[nameof(value.Value)];

			var result = intInput switch
			{
				null => string.IsNullOrEmpty(stringResult) ? (decimal?)null : throw new Exception(),
				_ => decimal.Parse(stringResult)
			};

			result
				.Should()
				.Be(value.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(123)]
		public void SetupClassWithNullableDecimalBracketsFull(int? intInput)
		{
			const string key = nameof(key);
			var value = new
			{
				Value = intInput switch
				{
					null => (decimal?)null,
					not null => Convert.ToDecimal(intInput)
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var stringResult = fixture.Object[$"{key}:{nameof(value.Value)}"];

			var result = intInput switch
			{
				null => string.IsNullOrEmpty(stringResult) ? (decimal?)null : throw new Exception(),
				_ => decimal.Parse(stringResult)
			};

			result
				.Should()
				.Be(value.Value);
		}

		[Fact]
		public void SetupClassWithDouble()
		{
			const string key = nameof(key);
			var value = new
			{
				Value = 123d
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = fixture.Object
				.GetSection(key)
				.GetValue<double>(nameof(value.Value));

			result
				.Should()
				.Be(value.Value);
		}

		[Fact]
		public void SetupClassWithDoubleBrackets()
		{
			const string key = nameof(key);
			var value = new
			{
				Value = 123d
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = double.Parse(
				fixture.Object.GetSection(key)[nameof(value.Value)]);

			result
				.Should()
				.Be(value.Value);
		}

		[Fact]
		public void SetupClassWithDoubleBracketsFull()
		{
			const string key = nameof(key);
			var value = new
			{
				Value = 123d
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = double.Parse(
				fixture.Object[$"{key}:{nameof(value.Value)}"]);

			result
				.Should()
				.Be(value.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(123d)]
		public void SetupClassWithNullableDouble(double? input)
		{
			const string key = nameof(key);
			var value = new
			{
				Value = input
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = fixture.Object
				.GetSection(key)
				.GetValue<double?>(nameof(value.Value));

			result
				.Should()
				.Be(value.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(123d)]
		public void SetupClassWithNullableDoubleBrackets(double? input)
		{
			const string key = nameof(key);
			var value = new
			{
				Value = input
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var stringResult = fixture.Object
				.GetSection(key)[nameof(value.Value)];

			var result = input switch
			{
				null => string.IsNullOrEmpty(stringResult) ? (double?)null : throw new Exception(),
				_ => double.Parse(stringResult)
			};

			result
				.Should()
				.Be(value.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(123d)]
		public void SetupClassWithNullableDoubleBracketsFull(double? input)
		{
			const string key = nameof(key);
			var value = new
			{
				Value = input
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var stringResult = fixture.Object[$"{key}:{nameof(value.Value)}"];

			var result = input switch
			{
				null => string.IsNullOrEmpty(stringResult) ? (double?)null : throw new Exception(),
				_ => double.Parse(stringResult)
			};

			result
				.Should()
				.Be(value.Value);
		}

		[Fact]
		public void SetupClassWithFloat()
		{
			const string key = nameof(key);
			var value = new
			{
				Value = 123f
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = fixture.Object
				.GetSection(key)
				.GetValue<float>(nameof(value.Value));

			result
				.Should()
				.Be(value.Value);
		}

		[Fact]
		public void SetupClassWithFloatBrackets()
		{
			const string key = nameof(key);
			var value = new
			{
				Value = 123f
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = float.Parse(
				fixture.Object.GetSection(key)[nameof(value.Value)]);

			result
				.Should()
				.Be(value.Value);
		}

		[Fact]
		public void SetupClassWithFloatBracketsFull()
		{
			const string key = nameof(key);
			var value = new
			{
				Value = 123f
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = float.Parse(
				fixture.Object[$"{key}:{nameof(value.Value)}"]);

			result
				.Should()
				.Be(value.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(123f)]
		public void SetupClassWithNullableFloat(float? input)
		{
			const string key = nameof(key);
			var value = new
			{
				Value = input
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = fixture.Object
				.GetSection(key)
				.GetValue<float?>(nameof(value.Value));

			result
				.Should()
				.Be(value.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(123f)]
		public void SetupClassWithNullableFloatBrackets(float? input)
		{
			const string key = nameof(key);
			var value = new
			{
				Value = input
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var stringResult = fixture.Object
				.GetSection(key)[nameof(value.Value)];

			var result = input switch
			{
				null => string.IsNullOrEmpty(stringResult) ? (float?)null : throw new Exception(),
				_ => float.Parse(stringResult)
			};

			result
				.Should()
				.Be(value.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(123f)]
		public void SetupClassWithNullableFloatBracketsFull(float? input)
		{
			const string key = nameof(key);
			var value = new
			{
				Value = input
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var stringResult = fixture.Object[$"{key}:{nameof(value.Value)}"];

			var result = input switch
			{
				null => string.IsNullOrEmpty(stringResult) ? (float?)null : throw new Exception(),
				_ => float.Parse(stringResult)
			};

			result
				.Should()
				.Be(value.Value);
		}

		[Fact]
		public void SetupClassWithInt()
		{
			const string key = nameof(key);
			var value = new
			{
				Value = 123
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = fixture.Object
				.GetSection(key)
				.GetValue<int>(nameof(value.Value));

			result
				.Should()
				.Be(value.Value);
		}

		[Fact]
		public void SetupClassWithIntBrackets()
		{
			const string key = nameof(key);
			var value = new
			{
				Value = 123
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = int.Parse(
				fixture.Object.GetSection(key)[nameof(value.Value)]);

			result
				.Should()
				.Be(value.Value);
		}

		[Fact]
		public void SetupClassWithIntBracketsFull()
		{
			const string key = nameof(key);
			var value = new
			{
				Value = 123
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = int.Parse(
				fixture.Object[$"{key}:{nameof(value.Value)}"]);

			result
				.Should()
				.Be(value.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(123)]
		public void SetupClassWithNullableInt(int? input)
		{
			const string key = nameof(key);
			var value = new
			{
				Value = input
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = fixture.Object
				.GetSection(key)
				.GetValue<int?>(nameof(value.Value));

			result
				.Should()
				.Be(value.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(123)]
		public void SetupClassWithNullableIntBrackets(int? input)
		{
			const string key = nameof(key);
			var value = new
			{
				Value = input
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var stringResult = fixture.Object
				.GetSection(key)[nameof(value.Value)];

			var result = input switch
			{
				null => string.IsNullOrEmpty(stringResult) ? (int?)null : throw new Exception(),
				_ => int.Parse(stringResult)
			};

			result
				.Should()
				.Be(value.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(123)]
		public void SetupClassWithNullableIntBracketsFull(int? input)
		{
			const string key = nameof(key);
			var value = new
			{
				Value = input
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var stringResult = fixture.Object[$"{key}:{nameof(value.Value)}"];

			var result = input switch
			{
				null => string.IsNullOrEmpty(stringResult) ? (int?)null : throw new Exception(),
				_ => int.Parse(stringResult)
			};

			result
				.Should()
				.Be(value.Value);
		}

		[Fact]
		public void SetupClassWithUint()
		{
			const string key = nameof(key);
			var value = new
			{
				Value = 123u
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = fixture.Object
				.GetSection(key)
				.GetValue<uint>(nameof(value.Value));

			result
				.Should()
				.Be(value.Value);
		}

		[Fact]
		public void SetupClassWithUintBrackets()
		{
			const string key = nameof(key);
			var value = new
			{
				Value = 123u
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = uint.Parse(
				fixture.Object.GetSection(key)[nameof(value.Value)]);

			result
				.Should()
				.Be(value.Value);
		}

		[Fact]
		public void SetupClassWithUintBracketsFull()
		{
			const string key = nameof(key);
			var value = new
			{
				Value = 123u
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = uint.Parse(
				fixture.Object[$"{key}:{nameof(value.Value)}"]);

			result
				.Should()
				.Be(value.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(123u)]
		public void SetupClassWithNullableUint(uint? input)
		{
			const string key = nameof(key);
			var value = new
			{
				Value = input
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = fixture.Object
				.GetSection(key)
				.GetValue<uint?>(nameof(value.Value));

			result
				.Should()
				.Be(value.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(123u)]
		public void SetupClassWithNullableUintBrackets(uint? input)
		{
			const string key = nameof(key);
			var value = new
			{
				Value = input
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var stringResult = fixture.Object
				.GetSection(key)[nameof(value.Value)];

			var result = input switch
			{
				null => string.IsNullOrEmpty(stringResult) ? (uint?)null : throw new Exception(),
				_ => uint.Parse(stringResult)
			};

			result
				.Should()
				.Be(value.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(123u)]
		public void SetupClassWithNullableUintBracketsFull(uint? input)
		{
			const string key = nameof(key);
			var value = new
			{
				Value = input
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var stringResult = fixture.Object[$"{key}:{nameof(value.Value)}"];

			var result = input switch
			{
				null => string.IsNullOrEmpty(stringResult) ? (uint?)null : throw new Exception(),
				_ => uint.Parse(stringResult)
			};

			result
				.Should()
				.Be(value.Value);
		}

		[Fact]
		public void SetupClassWithLong()
		{
			const string key = nameof(key);
			var value = new
			{
				Value = 123L
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = fixture.Object
				.GetSection(key)
				.GetValue<long>(nameof(value.Value));

			result
				.Should()
				.Be(value.Value);
		}

		[Fact]
		public void SetupClassWithLongBrackets()
		{
			const string key = nameof(key);
			var value = new
			{
				Value = 123L
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = long.Parse(
				fixture.Object.GetSection(key)[nameof(value.Value)]);

			result
				.Should()
				.Be(value.Value);
		}

		[Fact]
		public void SetupClassWithLongBracketsFull()
		{
			const string key = nameof(key);
			var value = new
			{
				Value = 123L
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = long.Parse(
				fixture.Object[$"{key}:{nameof(value.Value)}"]);

			result
				.Should()
				.Be(value.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(123L)]
		public void SetupClassWithNullableLong(long? input)
		{
			const string key = nameof(key);
			var value = new
			{
				Value = input
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = fixture.Object
				.GetSection(key)
				.GetValue<long?>(nameof(value.Value));

			result
				.Should()
				.Be(value.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(123L)]
		public void SetupClassWithNullableLongBrackets(long? input)
		{
			const string key = nameof(key);
			var value = new
			{
				Value = input
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var stringResult = fixture.Object
				.GetSection(key)[nameof(value.Value)];

			var result = input switch
			{
				null => string.IsNullOrEmpty(stringResult) ? (long?)null : throw new Exception(),
				_ => long.Parse(stringResult)
			};

			result
				.Should()
				.Be(value.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(123L)]
		public void SetupClassWithNullableLongBracketsFull(long? input)
		{
			const string key = nameof(key);
			var value = new
			{
				Value = input
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var stringResult = fixture.Object[$"{key}:{nameof(value.Value)}"];

			var result = input switch
			{
				null => string.IsNullOrEmpty(stringResult) ? (long?)null : throw new Exception(),
				_ => long.Parse(stringResult)
			};

			result
				.Should()
				.Be(value.Value);
		}

		[Fact]
		public void SetupClassWithUlong()
		{
			const string key = nameof(key);
			var value = new
			{
				Value = 123UL
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = fixture.Object
				.GetSection(key)
				.GetValue<ulong>(nameof(value.Value));

			result
				.Should()
				.Be(value.Value);
		}

		[Fact]
		public void SetupClassWithUlongBrackets()
		{
			const string key = nameof(key);
			var value = new
			{
				Value = 123UL
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = ulong.Parse(
				fixture.Object.GetSection(key)[nameof(value.Value)]);

			result
				.Should()
				.Be(value.Value);
		}

		[Fact]
		public void SetupClassWithUlongBracketsFull()
		{
			const string key = nameof(key);
			var value = new
			{
				Value = 123UL
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = ulong.Parse(
				fixture.Object[$"{key}:{nameof(value.Value)}"]);

			result
				.Should()
				.Be(value.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(123UL)]
		public void SetupClassWithNullableUlong(ulong? input)
		{
			const string key = nameof(key);
			var value = new
			{
				Value = input
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = fixture.Object
				.GetSection(key)
				.GetValue<ulong?>(nameof(value.Value));

			result
				.Should()
				.Be(value.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(123UL)]
		public void SetupClassWithNullableUlongBrackets(ulong? input)
		{
			const string key = nameof(key);
			var value = new
			{
				Value = input
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var stringResult = fixture.Object
				.GetSection(key)[nameof(value.Value)];

			var result = input switch
			{
				null => string.IsNullOrEmpty(stringResult) ? (ulong?)null : throw new Exception(),
				_ => ulong.Parse(stringResult)
			};

			result
				.Should()
				.Be(value.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(123UL)]
		public void SetupClassWithNullableUlongBracketsFull(ulong? input)
		{
			const string key = nameof(key);
			var value = new
			{
				Value = input
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var stringResult = fixture.Object[$"{key}:{nameof(value.Value)}"];

			var result = input switch
			{
				null => string.IsNullOrEmpty(stringResult) ? (ulong?)null : throw new Exception(),
				_ => ulong.Parse(stringResult)
			};

			result
				.Should()
				.Be(value.Value);
		}

		[Fact]
		public void SetupClassWithShort()
		{
			const string key = nameof(key);
			var value = new
			{
				Value = (short)123
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = fixture.Object
				.GetSection(key)
				.GetValue<short>(nameof(value.Value));

			result
				.Should()
				.Be(value.Value);
		}

		[Fact]
		public void SetupClassWithShortBrackets()
		{
			const string key = nameof(key);
			var value = new
			{
				Value = (short)123
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = short.Parse(
				fixture.Object.GetSection(key)[nameof(value.Value)]);

			result
				.Should()
				.Be(value.Value);
		}

		[Fact]
		public void SetupClassWithShortBracketsFull()
		{
			const string key = nameof(key);
			var value = new
			{
				Value = (short)123
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = short.Parse(
				fixture.Object[$"{key}:{nameof(value.Value)}"]);

			result
				.Should()
				.Be(value.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData((short)123)]
		public void SetupClassWithNullableShort(short? input)
		{
			const string key = nameof(key);
			var value = new
			{
				Value = input
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = fixture.Object
				.GetSection(key)
				.GetValue<short?>(nameof(value.Value));

			result
				.Should()
				.Be(value.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData((short)123)]
		public void SetupClassWithNullableShortBrackets(short? input)
		{
			const string key = nameof(key);
			var value = new
			{
				Value = input
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var stringResult = fixture.Object
				.GetSection(key)[nameof(value.Value)];

			var result = input switch
			{
				null => string.IsNullOrEmpty(stringResult) ? (short?)null : throw new Exception(),
				_ => short.Parse(stringResult)
			};

			result
				.Should()
				.Be(value.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData((short)123)]
		public void SetupClassWithNullableShortBracketsFull(short? input)
		{
			const string key = nameof(key);
			var value = new
			{
				Value = input
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var stringResult = fixture.Object[$"{key}:{nameof(value.Value)}"];

			var result = input switch
			{
				null => string.IsNullOrEmpty(stringResult) ? (short?)null : throw new Exception(),
				_ => short.Parse(stringResult)
			};

			result
				.Should()
				.Be(value.Value);
		}

		[Fact]
		public void SetupClassWithUshort()
		{
			const string key = nameof(key);
			var value = new
			{
				Value = (ushort)123
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = fixture.Object
				.GetSection(key)
				.GetValue<ushort>(nameof(value.Value));

			result
				.Should()
				.Be(value.Value);
		}

		[Fact]
		public void SetupClassWithUshortBrackets()
		{
			const string key = nameof(key);
			var value = new
			{
				Value = (ushort)123
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = ushort.Parse(
				fixture.Object.GetSection(key)[nameof(value.Value)]);

			result
				.Should()
				.Be(value.Value);
		}

		[Fact]
		public void SetupClassWithUshortBracketsFull()
		{
			const string key = nameof(key);
			var value = new
			{
				Value = (ushort)123
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = ushort.Parse(
				fixture.Object[$"{key}:{nameof(value.Value)}"]);

			result
				.Should()
				.Be(value.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData((ushort)123)]
		public void SetupClassWithNullableUshort(ushort? input)
		{
			const string key = nameof(key);
			var value = new
			{
				Value = input
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = fixture.Object
				.GetSection(key)
				.GetValue<ushort?>(nameof(value.Value));

			result
				.Should()
				.Be(value.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData((ushort)123)]
		public void SetupClassWithNullableUshortBrackets(ushort? input)
		{
			const string key = nameof(key);
			var value = new
			{
				Value = input
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var stringResult = fixture.Object
				.GetSection(key)[nameof(value.Value)];

			var result = input switch
			{
				null => string.IsNullOrEmpty(stringResult) ? (ushort?)null : throw new Exception(),
				_ => ushort.Parse(stringResult)
			};

			result
				.Should()
				.Be(value.Value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData((ushort)123)]
		public void SetupClassWithNullableUshortBracketsFull(ushort? input)
		{
			const string key = nameof(key);
			var value = new
			{
				Value = input
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var stringResult = fixture.Object[$"{key}:{nameof(value.Value)}"];

			var result = input switch
			{
				null => string.IsNullOrEmpty(stringResult) ? (ushort?)null : throw new Exception(),
				_ => ushort.Parse(stringResult)
			};

			result
				.Should()
				.Be(value.Value);
		}
	}
}

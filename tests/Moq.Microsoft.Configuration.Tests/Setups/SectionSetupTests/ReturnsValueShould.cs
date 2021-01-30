using System;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Moq.Microsoft.Configuration.Tests.Setups.SectionSetupTests
{
	public sealed class ReturnsValueShould : MockTestsBase
	{
		[Fact]
		public void ExistWithValue()
		{
			const string key = nameof(key), value = nameof(value);

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = fixture.Object
				.GetSection(key)
				.Exists();

			result
				.Should()
				.BeTrue();
		}

		[Fact]
		public void ExistWithProperties()
		{
			const string key = nameof(key);
			var value = new
			{
				StringValue = "string",
				IntValue = 123,
				BoolValue = true
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = fixture.Object
				.GetSection(key)
				.Exists();

			result
				.Should()
				.BeTrue();
		}

		[Fact]
		public void NotSetupIfObjectNull()
		{
			const string key = nameof(key);

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(null);

			var result = fixture.Object
				.GetSection(key)
				.Exists();

			result
				.Should()
				.BeFalse();
		}

		[Fact]
		public void SetupChar()
		{
			const string key = nameof(key);
			const char value = '日';

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = fixture.Object
				.GetValue<char>(key);

			result
				.Should()
				.Be(value);
		}

		[Fact]
		public void SetupCharBrackets()
		{
			const string key = nameof(key);
			const char value = '日';

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = fixture.Object[key][0];

			result
				.Should()
				.Be(value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData('日')]
		public void SetupNullableChar(char? value)
		{
			const string key = nameof(key);

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = fixture.Object
				.GetValue<char?>(key);

			result
				.Should()
				.Be(value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData('日')]
		public void SetupNullableCharBrackets(char? value)
		{
			const string key = nameof(key);

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = value switch
			{
				null => fixture.Object[key] == null ? (char?)null : throw new Exception(),
				_ => fixture.Object[key][0]
			};

			result
				.Should()
				.Be(value);
		}

		[Fact]
		public void SetupInt()
		{
			const string key = nameof(key);
			const int value = 123;

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = fixture.Object
				.GetValue<int>(key);

			result
				.Should()
				.Be(value);
		}

		[Fact]
		public void SetupIntBrackets()
		{
			const string key = nameof(key);
			const int value = 123;

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = int.Parse(fixture.Object[key]);

			result
				.Should()
				.Be(value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(123)]
		public void SetupNullableInt(int? value)
		{
			const string key = nameof(key);

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = fixture.Object
				.GetValue<int?>(key);

			result
				.Should()
				.Be(value);
		}
		
		[Theory]
		[InlineData(null)]
		[InlineData(123)]
		public void SetupNullableIntBrackets(int? value)
		{
			const string key = nameof(key);

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = value switch
			{
				null => fixture.Object[key] == null ? (int?)null : throw new Exception(),
				_ => int.Parse(fixture.Object[key])
			};

			result
				.Should()
				.Be(value);
		}

		[Fact]
		public void SetupUint()
		{
			const string key = nameof(key);
			const uint value = 123;

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = fixture.Object
				.GetValue<uint>(key);

			result
				.Should()
				.Be(value);
		}

		[Fact]
		public void SetupUintBrackets()
		{
			const string key = nameof(key);
			const uint value = 123;

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = uint.Parse(fixture.Object[key]);

			result
				.Should()
				.Be(value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(123u)]
		public void SetupNullableUint(uint? value)
		{
			const string key = nameof(key);

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = fixture.Object
				.GetValue<uint?>(key);

			result
				.Should()
				.Be(value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(123u)]
		public void SetupNullableUintBrackets(uint? value)
		{
			const string key = nameof(key);

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = value switch
			{
				null => fixture.Object[key] == null ? (uint?)null : throw new Exception(),
				_ => uint.Parse(fixture.Object[key])
			};

			result
				.Should()
				.Be(value);
		}

		[Fact]
		public void SetupByte()
		{
			const string key = nameof(key);
			const byte value = 123;

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = fixture.Object
				.GetValue<byte>(key);

			result
				.Should()
				.Be(value);
		}

		[Fact]
		public void SetupByteBrackets()
		{
			const string key = nameof(key);
			const byte value = 123;

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = byte.Parse(fixture.Object[key]);

			result
				.Should()
				.Be(value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData((byte)123)]
		public void SetupNullableByte(byte? value)
		{
			const string key = nameof(key);

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = fixture.Object
				.GetValue<byte?>(key);

			result
				.Should()
				.Be(value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData((byte)123)]
		public void SetupNullableByteBrackets(byte? value)
		{
			const string key = nameof(key);

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = value switch
			{
				null => fixture.Object[key] == null ? (byte?)null : throw new Exception(),
				_ => byte.Parse(fixture.Object[key])
			};

			result
				.Should()
				.Be(value);
		}

		[Fact]
		public void SetupSbyte()
		{
			const string key = nameof(key);
			const sbyte value = 123;

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = fixture.Object
				.GetValue<sbyte>(key);

			result
				.Should()
				.Be(value);
		}

		[Fact]
		public void SetupSbyteBrackets()
		{
			const string key = nameof(key);
			const sbyte value = 123;

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = sbyte.Parse(fixture.Object[key]);

			result
				.Should()
				.Be(value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData((sbyte)123)]
		public void SetupNullableSbyte(sbyte? value)
		{
			const string key = nameof(key);

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = fixture.Object
				.GetValue<sbyte?>(key);

			result
				.Should()
				.Be(value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData((sbyte)123)]
		public void SetupNullableSbyteBrackets(sbyte? value)
		{
			const string key = nameof(key);

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = value switch
			{
				null => fixture.Object[key] == null ? (sbyte?)null : throw new Exception(),
				_ => sbyte.Parse(fixture.Object[key])
			};

			result
				.Should()
				.Be(value);
		}

		[Fact]
		public void SetupShort()
		{
			const string key = nameof(key);
			const short value = 123;

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = fixture.Object
				.GetValue<short>(key);

			result
				.Should()
				.Be(value);
		}

		[Fact]
		public void SetupShortBrackets()
		{
			const string key = nameof(key);
			const short value = 123;

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = short.Parse(fixture.Object[key]);

			result
				.Should()
				.Be(value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData((short)123)]
		public void SetupNullableShort(short? value)
		{
			const string key = nameof(key);

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = fixture.Object
				.GetValue<short?>(key);

			result
				.Should()
				.Be(value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData((short)123)]
		public void SetupNullableShortBrackets(short? value)
		{
			const string key = nameof(key);

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = value switch
			{
				null => fixture.Object[key] == null ? (short?)null : throw new Exception(),
				_ => short.Parse(fixture.Object[key])
			};

			result
				.Should()
				.Be(value);
		}

		[Fact]
		public void SetupUshort()
		{
			const string key = nameof(key);
			const ushort value = 123;

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = fixture.Object
				.GetValue<ushort>(key);

			result
				.Should()
				.Be(value);
		}

		[Fact]
		public void SetupUshortBrackets()
		{
			const string key = nameof(key);
			const ushort value = 123;

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = ushort.Parse(fixture.Object[key]);

			result
				.Should()
				.Be(value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData((ushort)123)]
		public void SetupNullableUshort(ushort? value)
		{
			const string key = nameof(key);

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = fixture.Object
				.GetValue<ushort?>(key);

			result
				.Should()
				.Be(value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData((ushort)123)]
		public void SetupNullableUshortBrackets(ushort? value)
		{
			const string key = nameof(key);

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = value switch
			{
				null => fixture.Object[key] == null ? (ushort?)null : throw new Exception(),
				_ => ushort.Parse(fixture.Object[key])
			};

			result
				.Should()
				.Be(value);
		}

		[Fact]
		public void SetupLong()
		{
			const string key = nameof(key);
			const long value = 123L;

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = fixture.Object
				.GetValue<long>(key);

			result
				.Should()
				.Be(value);
		}

		[Fact]
		public void SetupLongBrackets()
		{
			const string key = nameof(key);
			const long value = 123L;

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = long.Parse(fixture.Object[key]);

			result
				.Should()
				.Be(value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(123L)]
		public void SetupNullableLong(long? value)
		{
			const string key = nameof(key);

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = fixture.Object
				.GetValue<long?>(key);

			result
				.Should()
				.Be(value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(123L)]
		public void SetupNullableLongBrackets(long? value)
		{
			const string key = nameof(key);

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = value switch
			{
				null => fixture.Object[key] == null ? (long?)null : throw new Exception(),
				_ => long.Parse(fixture.Object[key])
			};

			result
				.Should()
				.Be(value);
		}

		[Fact]
		public void SetupUlong()
		{
			const string key = nameof(key);
			const ulong value = 123UL;

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = fixture.Object
				.GetValue<ulong>(key);

			result
				.Should()
				.Be(value);
		}

		[Fact]
		public void SetupUlongBrackets()
		{
			const string key = nameof(key);
			const ulong value = 123UL;

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = ulong.Parse(fixture.Object[key]);

			result
				.Should()
				.Be(value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(123UL)]
		public void SetupNullableUlong(ulong? value)
		{
			const string key = nameof(key);

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = fixture.Object
				.GetValue<ulong?>(key);

			result
				.Should()
				.Be(value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(123UL)]
		public void SetupNullableUlongBrackets(ulong? value)
		{
			const string key = nameof(key);

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = value switch
			{
				null => fixture.Object[key] == null ? (ulong?)null : throw new Exception(),
				_ => ulong.Parse(fixture.Object[key])
			};

			result
				.Should()
				.Be(value);
		}

		[Fact]
		public void SetupDecimal()
		{
			const string key = nameof(key);
			const decimal value = 123m;

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = fixture.Object
				.GetValue<decimal>(key);

			result
				.Should()
				.Be(value);
		}

		[Fact]
		public void SetupDecimalBrackets()
		{
			const string key = nameof(key);
			const decimal value = 123m;

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = decimal.Parse(fixture.Object[key]);

			result
				.Should()
				.Be(value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(123)]
		public void SetupNullableDecimal(int? intValue)
		{
			const string key = nameof(key);
			decimal? value = intValue switch
			{
				null => null,
				not null => Convert.ToDecimal(intValue)
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = fixture.Object
				.GetValue<decimal?>(key);

			result
				.Should()
				.Be(value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(123)]
		public void SetupNullableDecimalBrackets(int? intValue)
		{
			const string key = nameof(key);
			decimal? value = intValue switch
			{
				null => null,
				not null => Convert.ToDecimal(intValue)
			};

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = value switch
			{
				null => fixture.Object[key] == null ? (decimal?)null : throw new Exception(),
				_ => decimal.Parse(fixture.Object[key])
			};

			result
				.Should()
				.Be(value);
		}

		[Fact]
		public void SetupDouble()
		{
			const string key = nameof(key);
			const double value = 123d;

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = fixture.Object
				.GetValue<double>(key);

			result
				.Should()
				.Be(value);
		}

		[Fact]
		public void SetupDoubleBrackets()
		{
			const string key = nameof(key);
			const double value = 123d;

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = double.Parse(fixture.Object[key]);

			result
				.Should()
				.Be(value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(123d)]
		public void SetupNullableDouble(double? value)
		{
			const string key = nameof(key);

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = fixture.Object
				.GetValue<double?>(key);

			result
				.Should()
				.Be(value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(123d)]
		public void SetupNullableDoubleBrackets(double? value)
		{
			const string key = nameof(key);

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = value switch
			{
				null => fixture.Object[key] == null ? (double?)null : throw new Exception(),
				_ => double.Parse(fixture.Object[key])
			};

			result
				.Should()
				.Be(value);
		}

		[Fact]
		public void SetupFloat()
		{
			const string key = nameof(key);
			const float value = 123f;

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = fixture.Object
				.GetValue<float>(key);

			result
				.Should()
				.Be(value);
		}

		[Fact]
		public void SetupFloatBrackets()
		{
			const string key = nameof(key);
			const float value = 123f;

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = float.Parse(fixture.Object[key]);

			result
				.Should()
				.Be(value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(123f)]
		public void SetupNullableFloat(float? value)
		{
			const string key = nameof(key);

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = fixture.Object
				.GetValue<float?>(key);

			result
				.Should()
				.Be(value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData(123f)]
		public void SetupNullableFloatBrackets(float? value)
		{
			const string key = nameof(key);

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = value switch
			{
				null => fixture.Object[key] == null ? (float?)null : throw new Exception(),
				_ => float.Parse(fixture.Object[key])
			};

			result
				.Should()
				.Be(value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("value")]
		public void SetupString(string value)
		{
			const string key = nameof(key);

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = fixture.Object
				.GetValue<string>(key);

			result
				.Should()
				.Be(value);
		}

		[Theory]
		[InlineData(null)]
		[InlineData("value")]
		public void SetupStringBrackets(string value)
		{
			const string key = nameof(key);

			var fixture = CreateClass();

			fixture
				.SetupSection(key)
				.Returns(value);

			var result = fixture.Object[key];

			result
				.Should()
				.Be(value);
		}
	}
}

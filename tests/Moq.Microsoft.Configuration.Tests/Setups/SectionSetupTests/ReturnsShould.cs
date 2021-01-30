using System;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Moq.Microsoft.Configuration.Tests.Setups.SectionSetupTests
{
	public sealed class ReturnsShould : MockTestsBase
	{
		[Fact]
		public void ExistWithValue()
		{
			const string key = nameof(key), value = nameof(value);

			var fixture = CreateClass();

			fixture
				.SetupSection<string>(key)
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
				.SetupSection<dynamic>(key)
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
				.SetupSection<dynamic>(key)
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
				.SetupSection<char>(key)
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
				.SetupSection<char>(key)
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
				.SetupSection<char?>(key)
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
				.SetupSection<char?>(key)
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
				.SetupSection<int>(key)
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
				.SetupSection<int>(key)
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
				.SetupSection<int?>(key)
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
				.SetupSection<int?>(key)
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
				.SetupSection<uint>(key)
				.Returns(value);

			var result = fixture.Object
				.GetValue<uint>(key);

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
				.SetupSection<uint?>(key)
				.Returns(value);

			var result = fixture.Object
				.GetValue<uint?>(key);

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
				.SetupSection<byte>(key)
				.Returns(value);

			var result = fixture.Object
				.GetValue<byte>(key);

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
				.SetupSection<byte?>(key)
				.Returns(value);

			var result = fixture.Object
				.GetValue<byte?>(key);

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
				.SetupSection<sbyte>(key)
				.Returns(value);

			var result = fixture.Object
				.GetValue<sbyte>(key);

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
				.SetupSection<sbyte?>(key)
				.Returns(value);

			var result = fixture.Object
				.GetValue<sbyte?>(key);

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
				.SetupSection<short>(key)
				.Returns(value);

			var result = fixture.Object
				.GetValue<short>(key);

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
				.SetupSection<short?>(key)
				.Returns(value);

			var result = fixture.Object
				.GetValue<short?>(key);

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
				.SetupSection<ushort>(key)
				.Returns(value);

			var result = fixture.Object
				.GetValue<ushort>(key);

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
				.SetupSection<ushort?>(key)
				.Returns(value);

			var result = fixture.Object
				.GetValue<ushort?>(key);

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
				.SetupSection<long>(key)
				.Returns(value);

			var result = fixture.Object
				.GetValue<long>(key);

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
				.SetupSection<long?>(key)
				.Returns(value);

			var result = fixture.Object
				.GetValue<long?>(key);

			result
				.Should()
				.Be(value);
		}

		[Fact]
		public void SetupUlong()
		{
			const string key = nameof(key);
			const ulong value = 123;

			var fixture = CreateClass();

			fixture
				.SetupSection<ulong>(key)
				.Returns(value);

			var result = fixture.Object
				.GetValue<ulong>(key);

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
				.SetupSection<ulong?>(key)
				.Returns(value);

			var result = fixture.Object
				.GetValue<ulong?>(key);

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
				.SetupSection<decimal>(key)
				.Returns(value);

			var result = fixture.Object
				.GetValue<decimal>(key);

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
				.SetupSection<decimal?>(key)
				.Returns(value);

			var result = fixture.Object
				.GetValue<decimal?>(key);

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
				.SetupSection<double>(key)
				.Returns(value);

			var result = fixture.Object
				.GetValue<double>(key);

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
				.SetupSection<double?>(key)
				.Returns(value);

			var result = fixture.Object
				.GetValue<double?>(key);

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
				.SetupSection<float>(key)
				.Returns(value);

			var result = fixture.Object
				.GetValue<float>(key);

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
				.SetupSection<float?>(key)
				.Returns(value);

			var result = fixture.Object
				.GetValue<float?>(key);

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
				.SetupSection<string>(key)
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
		public void SetupClassWithString(string input)
		{
			const string key = nameof(key);
			var value = new
			{
				Value = input
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var result = fixture.Object
				.GetSection(key)
				.GetValue<string>(nameof(value.Value));
			
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
				.SetupSection<dynamic>(key)
				.Returns(value);

			var result = fixture.Object
				.GetSection(key)
				.GetValue<bool>(nameof(value.Value));

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
				.SetupSection<dynamic>(key)
				.Returns(value);

			var result = fixture.Object
				.GetSection(key)
				.GetValue<bool?>(nameof(value.Value));

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
				.SetupSection<dynamic>(key)
				.Returns(value);

			var result = fixture.Object
				.GetSection(key)
				.GetValue<byte>(nameof(value.Value));

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
				.SetupSection<dynamic>(key)
				.Returns(value);

			var result = fixture.Object
				.GetSection(key)
				.GetValue<byte?>(nameof(value.Value));

			result
				.Should()
				.Be(value.Value);
		}

		[Fact]
		public void SetupClassWithsbyte()
		{
			const string key = nameof(key);
			var value = new
			{
				Value = (sbyte)123
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var result = fixture.Object
				.GetSection(key)
				.GetValue<sbyte>(nameof(value.Value));

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
				.SetupSection<dynamic>(key)
				.Returns(value);

			var result = fixture.Object
				.GetSection(key)
				.GetValue<sbyte?>(nameof(value.Value));

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
				.SetupSection<dynamic>(key)
				.Returns(value);

			var result = fixture.Object
				.GetSection(key)
				.GetValue<char>(nameof(value.Value));

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
				.SetupSection<dynamic>(key)
				.Returns(value);

			var result = fixture.Object
				.GetSection(key)
				.GetValue<char?>(nameof(value.Value));

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
				.SetupSection<dynamic>(key)
				.Returns(value);

			var result = fixture.Object
				.GetSection(key)
				.GetValue<decimal>(nameof(value.Value));

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
				.SetupSection<dynamic>(key)
				.Returns(value);

			var result = fixture.Object
				.GetSection(key)
				.GetValue<decimal?>(nameof(value.Value));

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
				.SetupSection<dynamic>(key)
				.Returns(value);

			var result = fixture.Object
				.GetSection(key)
				.GetValue<double>(nameof(value.Value));

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
				.SetupSection<dynamic>(key)
				.Returns(value);

			var result = fixture.Object
				.GetSection(key)
				.GetValue<double?>(nameof(value.Value));

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
				.SetupSection<dynamic>(key)
				.Returns(value);

			var result = fixture.Object
				.GetSection(key)
				.GetValue<float>(nameof(value.Value));

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
				.SetupSection<dynamic>(key)
				.Returns(value);

			var result = fixture.Object
				.GetSection(key)
				.GetValue<float?>(nameof(value.Value));

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
				.SetupSection<dynamic>(key)
				.Returns(value);

			var result = fixture.Object
				.GetSection(key)
				.GetValue<int>(nameof(value.Value));

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
				.SetupSection<dynamic>(key)
				.Returns(value);

			var result = fixture.Object
				.GetSection(key)
				.GetValue<int?>(nameof(value.Value));

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
				.SetupSection<dynamic>(key)
				.Returns(value);

			var result = fixture.Object
				.GetSection(key)
				.GetValue<uint>(nameof(value.Value));

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
				.SetupSection<dynamic>(key)
				.Returns(value);

			var result = fixture.Object
				.GetSection(key)
				.GetValue<uint?>(nameof(value.Value));

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
				.SetupSection<dynamic>(key)
				.Returns(value);

			var result = fixture.Object
				.GetSection(key)
				.GetValue<long>(nameof(value.Value));

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
				.SetupSection<dynamic>(key)
				.Returns(value);

			var result = fixture.Object
				.GetSection(key)
				.GetValue<long?>(nameof(value.Value));

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
				.SetupSection<dynamic>(key)
				.Returns(value);

			var result = fixture.Object
				.GetSection(key)
				.GetValue<ulong>(nameof(value.Value));

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
				.SetupSection<dynamic>(key)
				.Returns(value);

			var result = fixture.Object
				.GetSection(key)
				.GetValue<ulong?>(nameof(value.Value));

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
				.SetupSection<dynamic>(key)
				.Returns(value);

			var result = fixture.Object
				.GetSection(key)
				.GetValue<short>(nameof(value.Value));

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
				.SetupSection<dynamic>(key)
				.Returns(value);

			var result = fixture.Object
				.GetSection(key)
				.GetValue<short?>(nameof(value.Value));

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
				.SetupSection<dynamic>(key)
				.Returns(value);

			var result = fixture.Object
				.GetSection(key)
				.GetValue<ushort>(nameof(value.Value));

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
				.SetupSection<dynamic>(key)
				.Returns(value);

			var result = fixture.Object
				.GetSection(key)
				.GetValue<ushort?>(nameof(value.Value));

			result
				.Should()
				.Be(value.Value);
		}

		[Fact]
		public void SetupClassWithBoolArrays()
		{
			const string key = nameof(key);
			var value = new
			{
				Bools = new[] { true, false }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			var result = section
				.GetSection(nameof(value.Bools))
				.Get<bool[]>();

			result
				.Should()
				.BeEquivalentTo(value.Bools);
		}

		[Fact]
		public void SetupClassWithNullableBoolArrays()
		{
			const string key = nameof(key);
			var value = new
			{
				Bools = new bool?[] { true, false, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			var result = section
				.GetSection(nameof(value.Bools))
				.Get<bool?[]>();

			result
				.Should()
				.BeEquivalentTo(value.Bools);
		}

		[Fact]
		public void SetupClassWithByteArrays()
		{
			const string key = nameof(key);
			var value = new
			{
				Bytes = new byte[] { 1, 2 }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			var result = section
				.GetSection(nameof(value.Bytes))
				.Get<byte[]>();

			result
				.Should()
				.BeEquivalentTo(value.Bytes);
		}

		[Fact]
		public void SetupClassWithNullableByteArrays()
		{
			const string key = nameof(key);
			var value = new
			{
				Bytes = new byte?[] { 1, 2, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			var result = section
				.GetSection(nameof(value.Bytes))
				.Get<byte?[]>();

			result
				.Should()
				.BeEquivalentTo(value.Bytes);
		}

		[Fact]
		public void SetupClassWithSbyteArrays()
		{
			const string key = nameof(key);
			var value = new
			{
				Sbytes = new sbyte[] { 1, 2 }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			var result = section
				.GetSection(nameof(value.Sbytes))
				.Get<sbyte[]>();

			result
				.Should()
				.BeEquivalentTo(value.Sbytes);
		}

		[Fact]
		public void SetupClassWithNullableSbyteArrays()
		{
			const string key = nameof(key);
			var value = new
			{
				Sbytes = new sbyte?[] { 1, 2 }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			var result = section
				.GetSection(nameof(value.Sbytes))
				.Get<sbyte?[]>();

			result
				.Should()
				.BeEquivalentTo(value.Sbytes);
		}

		[Fact]
		public void SetupClassWithCharArrays()
		{
			const string key = nameof(key);
			var value = new
			{
				Chars = new[] { '日', '本' }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			var result = section
				.GetSection(nameof(value.Chars))
				.Get<char[]>();

			result
				.Should()
				.BeEquivalentTo(value.Chars);
		}

		[Fact]
		public void SetupClassWithNullableCharArrays()
		{
			const string key = nameof(key);
			var value = new
			{
				Chars = new char?[] { '日', '本', null }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			var result = section
				.GetSection(nameof(value.Chars))
				.Get<char?[]>();

			result
				.Should()
				.BeEquivalentTo(value.Chars);
		}

		[Fact]
		public void SetupClassWithDecimalArrays()
		{
			const string key = nameof(key);
			var value = new
			{
				Decimals = new[] { 1.3m, 2.45m }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			var result = section
				.GetSection(nameof(value.Decimals))
				.Get<decimal[]>();

			result
				.Should()
				.BeEquivalentTo(value.Decimals);
		}

		[Fact]
		public void SetupClassWithNullableDecimalArrays()
		{
			const string key = nameof(key);
			var value = new
			{
				Decimals = new decimal?[] { 1.3m, 2.45m, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			var result = section
				.GetSection(nameof(value.Decimals))
				.Get<decimal?[]>();

			result
				.Should()
				.BeEquivalentTo(value.Decimals);
		}

		[Fact]
		public void SetupClassWithDoubleArrays()
		{
			const string key = nameof(key);
			var value = new
			{
				Doubles = new[] { 1.2d, 2.33d }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			var result = section
				.GetSection(nameof(value.Doubles))
				.Get<double[]>();

			result
				.Should()
				.BeEquivalentTo(value.Doubles);
		}

		[Fact]
		public void SetupClassWithNullableDoubleArrays()
		{
			const string key = nameof(key);
			var value = new
			{
				Doubles = new double?[] { 1.2d, 2.33d, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			var result = section
				.GetSection(nameof(value.Doubles))
				.Get<double?[]>();

			result
				.Should()
				.BeEquivalentTo(value.Doubles);
		}

		[Fact]
		public void SetupClassWithFloatArrays()
		{
			const string key = nameof(key);
			var value = new
			{
				Floats = new[] { 1.2f, 2.33f }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			var result = section
				.GetSection(nameof(value.Floats))
				.Get<float[]>();

			result
				.Should()
				.BeEquivalentTo(value.Floats);
		}

		[Fact]
		public void SetupClassWithNullableFloatArrays()
		{
			const string key = nameof(key);
			var value = new
			{
				Floats = new float?[] { 1.2f, 2.33f, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			var result = section
				.GetSection(nameof(value.Floats))
				.Get<float?[]>();

			result
				.Should()
				.BeEquivalentTo(value.Floats);
		}

		[Fact]
		public void SetupClassWithIntArrays()
		{
			const string key = nameof(key);
			var value = new
			{
				Ints = new[] { 1, 2 }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			var result = section
				.GetSection(nameof(value.Ints))
				.Get<int[]>();

			result
				.Should()
				.BeEquivalentTo(value.Ints);
		}

		[Fact]
		public void SetupClassWithNullableIntArrays()
		{
			const string key = nameof(key);
			var value = new
			{
				Ints = new int?[] { 1, 2, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			var result = section
				.GetSection(nameof(value.Ints))
				.Get<int?[]>();

			result
				.Should()
				.BeEquivalentTo(value.Ints);
		}

		[Fact]
		public void SetupClassWithUintArrays()
		{
			const string key = nameof(key);
			var value = new
			{
				Uints = new[] { 1u, 2u }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			var result = section
				.GetSection(nameof(value.Uints))
				.Get<uint[]>();

			result
				.Should()
				.BeEquivalentTo(value.Uints);
		}

		[Fact]
		public void SetupClassWithNullableUintArrays()
		{
			const string key = nameof(key);
			var value = new
			{
				Uints = new uint?[] { 1u, 2u, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			var result = section
				.GetSection(nameof(value.Uints))
				.Get<uint?[]>();

			result
				.Should()
				.BeEquivalentTo(value.Uints);
		}

		[Fact]
		public void SetupClassWithLongArrays()
		{
			const string key = nameof(key);
			var value = new
			{
				Longs = new[] { 1L, 2L }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			var result = section
				.GetSection(nameof(value.Longs))
				.Get<long[]>();

			result
				.Should()
				.BeEquivalentTo(value.Longs);
		}

		[Fact]
		public void SetupClassWithNullableLongArrays()
		{
			const string key = nameof(key);
			var value = new
			{
				Longs = new long?[] { 1L, 2L, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			var result = section
				.GetSection(nameof(value.Longs))
				.Get<long?[]>();

			result
				.Should()
				.BeEquivalentTo(value.Longs);
		}

		[Fact]
		public void SetupClassWithUlongArrays()
		{
			const string key = nameof(key);
			var value = new
			{
				Ulongs = new[] { 1UL, 2UL }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			var result = section
				.GetSection(nameof(value.Ulongs))
				.Get<ulong[]>();

			result
				.Should()
				.BeEquivalentTo(value.Ulongs);
		}
		
		[Fact]
		public void SetupClassWithNullableUlongArrays()
		{
			const string key = nameof(key);
			var value = new
			{
				Ulongs = new ulong?[] { 1UL, 2UL, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			var result = section
				.GetSection(nameof(value.Ulongs))
				.Get<ulong?[]>();

			result
				.Should()
				.BeEquivalentTo(value.Ulongs);
		}

		[Fact]
		public void SetupClassWithShortArrays()
		{
			const string key = nameof(key);
			var value = new
			{
				Shorts = new short[] { 1, 2 }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			var result = section
				.GetSection(nameof(value.Shorts))
				.Get<short[]>();

			result
				.Should()
				.BeEquivalentTo(value.Shorts);
		}

		[Fact]
		public void SetupClassWithNullableShortArrays()
		{
			const string key = nameof(key);
			var value = new
			{
				Shorts = new short?[] { 1, 2, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			var result = section
				.GetSection(nameof(value.Shorts))
				.Get<short?[]>();

			result
				.Should()
				.BeEquivalentTo(value.Shorts);
		}

		[Fact]
		public void SetupClassWithUshortArrays()
		{
			const string key = nameof(key);
			var value = new
			{
				Ushorts = new ushort[] { 1, 2 }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			var result = section
				.GetSection(nameof(value.Ushorts))
				.Get<ushort[]>();

			result
				.Should()
				.BeEquivalentTo(value.Ushorts);
		}

		[Fact]
		public void SetupClassWithNullableUshortArrays()
		{
			const string key = nameof(key);
			var value = new
			{
				Ushorts = new ushort?[] { 1, 2, null }
			};

			var fixture = CreateClass();

			fixture
				.SetupSection<dynamic>(key)
				.Returns(value);

			var section = fixture.Object
				.GetSection(key);

			var result = section
				.GetSection(nameof(value.Ushorts))
				.Get<ushort?[]>();

			result
				.Should()
				.BeEquivalentTo(value.Ushorts);
		}
	}
}

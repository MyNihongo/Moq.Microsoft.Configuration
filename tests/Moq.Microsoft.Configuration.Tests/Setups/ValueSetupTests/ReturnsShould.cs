//using System;
//using FluentAssertions;
//using Microsoft.Extensions.Configuration;
//using Xunit;

//namespace Moq.Microsoft.Configuration.Tests.Setups.ValueSetupTests
//{
//	public sealed class ReturnsShould : MockTestsBase
//	{
//		[Fact]
//		public void Exist()
//		{

//			const string key = nameof(key), value = nameof(value);

//			var fixture = CreateClass();

//			fixture
//				.SetupValue<string>(key)
//				.Returns(value);

//			var result = fixture.Object
//				.GetSection(key)
//				.Exists();

//			result
//				.Should()
//				.BeTrue();
//		}

//		[Fact]
//		public void ReturnString()
//		{
//			const string key = nameof(key), value = nameof(value);

//			var fixture = CreateClass();

//			fixture
//				.SetupValue<string>(key)
//				.Returns(value);

//			var result = fixture.Object
//				.GetValue<string>(key);

//			result
//				.Should()
//				.Be(value);
//		}

//		[Fact]
//		public void ReturnStringBrackets()
//		{
//			const string key = nameof(key), value = nameof(value);

//			var fixture = CreateClass();

//			fixture
//				.SetupValue<string>(key)
//				.Returns(value);

//			var result = fixture.Object[key];

//			result
//				.Should()
//				.Be(value);
//		}

//		[Fact]
//		public void ReturnBool()
//		{
//			const string key = nameof(key);
//			const bool value = true;

//			var fixture = CreateClass();

//			fixture
//				.SetupValue<bool>(key)
//				.Returns(value);

//			var result = fixture.Object
//				.GetValue<bool>(key);

//			result
//				.Should()
//				.Be(value);
//		}

//		[Fact]
//		public void ReturnBoolBrackets()
//		{
//			const string key = nameof(key);
//			const bool value = true;

//			var fixture = CreateClass();

//			fixture
//				.SetupValue<bool>(key)
//				.Returns(value);

//			var result = bool.Parse(fixture.Object[key]);

//			result
//				.Should()
//				.Be(value);
//		}

//		[Theory]
//		[InlineData(null)]
//		[InlineData(true)]
//		public void ReturnNullableBool(bool? value)
//		{
//			const string key = nameof(key);

//			var fixture = CreateClass();

//			fixture
//				.SetupValue<bool?>(key)
//				.Returns(value);

//			var result = fixture.Object
//				.GetValue<bool?>(key);

//			result
//				.Should()
//				.Be(value);
//		}

//		[Theory]
//		[InlineData(null)]
//		[InlineData(true)]
//		public void ReturnNullableBoolBrackets(bool? value)
//		{
//			const string key = nameof(key);

//			var fixture = CreateClass();

//			fixture
//				.SetupValue<bool?>(key)
//				.Returns(value);

//			var result = value switch
//			{
//				null => fixture.Object[key] == null ? (bool?)null : throw new Exception(),
//				_ => bool.Parse(fixture.Object[key])
//			};

//			result
//				.Should()
//				.Be(value);
//		}

//		[Fact]
//		public void ReturnChar()
//		{
//			const string key = nameof(key);
//			const char value = '日';

//			var fixture = CreateClass();

//			fixture
//				.SetupValue<char>(key)
//				.Returns(value);

//			var result = fixture.Object
//				.GetValue<char>(key);

//			result
//				.Should()
//				.Be(value);
//		}

//		[Fact]
//		public void ReturnCharBrackets()
//		{
//			const string key = nameof(key);
//			const char value = '日';

//			var fixture = CreateClass();

//			fixture
//				.SetupValue<char>(key)
//				.Returns(value);

//			var result = fixture.Object[key][0];

//			result
//				.Should()
//				.Be(value);
//		}

//		[Theory]
//		[InlineData(null)]
//		[InlineData('日')]
//		public void ReturnNullableChar(char? value)
//		{
//			const string key = nameof(key);

//			var fixture = CreateClass();

//			fixture
//				.SetupValue<char?>(key)
//				.Returns(value);

//			var result = fixture.Object
//				.GetValue<char?>(key);

//			result
//				.Should()
//				.Be(value);
//		}

//		[Theory]
//		[InlineData(null)]
//		[InlineData('日')]
//		public void ReturnNullableCharBrackets(char? value)
//		{
//			const string key = nameof(key);

//			var fixture = CreateClass();

//			fixture
//				.SetupValue<char?>(key)
//				.Returns(value);

//			var result = value switch
//			{
//				null => fixture.Object[key] == null ? (char?)null : throw new Exception(),
//				_ => fixture.Object[key][0]
//			};

//			result
//				.Should()
//				.Be(value);
//		}

//		[Fact]
//		public void ReturnByte()
//		{
//			const string key = nameof(key);
//			const byte value = 1;

//			var fixture = CreateClass();

//			fixture
//				.SetupValue<byte>(key)
//				.Returns(value);

//			var result = fixture.Object
//				.GetValue<byte>(key);

//			result
//				.Should()
//				.Be(value);
//		}

//		[Fact]
//		public void ReturnByteBrackets()
//		{
//			const string key = nameof(key);
//			const byte value = 1;

//			var fixture = CreateClass();

//			fixture
//				.SetupValue<byte>(key)
//				.Returns(value);

//			var result = byte.Parse(fixture.Object[key]);

//			result
//				.Should()
//				.Be(value);
//		}

//		[Theory]
//		[InlineData(null)]
//		[InlineData((byte)1)]
//		public void ReturnNullableByte(byte? value)
//		{
//			const string key = nameof(key);

//			var fixture = CreateClass();

//			fixture
//				.SetupValue<byte?>(key)
//				.Returns(value);

//			var result = fixture.Object
//				.GetValue<byte?>(key);

//			result
//				.Should()
//				.Be(value);
//		}

//		[Theory]
//		[InlineData(null)]
//		[InlineData((byte)1)]
//		public void ReturnNullableByteBrackets(byte? value)
//		{
//			const string key = nameof(key);

//			var fixture = CreateClass();

//			fixture
//				.SetupValue<byte?>(key)
//				.Returns(value);

//			var result = value switch
//			{
//				null => fixture.Object[key] == null ? (byte?)null : throw new Exception(),
//				_ => byte.Parse(fixture.Object[key])
//			};

//			result
//				.Should()
//				.Be(value);
//		}

//		[Fact]
//		public void ReturnSbyte()
//		{
//			const string key = nameof(key);
//			const sbyte value = -1;

//			var fixture = CreateClass();

//			fixture
//				.SetupValue<sbyte>(key)
//				.Returns(value);

//			var result = fixture.Object
//				.GetValue<sbyte>(key);

//			result
//				.Should()
//				.Be(value);
//		}

//		[Fact]
//		public void ReturnSbyteBrackets()
//		{
//			const string key = nameof(key);
//			const sbyte value = -1;

//			var fixture = CreateClass();

//			fixture
//				.SetupValue<sbyte>(key)
//				.Returns(value);

//			var result = sbyte.Parse(fixture.Object[key]);

//			result
//				.Should()
//				.Be(value);
//		}

//		[Theory]
//		[InlineData(null)]
//		[InlineData((sbyte)-1)]
//		public void ReturnNullableSbyte(sbyte? value)
//		{
//			const string key = nameof(key);

//			var fixture = CreateClass();

//			fixture
//				.SetupValue<sbyte?>(key)
//				.Returns(value);

//			var result = fixture.Object
//				.GetValue<sbyte?>(key);

//			result
//				.Should()
//				.Be(value);
//		}

//		[Theory]
//		[InlineData(null)]
//		[InlineData((sbyte)-1)]
//		public void ReturnNullableSbyteBrackets(sbyte? value)
//		{
//			const string key = nameof(key);

//			var fixture = CreateClass();

//			fixture
//				.SetupValue<sbyte?>(key)
//				.Returns(value);

//			var result = value switch
//			{
//				null => fixture.Object[key] == null ? (sbyte?)null : throw new Exception(),
//				_ => sbyte.Parse(fixture.Object[key])
//			};

//			result
//				.Should()
//				.Be(value);
//		}

//		[Fact]
//		public void ReturnInt()
//		{
//			const string key = nameof(key);
//			const int value = 1_235;

//			var fixture = CreateClass();

//			fixture
//				.SetupValue<int>(key)
//				.Returns(value);

//			var result = fixture.Object
//				.GetValue<int>(key);

//			result
//				.Should()
//				.Be(value);
//		}

//		[Fact]
//		public void ReturnIntBrackets()
//		{
//			const string key = nameof(key);
//			const int value = 1_235;

//			var fixture = CreateClass();

//			fixture
//				.SetupValue<int>(key)
//				.Returns(value);

//			var result = int.Parse(fixture.Object[key]);

//			result
//				.Should()
//				.Be(value);
//		}

//		[Theory]
//		[InlineData(null)]
//		[InlineData(1_235)]
//		public void ReturnNullableInt(int? value)
//		{
//			const string key = nameof(key);

//			var fixture = CreateClass();

//			fixture
//				.SetupValue<int?>(key)
//				.Returns(value);

//			var result = fixture.Object
//				.GetValue<int?>(key);

//			result
//				.Should()
//				.Be(value);
//		}

//		[Theory]
//		[InlineData(null)]
//		[InlineData(1_235)]
//		public void ReturnNullableIntBrackets(int? value)
//		{
//			const string key = nameof(key);

//			var fixture = CreateClass();

//			fixture
//				.SetupValue<int?>(key)
//				.Returns(value);

//			var result = value switch
//			{
//				null => fixture.Object[key] == null ? (int?)null : throw new Exception(),
//				_ => int.Parse(fixture.Object[key])
//			};

//			result
//				.Should()
//				.Be(value);
//		}

//		[Fact]
//		public void ReturnUint()
//		{
//			const string key = nameof(key);
//			const uint value = 3_000_000_000u;

//			var fixture = CreateClass();

//			fixture
//				.SetupValue<uint>(key)
//				.Returns(value);

//			var result = fixture.Object
//				.GetValue<uint>(key);

//			result
//				.Should()
//				.Be(value);
//		}

//		[Fact]
//		public void ReturnUintBrackets()
//		{
//			const string key = nameof(key);
//			const uint value = 3_000_000_000u;

//			var fixture = CreateClass();

//			fixture
//				.SetupValue<uint>(key)
//				.Returns(value);

//			var result = uint.Parse(fixture.Object[key]);
					
//			result
//				.Should()
//				.Be(value);
//		}

//		[Theory]
//		[InlineData(null)]
//		[InlineData(3_000_000_000u)]
//		public void ReturnNullableUint(uint? value)
//		{
//			const string key = nameof(key);

//			var fixture = CreateClass();

//			fixture
//				.SetupValue<uint?>(key)
//				.Returns(value);

//			var result = fixture.Object
//				.GetValue<uint?>(key);

//			result
//				.Should()
//				.Be(value);
//		}

//		[Theory]
//		[InlineData(null)]
//		[InlineData(3_000_000_000u)]
//		public void ReturnNullableUintBrackets(uint? value)
//		{
//			const string key = nameof(key);

//			var fixture = CreateClass();

//			fixture
//				.SetupValue<uint?>(key)
//				.Returns(value);

//			var result = value switch
//			{
//				null => fixture.Object[key] == null ? (uint?)null : throw new Exception(),
//				_ => uint.Parse(fixture.Object[key])
//			};

//			result
//				.Should()
//				.Be(value);
//		}

//		[Fact]
//		public void ReturnLong()
//		{
//			const string key = nameof(key);
//			const long value = 6_000_000_000L;

//			var fixture = CreateClass();

//			fixture
//				.SetupValue<long>(key)
//				.Returns(value);

//			var result = fixture.Object
//				.GetValue<long>(key);

//			result
//				.Should()
//				.Be(value);
//		}

//		[Fact]
//		public void ReturnLongBrackets()
//		{
//			const string key = nameof(key);
//			const long value = 6_000_000_000L;

//			var fixture = CreateClass();

//			fixture
//				.SetupValue<long>(key)
//				.Returns(value);

//			var result = long.Parse(fixture.Object[key]);

//			result
//				.Should()
//				.Be(value);
//		}

//		[Theory]
//		[InlineData(null)]
//		[InlineData(6_000_000_000L)]
//		public void ReturnNullableLong(long? value)
//		{
//			const string key = nameof(key);

//			var fixture = CreateClass();

//			fixture
//				.SetupValue<long?>(key)
//				.Returns(value);

//			var result = fixture.Object
//				.GetValue<long?>(key);

//			result
//				.Should()
//				.Be(value);
//		}

//		[Theory]
//		[InlineData(null)]
//		[InlineData(6_000_000_000L)]
//		public void ReturnNullableLongBrackets(long? value)
//		{
//			const string key = nameof(key);

//			var fixture = CreateClass();

//			fixture
//				.SetupValue<long?>(key)
//				.Returns(value);

//			var result = value switch
//			{
//				null => fixture.Object[key] == null ? (long?)null : throw new Exception(),
//				_ => long.Parse(fixture.Object[key])
//			};

//			result
//				.Should()
//				.Be(value);
//		}

//		[Fact]
//		public void ReturnUlong()
//		{
//			const string key = nameof(key);
//			const ulong value = 18_000_000_000_000_000_000UL;

//			var fixture = CreateClass();

//			fixture
//				.SetupValue<ulong>(key)
//				.Returns(value);

//			var result = fixture.Object
//				.GetValue<ulong>(key);

//			result
//				.Should()
//				.Be(value);
//		}

//		[Fact]
//		public void ReturnUlongBrackets()
//		{
//			const string key = nameof(key);
//			const ulong value = 18_000_000_000_000_000_000UL;

//			var fixture = CreateClass();

//			fixture
//				.SetupValue<ulong>(key)
//				.Returns(value);

//			var result = ulong.Parse(fixture.Object[key]);

//			result
//				.Should()
//				.Be(value);
//		}

//		[Theory]
//		[InlineData(null)]
//		[InlineData(18_000_000_000_000_000_000UL)]
//		public void ReturnNullableUlong(ulong? value)
//		{
//			const string key = nameof(key);

//			var fixture = CreateClass();

//			fixture
//				.SetupValue<ulong?>(key)
//				.Returns(value);

//			var result = fixture.Object
//				.GetValue<ulong?>(key);

//			result
//				.Should()
//				.Be(value);
//		}

//		[Theory]
//		[InlineData(null)]
//		[InlineData(18_000_000_000_000_000_000UL)]
//		public void ReturnNullableUlongBrackets(ulong? value)
//		{
//			const string key = nameof(key);

//			var fixture = CreateClass();

//			fixture
//				.SetupValue<ulong?>(key)
//				.Returns(value);

//			var result = value switch
//			{
//				null => fixture.Object[key] == null ? (ulong?)null : throw new Exception(),
//				_ => ulong.Parse(fixture.Object[key])
//			};

//			result
//				.Should()
//				.Be(value);
//		}

//		[Fact]
//		public void ReturnShort()
//		{
//			const string key = nameof(key);
//			const short value = 30_000;

//			var fixture = CreateClass();

//			fixture
//				.SetupValue<short>(key)
//				.Returns(value);

//			var result = fixture.Object
//				.GetValue<short>(key);

//			result
//				.Should()
//				.Be(value);
//		}

//		[Fact]
//		public void ReturnShortBrackets()
//		{
//			const string key = nameof(key);
//			const short value = 30_000;

//			var fixture = CreateClass();

//			fixture
//				.SetupValue<short>(key)
//				.Returns(value);

//			var result = short.Parse(fixture.Object[key]);

//			result
//				.Should()
//				.Be(value);
//		}

//		[Theory]
//		[InlineData(null)]
//		[InlineData((short)30_000)]
//		public void ReturnNullableShort(short? value)
//		{
//			const string key = nameof(key);

//			var fixture = CreateClass();

//			fixture
//				.SetupValue<short?>(key)
//				.Returns(value);

//			var result = fixture.Object
//				.GetValue<short?>(key);

//			result
//				.Should()
//				.Be(value);
//		}

//		[Theory]
//		[InlineData(null)]
//		[InlineData((short)30_000)]
//		public void ReturnNullableShortBrackets(short? value)
//		{
//			const string key = nameof(key);

//			var fixture = CreateClass();

//			fixture
//				.SetupValue<short?>(key)
//				.Returns(value);

//			var result = value switch
//			{
//				null => fixture.Object[key] == null ? (short?)null : throw new Exception(),
//				_ => short.Parse(fixture.Object[key])
//			};

//			result
//				.Should()
//				.Be(value);
//		}

//		[Fact]
//		public void ReturnUshort()
//		{
//			const string key = nameof(key);
//			const ushort value = 60_000;

//			var fixture = CreateClass();

//			fixture
//				.SetupValue<ushort>(key)
//				.Returns(value);

//			var result = fixture.Object
//				.GetValue<ushort>(key);

//			result
//				.Should()
//				.Be(value);
//		}

//		[Fact]
//		public void ReturnUshortBrackets()
//		{
//			const string key = nameof(key);
//			const ushort value = 60_000;

//			var fixture = CreateClass();

//			fixture
//				.SetupValue<ushort>(key)
//				.Returns(value);

//			var result = ushort.Parse(fixture.Object[key]);

//			result
//				.Should()
//				.Be(value);
//		}

//		[Theory]
//		[InlineData(null)]
//		[InlineData((ushort)60_000)]
//		public void ReturnNullableUshort(ushort? value)
//		{
//			const string key = nameof(key);

//			var fixture = CreateClass();

//			fixture
//				.SetupValue<ushort?>(key)
//				.Returns(value);

//			var result = fixture.Object
//				.GetValue<ushort?>(key);

//			result
//				.Should()
//				.Be(value);
//		}

//		[Theory]
//		[InlineData(null)]
//		[InlineData((ushort)60_000)]
//		public void ReturnNullableUshortBrackets(ushort? value)
//		{
//			const string key = nameof(key);

//			var fixture = CreateClass();

//			fixture
//				.SetupValue<ushort?>(key)
//				.Returns(value);

//			var result = value switch
//			{
//				null => fixture.Object[key] == null ? (ushort?)null : throw new Exception(),
//				_ => ushort.Parse(fixture.Object[key])
//			};

//			result
//				.Should()
//				.Be(value);
//		}

//		[Fact]
//		public void ReturnDecimal()
//		{
//			const string key = nameof(key);
//			const decimal value = 12.345m;

//			var fixture = CreateClass();

//			fixture
//				.SetupValue<decimal>(key)
//				.Returns(value);

//			var result = fixture.Object
//				.GetValue<decimal>(key);

//			result
//				.Should()
//				.Be(value);
//		}

//		[Fact]
//		public void ReturnDecimalBrackets()
//		{
//			const string key = nameof(key);
//			const decimal value = 12.345m;

//			var fixture = CreateClass();

//			fixture
//				.SetupValue<decimal>(key)
//				.Returns(value);

//			var result = decimal.Parse(fixture.Object[key]);

//			result
//				.Should()
//				.Be(value);
//		}

//		[Theory]
//		[InlineData(null)]
//		[InlineData(12.345d)]
//		public void ReturnNullableDecimal(double? doubleValue)
//		{
//			const string key = nameof(key);
//			decimal? value = doubleValue switch
//			{
//				null => null,
//				not null => Convert.ToDecimal(doubleValue)
//			};

//			var fixture = CreateClass();

//			fixture
//				.SetupValue<decimal?>(key)
//				.Returns(value);

//			var result = fixture.Object
//				.GetValue<decimal?>(key);

//			result
//				.Should()
//				.Be(value);
//		}

//		[Theory]
//		[InlineData(null)]
//		[InlineData(12.345d)]
//		public void ReturnNullableDecimalBrackets(double? doubleValue)
//		{
//			const string key = nameof(key);
//			decimal? value = doubleValue switch
//			{
//				null => null,
//				not null => Convert.ToDecimal(doubleValue)
//			};

//			var fixture = CreateClass();

//			fixture
//				.SetupValue<decimal?>(key)
//				.Returns(value);

//			var result = value switch
//			{
//				null => fixture.Object[key] == null ? (decimal?)null : throw new Exception(),
//				_ => decimal.Parse(fixture.Object[key])
//			};

//			result
//				.Should()
//				.Be(value);
//		}

//		[Fact]
//		public void ReturnDouble()
//		{
//			const string key = nameof(key);
//			const double value = 12.345d;

//			var fixture = CreateClass();

//			fixture
//				.SetupValue<double>(key)
//				.Returns(value);

//			var result = fixture.Object
//				.GetValue<double>(key);

//			result
//				.Should()
//				.Be(value);
//		}

//		[Fact]
//		public void ReturnDoubleBrackets()
//		{
//			const string key = nameof(key);
//			const double value = 12.345d;

//			var fixture = CreateClass();

//			fixture
//				.SetupValue<double>(key)
//				.Returns(value);

//			var result = double.Parse(fixture.Object[key]);

//			result
//				.Should()
//				.Be(value);
//		}

//		[Theory]
//		[InlineData(null)]
//		[InlineData(12.345d)]
//		public void ReturnNullableDouble(double? value)
//		{
//			const string key = nameof(key);

//			var fixture = CreateClass();

//			fixture
//				.SetupValue<double?>(key)
//				.Returns(value);

//			var result = fixture.Object
//				.GetValue<double?>(key);

//			result
//				.Should()
//				.Be(value);
//		}

//		[Theory]
//		[InlineData(null)]
//		[InlineData(12.345d)]
//		public void ReturnNullableDoubleBrackets(double? value)
//		{
//			const string key = nameof(key);

//			var fixture = CreateClass();

//			fixture
//				.SetupValue<double?>(key)
//				.Returns(value);

//			var result = value switch
//			{
//				null => fixture.Object[key] == null ? (double?)null : throw new Exception(),
//				_ => double.Parse(fixture.Object[key])
//			};

//			result
//				.Should()
//				.Be(value);
//		}

//		[Fact]
//		public void ReturnFloat()
//		{
//			const string key = nameof(key);
//			const float value = 12.345f;

//			var fixture = CreateClass();

//			fixture
//				.SetupValue<float>(key)
//				.Returns(value);

//			var result = fixture.Object
//				.GetValue<float>(key);

//			result
//				.Should()
//				.Be(value);
//		}

//		[Fact]
//		public void ReturnFloatBrackets()
//		{
//			const string key = nameof(key);
//			const float value = 12.345f;

//			var fixture = CreateClass();

//			fixture
//				.SetupValue<float>(key)
//				.Returns(value);

//			var result = float.Parse(fixture.Object[key]);

//			result
//				.Should()
//				.Be(value);
//		}

//		[Theory]
//		[InlineData(null)]
//		[InlineData(12.345f)]
//		public void ReturnNullableFloat(float? value)
//		{
//			const string key = nameof(key);

//			var fixture = CreateClass();

//			fixture
//				.SetupValue<float?>(key)
//				.Returns(value);

//			var result = fixture.Object
//				.GetValue<float?>(key);

//			result
//				.Should()
//				.Be(value);
//		}

//		[Theory]
//		[InlineData(null)]
//		[InlineData(12.345f)]
//		public void ReturnNullableFloatBrackets(float? value)
//		{
//			const string key = nameof(key);

//			var fixture = CreateClass();

//			fixture
//				.SetupValue<float?>(key)
//				.Returns(value);

//			var result = value switch
//			{
//				null => fixture.Object[key] == null ? (float?)null : throw new Exception(),
//				_ => float.Parse(fixture.Object[key])
//			};

//			result
//				.Should()
//				.Be(value);
//		}
//	}
//}

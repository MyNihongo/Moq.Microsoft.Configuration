using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Moq.Microsoft.Configuration.Tests.Setups.SectionSetupTests
{
	public sealed class ReturnsClassArraysShould : MockTestsBase
	{
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

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
		public void SetupUint()
		{
			const string key = nameof(key);
			const int value = 123;

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

		[Fact]
		public void SetupLong()
		{
			const string key = nameof(key);
			const long value = 123;

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

		[Fact]
		public void SetupUlong()
		{
			const string key = nameof(key);
			const int value = 123;

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

		[Fact]
		public void SetupString()
		{
			const string key = nameof(key), value = nameof(value);

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

		[Fact]
		public void SetupClass()
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

			var section = fixture.Object
				.GetSection(key);

			section
				.GetValue<string>(nameof(value.StringValue))
				.Should()
				.Be(value.StringValue);

			section
				.GetValue<int>(nameof(value.IntValue))
				.Should()
				.Be(value.IntValue);

			section
				.GetValue<bool>(nameof(value.BoolValue))
				.Should()
				.Be(value.BoolValue);
		}
	}
}

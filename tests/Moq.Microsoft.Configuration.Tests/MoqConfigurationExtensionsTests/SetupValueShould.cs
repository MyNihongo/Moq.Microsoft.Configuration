using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Moq.Microsoft.Configuration.Tests.MoqConfigurationExtensionsTests
{
	public sealed class SetupValueShould : MockTestsBase
	{
		[Fact]
		public void ReturnString()
		{
			const string key = nameof(key), value = nameof(value);

			var fixture = CreateClass();

			fixture
				.SetupValue<string>(key)
				.Returns(value);

			var result = fixture.Object
				.GetValue<string>(key);

			result
				.Should()
				.Be(value);
		}

		[Theory]
		[InlineData(true)]
		[InlineData(false)]
		public void ReturnBool(bool value)
		{
			const string key = nameof(key);

			var fixture = CreateClass();

			fixture
				.SetupValue<bool>(key)
				.Returns(value);

			var result = fixture.Object
				.GetValue<bool>(key);

			result
				.Should()
				.Be(value);
		}

		[Fact]
		public void ReturnChar()
		{
			const string key = nameof(key);
			const char value = 'q';

			var fixture = CreateClass();

			fixture
				.SetupValue<char>(key)
				.Returns(value);

			var result = fixture.Object
				.GetValue<char>(key);

			result
				.Should()
				.Be(value);
		}

		[Fact]
		public void ReturnByte()
		{
			const string key = nameof(key);
			const byte value = 1;

			var fixture = CreateClass();

			fixture
				.SetupValue<byte>(key)
				.Returns(value);

			var result = fixture.Object
				.GetValue<byte>(key);

			result
				.Should()
				.Be(value);
		}

		[Fact]
		public void ReturnSbyte()
		{
			const string key = nameof(key);
			const sbyte value = -1;

			var fixture = CreateClass();

			fixture
				.SetupValue<sbyte>(key)
				.Returns(value);

			var result = fixture.Object
				.GetValue<sbyte>(key);

			result
				.Should()
				.Be(value);
		}

		[Fact]
		public void ReturnInt()
		{
			const string key = nameof(key);
			const int value = 1_235;

			var fixture = CreateClass();

			fixture
				.SetupValue<int>(key)
				.Returns(value);

			var result = fixture.Object
				.GetValue<int>(key);

			result
				.Should()
				.Be(value);
		}

		[Fact]
		public void ReturnUint()
		{
			const string key = nameof(key);
			const uint value = 3_000_000_000;

			var fixture = CreateClass();

			fixture
				.SetupValue<uint>(key)
				.Returns(value);

			var result = fixture.Object
				.GetValue<uint>(key);

			result
				.Should()
				.Be(value);
		}

		[Fact]
		public void ReturnLong()
		{
			const string key = nameof(key);
			const long value = 6_000_000_000L;

			var fixture = CreateClass();

			fixture
				.SetupValue<long>(key)
				.Returns(value);

			var result = fixture.Object
				.GetValue<long>(key);

			result
				.Should()
				.Be(value);
		}

		[Fact]
		public void ReturnUlong()
		{
			const string key = nameof(key);
			const ulong value = 18_000_000_000_000_000_000L;

			var fixture = CreateClass();

			fixture
				.SetupValue<ulong>(key)
				.Returns(value);

			var result = fixture.Object
				.GetValue<ulong>(key);

			result
				.Should()
				.Be(value);
		}

		[Fact]
		public void ReturnShort()
		{
			const string key = nameof(key);
			const short value = 30_000;

			var fixture = CreateClass();

			fixture
				.SetupValue<short>(key)
				.Returns(value);

			var result = fixture.Object
				.GetValue<short>(key);

			result
				.Should()
				.Be(value);
		}

		[Fact]
		public void ReturnUshort()
		{
			const string key = nameof(key);
			const ushort value = 60_000;

			var fixture = CreateClass();

			fixture
				.SetupValue<ushort>(key)
				.Returns(value);

			var result = fixture.Object
				.GetValue<ushort>(key);

			result
				.Should()
				.Be(value);
		}
	}
}

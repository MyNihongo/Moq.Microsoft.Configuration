using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Moq.Microsoft.Configuration.Tests.Setups.ValueSetupTests
{
	public sealed class ValueSetupShould : MockTestsBase
	{
		[Fact]
		public void ReturnConfigurationSection()
		{
			const string key = nameof(key);

			var fixture = CreateClass();
			fixture.SetupValue<int>(key);

			var result = fixture.Object
				.GetSection(key);

			result
				.Should()
				.NotBeNull()
				.And
				.BeAssignableTo<IConfigurationSection>();
		}

		[Fact]
		public void ReturnDefaultValueInt()
		{
			const string key = nameof(key);

			var fixture = CreateClass();
			fixture.SetupValue<int>(key);

			var result = fixture.Object
				.GetValue<int>(key);

			result
				.Should()
				.Be(0);
		}

		[Fact]
		public void ReturnDefaultValueBool()
		{
			const string key = nameof(key);

			var fixture = CreateClass();
			fixture.SetupValue<bool>(key);

			var result = fixture.Object
				.GetValue<bool>(key);

			result
				.Should()
				.BeFalse();
		}

		[Fact]
		public void ReturnDefaultValueChar()
		{
			const string key = nameof(key);

			var fixture = CreateClass();
			fixture.SetupValue<char>(key);

			var result = fixture.Object
				.GetValue<char>(key);

			result
				.Should()
				.Be('\0');
		}

		[Fact]
		public void ReturnDefaultValueByte()
		{
			const string key = nameof(key);

			var fixture = CreateClass();
			fixture.SetupValue<byte>(key);

			var result = fixture.Object
				.GetValue<byte>(key);

			result
				.Should()
				.Be(0);
		}

		[Fact]
		public void ReturnDefaultValueSbyte()
		{
			const string key = nameof(key);

			var fixture = CreateClass();
			fixture.SetupValue<sbyte>(key);

			var result = fixture.Object
				.GetValue<sbyte>(key);

			result
				.Should()
				.Be(0);
		}

		[Fact]
		public void ReturnDefaultValueString()
		{
			const string key = nameof(key);

			var fixture = CreateClass();
			fixture.SetupValue<string>(key);

			var result = fixture.Object
				.GetValue<string>(key);

			result
				.Should()
				.BeNull();
		}

		[Fact]
		public void ReturnDefaultValueUint()
		{
			const string key = nameof(key);

			var fixture = CreateClass();
			fixture.SetupValue<uint>(key);

			var result = fixture.Object
				.GetValue<uint>(key);

			result
				.Should()
				.Be(0);
		}

		[Fact]
		public void ReturnDefaultValueLong()
		{
			const string key = nameof(key);

			var fixture = CreateClass();
			fixture.SetupValue<long>(key);

			var result = fixture.Object
				.GetValue<long>(key);

			result
				.Should()
				.Be(0L);
		}

		[Fact]
		public void ReturnDefaultValueUlong()
		{
			const string key = nameof(key);

			var fixture = CreateClass();
			fixture.SetupValue<ulong>(key);

			var result = fixture.Object
				.GetValue<ulong>(key);

			result
				.Should()
				.Be(0L);
		}

		[Fact]
		public void ReturnDefaultValueShort()
		{
			const string key = nameof(key);

			var fixture = CreateClass();
			fixture.SetupValue<short>(key);

			var result = fixture.Object
				.GetValue<short>(key);

			result
				.Should()
				.Be(0);
		}

		[Fact]
		public void ReturnDefaultValueUshort()
		{
			const string key = nameof(key);

			var fixture = CreateClass();
			fixture.SetupValue<ushort>(key);

			var result = fixture.Object
				.GetValue<ushort>(key);

			result
				.Should()
				.Be(0);
		}
	}
}

using System;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Xunit;
// ReSharper disable ConditionIsAlwaysTrueOrFalse

namespace Moq.Microsoft.Configuration.Tests.ConfigurationSetupTests
{
	public sealed class ReturnsValueShould : MockTestsBase
	{
		[Fact]
		public void NotSetupIfObjectNull()
		{
			const string key = nameof(key);

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(null);

			var result = fixture.Object
				.GetSection(key)
				.Exists();

			result
				.Should()
				.BeFalse();
		}

		[Fact]
		public void ThrowForBool()
		{
			const bool value = true;

			Action action = () => CreateClass()
				.SetupConfiguration()
				.Returns(value);

			action
				.Should()
				.ThrowExactly<InvalidOperationException>();
		}

		[Fact]
		public void ThrowForNullableBool()
		{
			bool? value = true;

			Action action = () => CreateClass()
				.SetupConfiguration()
				.Returns(value);

			action
				.Should()
				.ThrowExactly<InvalidOperationException>();
		}

		[Fact]
		public void ThrowForChar()
		{
			const char value = '日';

			Action action = () => CreateClass()
				.SetupConfiguration()
				.Returns(value);

			action
				.Should()
				.ThrowExactly<InvalidOperationException>();
		}

		[Fact]
		public void ThrowForNullableChar()
		{
			char? value = '日';

			Action action = () => CreateClass()
				.SetupConfiguration()
				.Returns(value);

			action
				.Should()
				.ThrowExactly<InvalidOperationException>();
		}

		[Fact]
		public void ThrowForInt()
		{
			const int value = 123;

			Action action = () => CreateClass()
				.SetupConfiguration()
				.Returns(value);

			action
				.Should()
				.ThrowExactly<InvalidOperationException>();
		}

		[Fact]
		public void ThrowForNullableInt()
		{
			int? value = 123;

			Action action = () => CreateClass()
				.SetupConfiguration()
				.Returns(value);

			action
				.Should()
				.ThrowExactly<InvalidOperationException>();
		}

		[Fact]
		public void ThrowForUint()
		{
			const uint value = 123u;

			Action action = () => CreateClass()
				.SetupConfiguration()
				.Returns(value);

			action
				.Should()
				.ThrowExactly<InvalidOperationException>();
		}

		[Fact]
		public void ThrowForNullableUint()
		{
			uint? value = 123u;

			Action action = () => CreateClass()
				.SetupConfiguration()
				.Returns(value);

			action
				.Should()
				.ThrowExactly<InvalidOperationException>();
		}

		[Fact]
		public void ThrowForByte()
		{
			const byte value = 123;

			Action action = () => CreateClass()
				.SetupConfiguration()
				.Returns(value);

			action
				.Should()
				.ThrowExactly<InvalidOperationException>();
		}

		[Fact]
		public void ThrowForNullableByte()
		{
			byte? value = 123;

			Action action = () => CreateClass()
				.SetupConfiguration()
				.Returns(value);

			action
				.Should()
				.ThrowExactly<InvalidOperationException>();
		}

		[Fact]
		public void ThrowSbyte()
		{
			const sbyte value = 123;

			Action action = () => CreateClass()
				.SetupConfiguration()
				.Returns(value);

			action
				.Should()
				.ThrowExactly<InvalidOperationException>();
		}

		[Fact]
		public void ThrowNullableSbyte()
		{
			sbyte? value = 123;

			Action action = () => CreateClass()
				.SetupConfiguration()
				.Returns(value);

			action
				.Should()
				.ThrowExactly<InvalidOperationException>();
		}

		[Fact]
		public void ThrowForShort()
		{
			const short value = 123;

			Action action = () => CreateClass()
				.SetupConfiguration()
				.Returns(value);

			action
				.Should()
				.ThrowExactly<InvalidOperationException>();
		}

		[Fact]
		public void ThrowForNullableShort()
		{
			short? value = 123;

			Action action = () => CreateClass()
				.SetupConfiguration()
				.Returns(value);

			action
				.Should()
				.ThrowExactly<InvalidOperationException>();
		}

		[Fact]
		public void ThrowForUshort()
		{
			const ushort value = 123;

			Action action = () => CreateClass()
				.SetupConfiguration()
				.Returns(value);

			action
				.Should()
				.ThrowExactly<InvalidOperationException>();
		}

		[Fact]
		public void ThrowForNullableUshort()
		{
			ushort? value = 123;

			Action action = () => CreateClass()
				.SetupConfiguration()
				.Returns(value);

			action
				.Should()
				.ThrowExactly<InvalidOperationException>();
		}

		[Fact]
		public void ThrowForLong()
		{
			const long value = 123L;

			Action action = () => CreateClass()
				.SetupConfiguration()
				.Returns(value);

			action
				.Should()
				.ThrowExactly<InvalidOperationException>();
		}

		[Fact]
		public void ThrowForNullableLong()
		{
			long? value = 123L;

			Action action = () => CreateClass()
				.SetupConfiguration()
				.Returns(value);

			action
				.Should()
				.ThrowExactly<InvalidOperationException>();
		}

		[Fact]
		public void ThrowForUlong()
		{
			const ulong value = 123UL;

			Action action = () => CreateClass()
				.SetupConfiguration()
				.Returns(value);

			action
				.Should()
				.ThrowExactly<InvalidOperationException>();
		}

		[Fact]
		public void ThrowForNullableUlong()
		{
			ulong? value = 123UL;

			Action action = () => CreateClass()
				.SetupConfiguration()
				.Returns(value);

			action
				.Should()
				.ThrowExactly<InvalidOperationException>();
		}

		[Fact]
		public void ThrowForDecimal()
		{
			const decimal value = 123m;

			Action action = () => CreateClass()
				.SetupConfiguration()
				.Returns(value);

			action
				.Should()
				.ThrowExactly<InvalidOperationException>();
		}

		[Fact]
		public void ThrowForNullableDecimal()
		{
			decimal? value = 123m;

			Action action = () => CreateClass()
				.SetupConfiguration()
				.Returns(value);

			action
				.Should()
				.ThrowExactly<InvalidOperationException>();
		}

		[Fact]
		public void ThrowForDouble()
		{
			const double value = 123d;

			Action action = () => CreateClass()
				.SetupConfiguration()
				.Returns(value);

			action
				.Should()
				.ThrowExactly<InvalidOperationException>();
		}

		[Fact]
		public void ThrowForNullableDouble()
		{
			double? value = 123d;

			Action action = () => CreateClass()
				.SetupConfiguration()
				.Returns(value);

			action
				.Should()
				.ThrowExactly<InvalidOperationException>();
		}

		[Fact]
		public void ThrowForFloat()
		{
			const float value = 123f;

			Action action = () => CreateClass()
				.SetupConfiguration()
				.Returns(value);

			action
				.Should()
				.ThrowExactly<InvalidOperationException>();
		}

		[Fact]
		public void ThrowForNullableFloat()
		{
			float? value = 123f;

			Action action = () => CreateClass()
				.SetupConfiguration()
				.Returns(value);

			action
				.Should()
				.ThrowExactly<InvalidOperationException>();
		}

		[Fact]
		public void ThrowForString()
		{
			const string value = nameof(value);

			Action action = () => CreateClass()
				.SetupConfiguration()
				.Returns(value);

			action
				.Should()
				.ThrowExactly<InvalidOperationException>();
		}
	}
}

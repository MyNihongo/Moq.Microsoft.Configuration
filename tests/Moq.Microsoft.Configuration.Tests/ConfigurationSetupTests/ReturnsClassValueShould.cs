using System;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Moq.Microsoft.Configuration.Tests.Resources;
using Xunit;

namespace Moq.Microsoft.Configuration.Tests.ConfigurationSetupTests
{
	public sealed class ReturnsClassValueShould : ConfigurationTestsBase
	{
		[Fact]
		public void SetupClassWithEnumLong()
		{
			var value = new
			{
				Value = LongEnum.Val1
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetValue<LongEnum>(nameof(value.Value));

			result
				.Should()
				.Be(value.Value);
		}
	}
}

using System;
using FluentAssertions;
using Xunit;

namespace Moq.Microsoft.Configuration.Tests.ConfigurationSetupTests
{
	public sealed class ReturnsEnumerableShould : MockTestsBase
	{
		[Fact]
		public void ThrowForBoolEnumerable()
		{
			var value = new[] { true, false };

			Action action = () => CreateClass()
				.SetupConfiguration()
				.Returns(value);

			action
				.Should()
				.ThrowExactly<InvalidOperationException>();
		}
	}
}

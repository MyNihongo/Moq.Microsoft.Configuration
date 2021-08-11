using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Moq.Microsoft.Configuration.Tests.EmptyMockConfigurationTests
{
	public sealed class EmptyMockConfigurationShould : EmptyConfigurationRootTestsBase
	{
		[Fact]
		public void ReturnDefaultValue()
		{
			const int fallbackValue = 123;

			var fixture = CreateClass();

			var result = fixture.Object
				.GetValue("key", fallbackValue);

			result
				.Should()
				.Be(fallbackValue);
		}

		[Fact]
		public void ReturnDefaultValuePath()
		{
			const int fallbackValue = 123;

			var fixture = CreateClass();

			var result = fixture.Object
				.GetValue("section:key", fallbackValue);

			result
				.Should()
				.Be(fallbackValue);
		}

		[Fact]
		public void ReturnDefaultValueSection()
		{
			const int fallbackValue = 123;

			var fixture = CreateClass();
			var section = fixture.Object.GetSection("section");

			var result = section.GetValue("key", fallbackValue);

			result
				.Should()
				.Be(fallbackValue);
		}
	}
}

using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Moq.Microsoft.Configuration.Tests.Utils.ConfigurationSectionTests;

public sealed class ConfigurationSectionShould : ConfigurationSectionTestsBase
{
	[Fact]
	public void HaveNoChildren()
	{
		var result = CreateClass()
			.GetChildren();

		result
			.Should()
			.BeEmpty();
	}

	[Fact]
	public void NotExist()
	{
		var result = CreateClass()
			.Exists();

		result
			.Should()
			.BeFalse();
	}
}
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Moq.Microsoft.Configuration.Tests.Setups.SectionSetupTests
{
	public sealed class SectionSetupShould : MockTestsBase
	{
		[Fact]
		public void ReturnConfigurationSection()
		{
			const string key = nameof(key);

			var fixture = CreateClass();
			fixture.SetupSection<int>(key);

			var result = fixture.Object
				.GetSection(key);

			result
				.Should()
				.NotBeNull()
				.And
				.BeAssignableTo<IConfigurationSection>();
		}

		[Fact]
		public void NotExist()
		{
			const string key = nameof(key);

			var fixture = CreateClass();
			fixture.SetupSection<int>(key);

			var result = fixture.Object
				.GetSection(key)
				.Exists();

			result
				.Should()
				.BeFalse();
		}
	}
}

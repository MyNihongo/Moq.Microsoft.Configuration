using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Moq.Microsoft.Configuration.Tests.Setups.SetupChildrenTests
{
	public sealed class SetupChildrenShould : MockTestsBase
	{
		[Fact]
		public void ReturnConfigurationSection()
		{
			const string key = nameof(key);

			var fixture = CreateClass();
			fixture.SetupChildren<int>(key);

			var result = fixture.Object
				.GetSection(key);

			result
				.Should()
				.NotBeNull()
				.And
				.BeAssignableTo<IConfigurationSection>();
		}
	}
}

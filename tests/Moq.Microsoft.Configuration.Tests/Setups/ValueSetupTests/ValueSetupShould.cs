using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Moq.Microsoft.Configuration.Tests.Setups.ValueSetupTests
{
	public sealed class ValueSetupShould : MockTestsBase
	{
		[Fact]
		public void ReturnEmptySection()
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
	}
}

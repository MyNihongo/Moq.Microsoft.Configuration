﻿using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Moq.Microsoft.Configuration.Tests.Setups.ChildrenSetupTests
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

		[Fact]
		public void ReturnEmptyArray()
		{
			const string key = nameof(key);

			var fixture = CreateClass();
			fixture.SetupChildren<int>(key);

			var result = fixture.Object
				.GetSection(key)
				.GetChildren();

			result
				.Should()
				.BeEmpty();
		}

		[Fact]
		public void NotExist()
		{
			const string key = nameof(key);

			var fixture = CreateClass();
			fixture.SetupChildren<int>(key);

			var result = fixture.Object
				.GetSection(key)
				.Exists();

			result
				.Should()
				.BeFalse();
		}
	}
}
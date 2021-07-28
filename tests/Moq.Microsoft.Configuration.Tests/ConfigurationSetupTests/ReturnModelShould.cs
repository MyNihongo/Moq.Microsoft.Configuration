using System.Collections.Generic;
using System.Collections.Immutable;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Moq.Microsoft.Configuration.Tests.Resources;
using Xunit;

namespace Moq.Microsoft.Configuration.Tests.ConfigurationSetupTests
{
	public sealed class ReturnModelShould : MockTestsBase
	{
		[Fact]
		public void BindModel()
		{
			const string name1 = nameof(name1), name2 = nameof(name2);
			const int age1 = 2, age2 = 3;

			var expectedResult = new TestRecord[]
			{
				new() { Name = name1, Number = age1},
				new() { Name = name2, Number = age2}
			};

			var value = new
			{
				Section = new[]
				{
					new {Name = name1, Number = age1},
					new {Name = name2, Number = age2}
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection(nameof(value.Section))
				.Get<TestRecord[]>();

			result
				.Should()
				.BeEquivalentTo(expectedResult, x => x.WithStrictOrdering());
		}

		[Fact]
		public void GetDefaultValueIfUnmatchedProperties()
		{
			const string name = "scale1";

			var expectedResult = new Dictionary<byte, string>
			{
				{0, name}
			};

			var value = new
			{
				IpAddress = "127.0.0.1",
				Port = 123,
				ScalesNames = new[]
				{
					new { Id = 2, Name = name }
				}
			};

			var fixture = CreateClass();

			fixture
				.SetupConfiguration()
				.Returns(value);

			var result = fixture.Object
				.GetSection("ScalesNames")
				.Get<TestRecord[]>()
				.ToImmutableSortedDictionary(x => x.Number, x => x.Name);

			result
				.Should()
				.BeEquivalentTo(expectedResult);
		}
	}
}

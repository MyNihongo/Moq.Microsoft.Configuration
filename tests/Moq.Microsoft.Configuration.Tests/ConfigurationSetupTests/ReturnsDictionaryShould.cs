namespace Moq.Microsoft.Configuration.Tests.ConfigurationSetupTests;

// TODO: create tests with src-gen
public sealed class ReturnsDictionaryShould : ConfigurationTestsBase
{
	[Fact]
	public void ReturnKeys()
	{
		const string key1 = nameof(key1), key2 = nameof(key2);
		const int value1 = 123, value2 = 321;

		var expected = new Dictionary<string, int>
		{
			{ key1, value1 },
			{ key2, value2 }
		};

		var value = new
		{
			Section = expected
		};

		var fixture = CreateClass();

		fixture
			.SetupConfiguration()
			.Returns(value);

		var result = fixture.Object
			.GetSection(nameof(value.Section))
			.Get<Dictionary<string, int>>();

		result
			.Should()
			.BeEquivalentTo(expected, x => x.WithStrictOrdering());
	}
}
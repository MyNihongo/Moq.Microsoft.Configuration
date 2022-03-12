namespace Moq.Microsoft.Configuration.Tests.ConfigurationSetupTests;

public sealed class ReturnsExpandoObjectShould : ConfigurationTestsBase
{
	[Fact]
	public void SetExpandoObjectAsRoot()
	{
		const string field1 = nameof(field1),
			field2 = nameof(field2);

		var expandoObject = new ExpandoObjectBuilder()
			.Set(field1, new
			{
				Prop1 = 123,
				Obj1 = new
				{
					Prop1 = 321,
					Prop2 = "string"
				}
			})
			.Set(field2, new
			{
				Prop1 = "string value",
				Prop2 = new
				{
					Nested = new
					{
						Prop1 = "value"
					},
					Prop2 = 123L
				}
			}).Build();

		var fixture = CreateClass();

		fixture
			.SetupConfiguration()
			.Returns(expandoObject);

		var result1 = fixture.Object
			.GetSection(field1);

		var result2 = fixture.Object
			.GetSection(field2);
	}
}
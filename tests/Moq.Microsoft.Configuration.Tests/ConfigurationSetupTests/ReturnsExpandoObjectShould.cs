// ReSharper disable UnusedAutoPropertyAccessor.Local
namespace Moq.Microsoft.Configuration.Tests.ConfigurationSetupTests;

public sealed class ReturnsExpandoObjectShould : ConfigurationTestsBase
{
	[Fact]
	public void SetExpandoObjectAsRoot()
	{
		var expected1 = new Field1
		{
			Prop1 = 123,
			Obj1 = new Field1.Object1
			{
				Prop1 = 321,
				Prop2 = "string"
			}
		};

		var expected2 = new Field2
		{
			Prop1 = new[] { "string1", "string2" },
			Prop2 = new Field2.Property2
			{
				Nested = new Field2.Property2.NestedRecord
				{
					Prop1 = "value"
				},
				Prop2 = 123L
			}
		};

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
				Prop1 = new[] { "string1", "string2" },
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
			.GetSection(field1)
			.Get<Field1>();

		var result2 = fixture.Object
			.GetSection(field2)
			.Get<Field2>();

		result1
			.Should()
			.Be(expected1);

		result2
			.Should()
			.BeEquivalentTo(expected2);
	}

	private sealed record Field1
	{
		public int Prop1 { get; init; }

		public Object1 Obj1 { get; init; } = new();

		public sealed record Object1
		{
			public int Prop1 { get; init; }

			public string Prop2 { get; init; } = string.Empty;
		}
	}

	private sealed record Field2
	{
		public string[] Prop1 { get; init; } = Array.Empty<string>();

		public Property2 Prop2 { get; init; } = new();

		public sealed record Property2
		{
			public NestedRecord Nested { get; init; } = new();

			public long Prop2 { get; init; }

			public sealed record NestedRecord
			{
				public string Prop1 { get; init; } = string.Empty;
			}
		}
	}
}
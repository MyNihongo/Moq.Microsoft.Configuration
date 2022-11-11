using System.Text;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Generators.Base;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Models;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Resources;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Utils.Extensions;

namespace Moq.Microsoft.Configuration.Tests.SourceGenerators.Generators;

internal sealed class ReturnsClassOfEnumerableGenerator : TestGeneratorEnumerableBase
{
	public ReturnsClassOfEnumerableGenerator()
		: base("ClassOfEnumerable")
	{
	}

	protected override void CreateTestsForExists(in TypeDetails type, in StringBuilder stringBuilder)
	{
		CreateInitialSetup(type, stringBuilder, "Exists", true)
			.AppendLine("\tvar result = fixture.Object.GetSection(nameof(value.Values)).Exists();")
			.AppendLine("\tresult.Should().BeTrue();")
			.AppendLine("}");
	}

	protected override void CreateTestsForExistsSection(in TypeDetails type, in StringBuilder stringBuilder)
	{
		CreateInitialSetup(type, stringBuilder, "ExistSections", false)
			.AppendLine("\tvar section = fixture.Object.GetSection(nameof(value.Values));")
			.AppendLine("\tfor (var i = 0; i < value.Values.Length; i++)")
			.AppendLine("\t{")
			.AppendLine("\t\tvar result = section.GetSection(i.ToString()).Exists();")
			.AppendLine("\t\tresult.Should().BeTrue();")
			.AppendLine("\t}")
			.AppendLine("}");
	}

	protected override void CreateTestsForGet(in TypeDetails type, in StringBuilder stringBuilder)
	{
		CreateInitialSetup(type, stringBuilder, "Get", true)
			.AppendFormat("\tvar result = fixture.Object.GetSection(nameof(value.Values)).Get<{0}[]>();", type.DeclarationName)
			.AppendLine("\tresult.Should().BeEquivalentTo(value.Values);")
			.AppendLine("}");
	}

	protected override void CreateTestsForBind(in TypeDetails type, in StringBuilder stringBuilder)
	{
		var expectedResult = type.IsNullable
			? "value.Values.Where(x => x != null)"
			: "value.Values";

		CreateInitialSetup(type, stringBuilder, "Bind", true)
			.AppendFormat("\tvar result = new List<{0}>({1});", type.DeclarationName, type.ValueTexts.Length).AppendLine()
			.AppendLine("\tfixture.Object.GetSection(nameof(value.Values)).Bind(result);")
			.AppendFormat("\tresult.Should().BeEquivalentTo({0});", expectedResult).AppendLine()
			.AppendLine("}");
	}

	protected override void CreateTestsItemGetValue(in TypeDetails type, in StringBuilder stringBuilder)
	{
		CreateInitialSetup(type, stringBuilder, "Items_GetValue", true)
			.AppendLine("\tfor (var i = 0; i < value.Values.Length; i++)")
			.AppendLine("\t{")
			.AppendFormat("\t\tvar result = fixture.Object.GetValue<{0}>($\"{{nameof(value.Values)}}:{{i}}\");", type.DeclarationName).AppendLine()
			.AppendLine("\t\tresult.Should().Be(value.Values[i]);")
			.AppendLine("\t}")
			.AppendLine("}");
	}

	protected override void CreateTestsItemBrackets(in TypeDetails type, in StringBuilder stringBuilder)
	{
		CreateInitialSetup(type, stringBuilder, "Items_Brackets", true)
			.AppendLine("\tfor (var i = 0; i < value.Values.Length; i++)")
			.AppendLine("\t{")
			.AppendLine("\t\tvar strResult = fixture.Object[$\"{nameof(value.Values)}:{i}\"]!;")
			.AppendParse(type, "value.Values[i]", "\t\t")
			.AppendLine("\t\tresult.Should().Be(value.Values[i]);")
			.AppendLine("\t}")
			.AppendLine("}");
	}

	private static StringBuilder CreateInitialSetup(in TypeDetails type, in StringBuilder stringBuilder, string methodName, bool appendNull) =>
		stringBuilder
			.AppendLine("[Fact]")
			.AppendFormat("public void {0}_{1}()", methodName, type.TestType).AppendLine()
			.AppendLine("{")
			.Append("\tvar value = new {Values=")
			.AppendAllValues(type, appendNull)
			.AppendLine("};")
			.AppendFormat("\tvar fixture = {0}();", GeneratorConst.CreateFixtureMethodName).AppendLine()
			.AppendLine("\tfixture.SetupConfiguration().Returns(value);");
}
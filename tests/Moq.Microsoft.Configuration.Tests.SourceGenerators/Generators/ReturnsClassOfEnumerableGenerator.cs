using System.Text;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Generators.Base;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Models;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Resources;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Utils.Extensions;

namespace Moq.Microsoft.Configuration.Tests.SourceGenerators.Generators
{
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
}

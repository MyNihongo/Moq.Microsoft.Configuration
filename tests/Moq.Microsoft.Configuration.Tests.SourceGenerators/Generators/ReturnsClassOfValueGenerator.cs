using System.Text;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Generators.Base;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Models;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Resources;

namespace Moq.Microsoft.Configuration.Tests.SourceGenerators.Generators
{
	internal sealed class ReturnsClassOfValueGenerator : TestGeneratorValueBase
	{
		public ReturnsClassOfValueGenerator()
			: base("ClassOfValue")
		{
		}

		protected override void CreateTestForExists(TypeDetails type, StringBuilder stringBuilder)
		{
			stringBuilder
				.AppendLine("[Fact]")
				.AppendFormat("public void Exist_{0}()", type.TestType).AppendLine()
				.AppendLine("{")
				.AppendFormat("\tvar value = new {{Value = ({0}){1}}};", type.DeclarationName, type.ValueTexts[0]).AppendLine()
				.AppendFormat("\tvar fixture = {0}();", GeneratorConst.CreateFixtureMethodName).AppendLine()
				.AppendLine("\tfixture.SetupConfiguration().Returns(value);")
				.AppendLine("\tvar result = fixture.Object.GetSection(nameof(value.Value)).Exists();")
				.AppendLine("\tresult.Should().BeTrue();")
				.AppendLine("}");
		}

		protected override void CreateTestForGetValue(TypeDetails type, StringBuilder stringBuilder)
		{
			AppendTestInitialisation(type, stringBuilder, "GetValue", out var valueInput);
		}

		private static void AppendTestInitialisation(TypeDetails type, StringBuilder stringBuilder, string methodName, out string valueInput)
		{
			valueInput = type.ValueTexts[0];

			if (type.IsNullable)
			{
				stringBuilder
					.AppendLine("[Theory]")
					.AppendLine("[InlineData(null)]")
					.AppendFormat("[InlineData(({0}){1})]", type.DeclarationName, valueInput).AppendLine()
					.AppendFormat("public void {0}_{1}(object input)", methodName, type.TestType);

				valueInput = "input";
			}
			else
			{
				stringBuilder
					.AppendLine("[Fact]")
					.AppendFormat("public void {0}_{1}()", methodName, type.ValueTexts);
			}

			stringBuilder
				.AppendLine("{");



			stringBuilder.AppendLine("}");
		}
	}
}

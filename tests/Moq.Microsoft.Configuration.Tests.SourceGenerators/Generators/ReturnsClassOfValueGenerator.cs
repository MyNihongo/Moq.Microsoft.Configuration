using System;
using System.Text;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Generators.Base;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Models;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Resources;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Utils.Extensions;

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
			AppendTestInitialisation(type, stringBuilder, "GetValue", GenerateTestResult);

			static void GenerateTestResult(TypeDetails type, StringBuilder stringBuilder) =>
				stringBuilder
					.AppendFormat("\tvar result = fixture.Object.GetValue<{0}>(nameof(value.Value));", type.DeclarationName).AppendLine()
					.AppendLine("\tresult.Should().Be(value.Value);");
		}

		protected override void CreateTestsForGetSectionGet(TypeDetails type, StringBuilder stringBuilder)
		{
			AppendTestInitialisation(type, stringBuilder, "GetSection_Get", GenerateTestResult);

			static void GenerateTestResult(TypeDetails type, StringBuilder stringBuilder) =>
				stringBuilder
					.AppendFormat("\tvar result = fixture.Object.GetSection(nameof(value.Value)).Get<{0}>();", type.DeclarationName).AppendLine()
					.AppendLine("\tresult.Should().Be(value.Value);");
		}

		protected override void CreateTestsForBrackets(TypeDetails type, StringBuilder stringBuilder)
		{
			AppendTestInitialisation(type, stringBuilder, "Brackets", GenerateTestResult);

			static void GenerateTestResult(TypeDetails type, StringBuilder stringBuilder)
			{
				if (type.IsNullable)
				{
					if (type.CanParse)
					{
						stringBuilder
							.AppendLine("\tvar strResult = fixture.Object[nameof(value.Value)];")
							.AppendFormat("\t{0} result = input == null ? null : {1};", type.DeclarationName, type.GetParseMethod("strResult"))
							.AppendLine();
					}
					else
					{
						stringBuilder
							.AppendLine("\tvar result = fixture.Object[nameof(value.Value)];");
					}
				}
				else
				{
					stringBuilder
						.AppendFormat("\tvar result = {0};", type.GetParseMethod("fixture.Object[nameof(value.Value)]"))
						.AppendLine();
				}

				stringBuilder
					.AppendLine("\tresult.Should().Be(value.Value);");
			}
		}

		private static void AppendTestInitialisation(TypeDetails type, StringBuilder stringBuilder, string methodName, Action<TypeDetails, StringBuilder> testFunc)
		{
			if (type.IsNullable)
			{
				var attributeValue = type.GetAttributeValue(type.ValueTexts[0]);

				stringBuilder
					.AppendLine("[Theory]")
					.AppendLine("[InlineData(null)]")
					.AppendFormat("[InlineData({0})]", attributeValue.Value).AppendLine()
					.AppendFormat("public void {0}_{1}({2} input)", methodName, type.TestType, attributeValue.ParameterType).AppendLine()
					.AppendLine("{")
					.Append("\tvar value = new {Value=");

				if (!string.IsNullOrEmpty(attributeValue.ConversionFunc))
					stringBuilder.AppendFormat("{0}(input)", attributeValue.ConversionFunc);
				else
					stringBuilder.Append("input");

				stringBuilder.AppendLine("};");
			}
			else
			{
				stringBuilder
					.AppendLine("[Fact]")
					.AppendFormat("public void {0}_{1}()", methodName, type.TestType).AppendLine()
					.AppendLine("{")
					.AppendFormat("\tvar value = new {{Value=({0}){1}}};", type.DeclarationName, type.ValueTexts[0]).AppendLine();
			}

			stringBuilder
				.AppendFormat("\tvar fixture = {0}();", GeneratorConst.CreateFixtureMethodName).AppendLine()
				.AppendLine("\tfixture.SetupConfiguration().Returns(value);");

			testFunc(type, stringBuilder);
			stringBuilder.AppendLine("}");
		}
	}
}

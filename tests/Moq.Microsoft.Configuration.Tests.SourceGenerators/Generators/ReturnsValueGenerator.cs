using System.Text;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Generators.Base;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Models;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Resources;

namespace Moq.Microsoft.Configuration.Tests.SourceGenerators.Generators
{
	internal sealed class ReturnsValueGenerator : TestGeneratorBase
	{
		public ReturnsValueGenerator()
			: base("ReturnsValue")
		{
		}

		protected override void CreateTestsForType(TypeDetails type, StringBuilder stringBuilder)
		{
			var declaration = type.IsConst ? $"const {type.DeclarationName}" : type.DeclarationName;

			stringBuilder
				.AppendLine("[Fact]")
				.AppendFormat("public void ThrowException{0}()", type.TestType).AppendLine()
				.AppendLine("{")
				.AppendFormat("\t{0} value = {1};", declaration, type.ValueTexts[0]).AppendLine()
				.AppendFormat("\tAction action = () => {0}().SetupConfiguration().Returns(value);", GeneratorConst.CreateFixtureMethodName).AppendLine()
				.AppendFormat("\taction.Should().ThrowExactly<InvalidOperationException>();").AppendLine()
				.AppendLine("}");
		}
	}
}

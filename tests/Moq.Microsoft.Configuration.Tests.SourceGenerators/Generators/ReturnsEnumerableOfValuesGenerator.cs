using System.Text;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Generators.Base;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Models;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Resources;

namespace Moq.Microsoft.Configuration.Tests.SourceGenerators.Generators
{
	internal sealed class ReturnsEnumerableOfValuesGenerator : TestGeneratorBase
	{
		public ReturnsEnumerableOfValuesGenerator()
			: base("EnumerableOfValues")
		{
		}

		protected override void CreateTestsForType(TypeDetails type, StringBuilder stringBuilder)
		{
			stringBuilder
				.AppendLine("[Fact]")
				.AppendFormat("public void ThrowException_{0}_Enumerable()", type.TestType).AppendLine()
				.AppendLine("{")
				.AppendFormat("\tvar value = new {0}[] {{", type.DeclarationName);

			for (var i = 0; i < type.ValueTexts.Length; i++)
			{
				if (i != 0)
					stringBuilder.Append(',');

				stringBuilder.Append(type.ValueTexts[i]);
			}

			if (type.IsNullable)
			{
				stringBuilder.Append(",null");
			}

			stringBuilder
				.AppendLine("};")
				.AppendFormat("\tAction action = () => {0}().SetupConfiguration().Returns(value);", GeneratorConst.CreateFixtureMethodName).AppendLine()
				.AppendFormat("\taction.Should().ThrowExactly<InvalidOperationException>();").AppendLine()
				.AppendLine("}");
		}
	}
}

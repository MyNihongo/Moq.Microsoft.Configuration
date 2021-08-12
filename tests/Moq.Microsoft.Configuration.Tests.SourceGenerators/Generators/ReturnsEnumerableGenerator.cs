using System.Text;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Generators.Base;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Models;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Resources;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Utils.Extensions;

namespace Moq.Microsoft.Configuration.Tests.SourceGenerators.Generators
{
	internal sealed class ReturnsEnumerableGenerator : TestGeneratorBase
	{
		public ReturnsEnumerableGenerator()
			: base("Enumerable")
		{
		}

		protected override void CreateTestsForType(TypeDetails type, StringBuilder stringBuilder)
		{
			stringBuilder
				.AppendLine("[Fact]")
				.AppendFormat("public void ThrowException_{0}_Enumerable()", type.TestType).AppendLine()
				.AppendLine("{")
				.Append("\tvar value = ")
				.AppendAllValues(type)
				.AppendLine(";")
				.AppendFormat("\tAction action = () => {0}().SetupConfiguration().Returns(value);", GeneratorConst.CreateFixtureMethodName).AppendLine()
				.AppendFormat("\taction.Should().ThrowExactly<InvalidOperationException>();").AppendLine()
				.AppendLine("}");
		}
	}
}

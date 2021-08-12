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
			stringBuilder
				.AppendLine("[Fact]")
				.AppendFormat("public void Exist_{0}()", type.TestType).AppendLine()
				.AppendLine("{")
				.Append("\tvar value = new {Values=")
				.AppendAllValues(type)
				.AppendLine("};")
				.AppendFormat("\tvar fixture = {0}();", GeneratorConst.CreateFixtureMethodName).AppendLine()
				.AppendLine("\tfixture.SetupConfiguration().Returns(value);")
				.AppendLine("\tvar result = fixture.Object.GetSection(nameof(value.Values)).Exists();")
				.AppendLine("\tresult.Should().BeTrue();")
				.AppendLine("}");
		}
	}
}

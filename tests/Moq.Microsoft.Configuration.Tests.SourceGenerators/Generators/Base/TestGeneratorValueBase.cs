using System.Collections.Generic;
using System.Text;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Models;

namespace Moq.Microsoft.Configuration.Tests.SourceGenerators.Generators.Base
{
	internal abstract class TestGeneratorValueBase : TestGeneratorBase
	{
		protected TestGeneratorValueBase(string testCase)
			: base(testCase)
		{
		}

		protected abstract void CreateTestForExists(TypeDetails type, StringBuilder stringBuilder);

		protected abstract void CreateTestForGetValue(TypeDetails type, StringBuilder stringBuilder);

		protected abstract void CreateTestsForGetSectionGet(TypeDetails type, StringBuilder stringBuilder);

		protected sealed override void CreateTestsForType(TypeDetails type, StringBuilder stringBuilder)
		{
			CreateTestForExists(type, stringBuilder);
			CreateTestForGetValue(type, stringBuilder);
			CreateTestsForGetSectionGet(type, stringBuilder);
		}

		protected override IEnumerable<string> GetAdditionalUsings()
		{
			yield return "Microsoft.Extensions.Configuration";
		}
	}
}

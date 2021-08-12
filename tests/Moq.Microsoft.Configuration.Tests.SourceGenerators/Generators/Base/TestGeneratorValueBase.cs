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

		protected abstract void CreateTestForExists(in TypeDetails type, in StringBuilder stringBuilder);

		protected abstract void CreateTestForGetValue(in TypeDetails type, in StringBuilder stringBuilder);

		protected abstract void CreateTestsForGetSectionGet(in TypeDetails type, in StringBuilder stringBuilder);

		protected abstract void CreateTestsForBrackets(in TypeDetails type, in StringBuilder stringBuilder);

		protected sealed override void CreateTestsForType(TypeDetails type, StringBuilder stringBuilder)
		{
			CreateTestForExists(type, stringBuilder);
			CreateTestForGetValue(type, stringBuilder);
			CreateTestsForGetSectionGet(type, stringBuilder);
			CreateTestsForBrackets(type, stringBuilder);
		}

		protected override IEnumerable<string> GetAdditionalUsings()
		{
			yield return "Microsoft.Extensions.Configuration";
		}
	}
}

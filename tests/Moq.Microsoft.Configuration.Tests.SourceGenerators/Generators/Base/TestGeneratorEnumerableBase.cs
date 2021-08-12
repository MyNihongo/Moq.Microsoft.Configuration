using System.Collections.Generic;
using System.Text;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Models;

namespace Moq.Microsoft.Configuration.Tests.SourceGenerators.Generators.Base
{
	internal abstract class TestGeneratorEnumerableBase : TestGeneratorBase
	{
		protected TestGeneratorEnumerableBase(string testCase)
			: base(testCase)
		{
		}

		protected abstract void CreateTestsForExists(in TypeDetails type, in StringBuilder stringBuilder);
		
		protected abstract void CreateTestsForExistsSection(in TypeDetails type, in StringBuilder stringBuilder);
		
		protected abstract void CreateTestsForGet(in TypeDetails type, in StringBuilder stringBuilder);
		
		protected abstract void CreateTestsForBind(in TypeDetails type, in StringBuilder stringBuilder);
		
		protected abstract void CreateTestsItemGetValue(in TypeDetails type, in StringBuilder stringBuilder);
		
		protected abstract void CreateTestsItemBrackets(in TypeDetails type, in StringBuilder stringBuilder);

		protected sealed override void CreateTestsForType(TypeDetails type, StringBuilder stringBuilder)
		{
			CreateTestsForExists(type, stringBuilder);
			CreateTestsForExistsSection(type, stringBuilder);
			CreateTestsForGet(type, stringBuilder);
			CreateTestsForBind(type, stringBuilder);
			CreateTestsItemGetValue(type, stringBuilder);
			CreateTestsItemBrackets(type, stringBuilder);
		}

		protected override IEnumerable<string> GetAdditionalUsings()
		{
			yield return "Microsoft.Extensions.Configuration";
			yield return "System.Collections.Generic";
			yield return "System.Linq";
		}
	}
}

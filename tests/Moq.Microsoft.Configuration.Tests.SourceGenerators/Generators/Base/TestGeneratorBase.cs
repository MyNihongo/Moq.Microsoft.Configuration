using System;
using System.Collections.Generic;
using System.Text;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Interfaces;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Models;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Resources;

namespace Moq.Microsoft.Configuration.Tests.SourceGenerators.Generators.Base
{
	internal abstract class TestGeneratorBase : ITestGenerator
	{
		private readonly string _testCase;

		protected TestGeneratorBase(string testCase)
		{
			_testCase = testCase;
		}

		protected abstract void CreateTestsForType(TypeDetails type, StringBuilder stringBuilder);

		public ClassDeclaration Generate(string baseClass, TypeDetails[] types)
		{
			var stringBuilder = new StringBuilder();

			// Using statements
			foreach (var @using in GetUsings())
			{
				stringBuilder
					.AppendFormat("using {0};", @using)
					.AppendLine();
			}

			// Class declaration
			var className = $"{baseClass}_{_testCase}";

			stringBuilder
				.AppendFormat("namespace {0}", GeneratorConst.Namespace).AppendLine()
				.AppendLine("{")
				.AppendFormat("\tpublic sealed class {0} : {1}", className, baseClass).AppendLine()
				.AppendLine("\t{");

			for (var i = 0; i < types.Length; i++)
				CreateTestsForType(types[i], stringBuilder);

			var declaration = stringBuilder
				.AppendLine("\t}")
				.Append("}")
				.ToString();

			return new ClassDeclaration(className, declaration);
		}

		private static IEnumerable<string> GetUsings()
		{
			yield return "System";
			yield return "FluentAssertions";
			yield return "Xunit";
		}
	}
}

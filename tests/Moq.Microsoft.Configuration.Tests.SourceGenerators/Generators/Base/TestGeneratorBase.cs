using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.ObjectPool;
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

		public ClassDeclaration Generate(string baseClass, Type[] types, ObjectPool<StringBuilder> stringBuilderPool)
		{
			var stringBuilder = stringBuilderPool.Get();

			// Using statements
			foreach (var @using in GetUsings())
			{
				stringBuilder
					.AppendFormat("{0};", @using)
					.AppendLine();
			}

			// Class declaration
			var className = $"{baseClass}_{_testCase}";

			stringBuilder
				.AppendFormat("namespace {0}", GeneratorConst.Namespace)
				.AppendLine("{")
				.AppendFormat("\tpublic sealed class {0} : {1}", className, baseClass).AppendLine()
				.AppendLine("\t{");

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

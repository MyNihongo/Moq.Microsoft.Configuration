using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Enums;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Extensions;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Generators;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Interfaces;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Models;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Resources;

namespace Moq.Microsoft.Configuration.Tests.SourceGenerators
{
	[Generator]
	public sealed class TestGenerator : ISourceGenerator
	{
		public void Initialize(GeneratorInitializationContext context)
		{
#if DEBUG
			//if (!System.Diagnostics.Debugger.IsAttached)
			//	System.Diagnostics.Debugger.Launch();
#endif
		}

		public void Execute(GeneratorExecutionContext context)
		{
			var generators = new ITestGenerator[]
			{
				new ReturnsValueGenerator(),
				new ReturnsEnumerableOfValuesGenerator()
			};

			var types = Enum.GetValues(typeof(TestType))
				.CreateDetails();

			foreach (var baseClass in CreateBaseClasses())
			{
				context.AddSource(in baseClass);

				for (var i = 0; i < generators.Length; i++)
				{
					var testClass = generators[i].Generate(baseClass.ClassName, types);
					context.AddSource(testClass);
				}
			}

			const string src =
@"using System;
using Xunit;

namespace Moq.Microsoft.Configuration.Tests
{
	public sealed class TestGen
	{
		[Fact]
		public void ThrowEx()
		{
			throw new Exception(""aaaaaa"");
		}
	}
}";

			context.AddSource("TestGen", src);
		}

		private static IEnumerable<ClassDeclaration> CreateBaseClasses()
		{
			var interfaces = new[]
			{
				"IConfiguration",
				"IConfigurationRoot"
			};

			for (var i = 0; i < interfaces.Length; i++)
			{
				yield return CreateBaseClass(interfaces[i], true);
				yield return CreateBaseClass(interfaces[i], false);
			}

			static ClassDeclaration CreateBaseClass(string interfaceType, bool isEmpty)
			{
				var className = $"{interfaceType.Substring(1)}TestsBase";
				if (isEmpty)
					className = "Empty" + className;

				var mockClass = isEmpty ? "EmptyMockConfiguration" : "Mock";

				var declaration =
$@"using Microsoft.Extensions.Configuration;
namespace {GeneratorConst.Namespace}
{{
	public abstract class {className}
	{{
		protected static {mockClass}<{interfaceType}> {GeneratorConst.CreateFixtureMethodName}() => new();
	}}
}}";

				return new ClassDeclaration(className, declaration);
			}
		}
	}
}

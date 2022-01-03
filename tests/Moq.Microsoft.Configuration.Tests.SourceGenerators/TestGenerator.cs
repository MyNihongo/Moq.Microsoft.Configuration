using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.CodeAnalysis;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Enums;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Generators;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Interfaces;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Models;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Resources;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Utils.Extensions;

namespace Moq.Microsoft.Configuration.Tests.SourceGenerators;

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
		{
			var enumsSource = CreateTestEnums();
			context.AddSource("TestEnums", enumsSource);
		}

		var generators = new ITestGenerator[]
		{
			new ReturnsValueGenerator(),
			new ReturnsEnumerableGenerator(),
			new ReturnsClassOfValueGenerator(),
			new ReturnsClassOfEnumerableGenerator()
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
	}

	private static string CreateTestEnums()
	{
		var enums = new[]
		{
			new { Type = "int", Suffix = string.Empty },
			new { Type = "uint", Suffix = "u" },
			new { Type = "byte", Suffix = string.Empty },
			new { Type = "sbyte", Suffix = string.Empty },
			new { Type = "short", Suffix = string.Empty },
			new { Type = "ushort", Suffix = string.Empty },
			new { Type = "long", Suffix = "L" },
			new { Type = "ulong", Suffix = "UL" }
		};

		var stringBuilder = new StringBuilder()
			.AppendFormat("namespace {0}", GeneratorConst.Namespace).AppendLine()
			.AppendLine("{");

		for (var i = 0; i < enums.Length; i++)
		{
			stringBuilder
				.Append("\tpublic enum ")
				.Append(char.ToUpper(enums[i].Type[0]))
				.Append(enums[i].Type.Substring(1))
				.AppendFormat("Enum : {0}", enums[i].Type).AppendLine();

			stringBuilder
				.AppendLine("\t{")
				.AppendFormat("\t\tVal1 = 1{0},", enums[i].Suffix).AppendLine()
				.AppendFormat("\t\tVal2 = 2{0}", enums[i].Suffix).AppendLine()
				.AppendLine("\t}");
		}

		return stringBuilder
			.Append("}")
			.ToString();
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
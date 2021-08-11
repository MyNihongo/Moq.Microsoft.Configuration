using Microsoft.CodeAnalysis;

namespace Moq.Microsoft.Configuration.Tests.SourceGenerators
{
	[Generator]
	public sealed class TestGenerator : ISourceGenerator
	{
		public void Initialize(GeneratorInitializationContext context)
		{

		}

		public void Execute(GeneratorExecutionContext context)
		{
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
			throw new Exception(""aaaaaaa!"");
		}
	}
}";

			context.AddSource("TestGen", src);
		}
	}
}

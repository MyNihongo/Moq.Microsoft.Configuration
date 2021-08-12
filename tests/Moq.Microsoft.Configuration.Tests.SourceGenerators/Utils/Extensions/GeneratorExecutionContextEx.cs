using Microsoft.CodeAnalysis;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Models;

namespace Moq.Microsoft.Configuration.Tests.SourceGenerators.Utils.Extensions
{
	internal static class GeneratorExecutionContextEx
	{
		public static void AddSource(this GeneratorExecutionContext @this, in ClassDeclaration classDeclaration) =>
			@this.AddSource(classDeclaration.ClassName, classDeclaration.Declaration);
	}
}

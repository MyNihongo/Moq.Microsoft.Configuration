namespace Moq.Microsoft.Configuration.Tests.SourceGenerators.Models
{
	internal readonly struct ClassDeclaration
	{
		public ClassDeclaration(string className, string declaration)
		{
			ClassName = className;
			Declaration = declaration;
		}

		public string ClassName { get; }

		public string Declaration { get; }
	}
}

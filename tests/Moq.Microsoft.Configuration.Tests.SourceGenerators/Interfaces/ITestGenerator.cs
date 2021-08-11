using System;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Models;

namespace Moq.Microsoft.Configuration.Tests.SourceGenerators.Interfaces
{
	internal interface ITestGenerator
	{
		ClassDeclaration Generate(string baseClass, Type[] types);
	}
}

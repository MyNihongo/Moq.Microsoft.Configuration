using Moq.Microsoft.Configuration.Tests.SourceGenerators.Models;

namespace Moq.Microsoft.Configuration.Tests.SourceGenerators.Interfaces;

internal interface IParseMethodConverter
{
	string Create(TypeDetails type, string value);
}
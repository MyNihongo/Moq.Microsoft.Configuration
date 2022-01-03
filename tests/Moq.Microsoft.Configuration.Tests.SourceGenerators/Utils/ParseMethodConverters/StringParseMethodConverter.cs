using Moq.Microsoft.Configuration.Tests.SourceGenerators.Interfaces;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Models;

namespace Moq.Microsoft.Configuration.Tests.SourceGenerators.Utils.ParseMethodConverters;

internal sealed class StringParseMethodConverter : IParseMethodConverter
{
	public string Create(TypeDetails type, string value) =>
		value;
}
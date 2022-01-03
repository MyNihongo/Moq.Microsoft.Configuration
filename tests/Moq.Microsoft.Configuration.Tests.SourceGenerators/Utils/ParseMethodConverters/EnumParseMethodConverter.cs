using Moq.Microsoft.Configuration.Tests.SourceGenerators.Interfaces;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Models;

namespace Moq.Microsoft.Configuration.Tests.SourceGenerators.Utils.ParseMethodConverters;

internal sealed class EnumParseMethodConverter : IParseMethodConverter
{
	public string Create(TypeDetails type, string value) =>
		string.Format("({0})Enum.Parse(typeof({0}), {1})", type.BasicDeclarationName, value);
}
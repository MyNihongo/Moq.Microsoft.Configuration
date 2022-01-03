using Moq.Microsoft.Configuration.Tests.SourceGenerators.Interfaces;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Models;

namespace Moq.Microsoft.Configuration.Tests.SourceGenerators.Utils.AttributeValueConverters;

internal sealed class CastAttributeValueConverter : IAttributeValueConverter
{
	public AttributeValue Convert(TypeDetails typeDetails, string value) =>
		new($"({typeDetails.BasicDeclarationName}){value}", typeDetails.DeclarationName, string.Empty);
}
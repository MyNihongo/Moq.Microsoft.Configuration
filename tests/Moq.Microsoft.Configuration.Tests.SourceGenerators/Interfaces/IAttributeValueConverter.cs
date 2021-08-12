using Moq.Microsoft.Configuration.Tests.SourceGenerators.Models;

namespace Moq.Microsoft.Configuration.Tests.SourceGenerators.Interfaces
{
	internal interface IAttributeValueConverter
	{
		AttributeValue Convert(TypeDetails typeDetails, string value);
	}
}

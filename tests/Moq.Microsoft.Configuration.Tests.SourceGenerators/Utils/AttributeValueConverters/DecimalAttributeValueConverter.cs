using Moq.Microsoft.Configuration.Tests.SourceGenerators.Interfaces;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Models;

namespace Moq.Microsoft.Configuration.Tests.SourceGenerators.Utils.AttributeValueConverters;

internal sealed class DecimalAttributeValueConverter : IAttributeValueConverter
{
	public AttributeValue Convert(TypeDetails typeDetails, string value)
	{
		value = value.Replace('m', 'd');
		var parameterType = "double";
		if (typeDetails.IsNullable)
			parameterType += '?';

		return new AttributeValue(value, parameterType, "Convert.ToDecimal");
	}
}
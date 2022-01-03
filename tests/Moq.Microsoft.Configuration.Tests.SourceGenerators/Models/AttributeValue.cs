namespace Moq.Microsoft.Configuration.Tests.SourceGenerators.Models;

internal readonly ref struct AttributeValue
{
	public AttributeValue(string value, string parameterType, string conversionFunc)
	{
		Value = value;
		ParameterType = parameterType;
		ConversionFunc = conversionFunc;
	}

	public string Value { get; }

	public string ParameterType { get; }

	public string ConversionFunc { get; }
}
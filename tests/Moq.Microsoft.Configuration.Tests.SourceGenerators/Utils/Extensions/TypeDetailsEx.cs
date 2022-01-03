using Moq.Microsoft.Configuration.Tests.SourceGenerators.Models;

namespace Moq.Microsoft.Configuration.Tests.SourceGenerators.Utils.Extensions;

internal static class TypeDetailsEx
{
	public static AttributeValue GetAttributeValue(this TypeDetails @this, in string value) =>
		@this.AttributeValueConverter != null
			? @this.AttributeValueConverter.Convert(@this, value)
			: new AttributeValue(value, @this.DeclarationName, string.Empty);

	public static string GetParseMethod(this TypeDetails @this, in string value) =>
		@this.ParseMethodConverter != null
			? @this.ParseMethodConverter.Create(@this, value)
			: $"{@this.BasicDeclarationName}.Parse({value})";
}
using System;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Enums;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Interfaces;

namespace Moq.Microsoft.Configuration.Tests.SourceGenerators.Models;

internal sealed record TypeDetails(in TestType TestType, in string BasicDeclarationName, in bool IsNullable = false, in bool IsConst = true)
{
	public TestType TestType { get; } = TestType;

	public string BasicDeclarationName { get; } = BasicDeclarationName;

	public string DeclarationName { get; } = IsNullable ? BasicDeclarationName + '?' : BasicDeclarationName;

	public bool IsNullable { get; } = IsNullable;

	public bool IsConst { get; } = IsConst;

	public string[] ValueTexts { get; set; } = Array.Empty<string>();

	public IAttributeValueConverter? AttributeValueConverter { get; set; }

	public IParseMethodConverter? ParseMethodConverter { get; set; }
}
using System.Text;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Models;

namespace Moq.Microsoft.Configuration.Tests.SourceGenerators.Utils.Extensions;

internal static class StringBuilderEx
{
	public static StringBuilder AppendAllValues(this StringBuilder @this, TypeDetails type, bool appendNull = true)
	{
		@this.AppendFormat("new {0}[] {{", type.DeclarationName);

		for (var i = 0; i < type.ValueTexts.Length; i++)
		{
			if (i != 0)
				@this.Append(',');

			@this.Append(type.ValueTexts[i]);
		}

		if (appendNull && type.IsNullable)
		{
			@this.Append(",null");
		}

		return @this.Append("}");
	}

	public static StringBuilder AppendParse(this StringBuilder @this, TypeDetails type, string itemVariable, string indent)
	{
		var parseMethod = type.GetParseMethod("strResult");

		if (type.IsNullable)
		{
			@this
				.AppendFormat("{0}{1} result = {2} == null ? null : {3};", indent, type.DeclarationName, itemVariable, parseMethod)
				.AppendLine();
		}
		else
		{
			@this
				.AppendFormat("{0}var result = {1};", indent, parseMethod)
				.AppendLine();
		}

		return @this;
	}
}
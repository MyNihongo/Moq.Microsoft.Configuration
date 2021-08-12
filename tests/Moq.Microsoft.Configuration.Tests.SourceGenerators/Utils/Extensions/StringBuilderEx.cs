using System.Text;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Models;

namespace Moq.Microsoft.Configuration.Tests.SourceGenerators.Utils.Extensions
{
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
	}
}

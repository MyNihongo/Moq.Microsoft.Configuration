using System;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Enums;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Models;

namespace Moq.Microsoft.Configuration.Tests.SourceGenerators.Extensions
{
	internal static class TestTypeEx
	{
		private static readonly string[]
			BoolValueTexts = { "true", "false" },
			CharValueTexts = { "'日'", "'本'" },
			IntValueTexts = { "123", "321" },
			UnsignedIntValueTexts = { "123u", "321u" },
			ByteValueTexts = { "123", "321" };

		public static TypeDetails[] CreateDetails(this Array @this)
		{
			var array = new TypeDetails[@this.Length];

			for (var i = 0; i < @this.Length; i++)
			{
				var val = (TestType)@this.GetValue(i);
				array[i] = val switch
				{
					TestType.Bool => new TypeDetails(val) { DeclarationName = "bool", ValueTexts = BoolValueTexts },
					TestType.BoolNullable => new TypeDetails(val, true) { DeclarationName = "bool?", ValueTexts = BoolValueTexts },
					TestType.Char => new TypeDetails(val) { DeclarationName = "char", ValueTexts = CharValueTexts },
					TestType.CharNullable => new TypeDetails(val, true) { DeclarationName = "char?", ValueTexts = CharValueTexts },
					TestType.Int => new TypeDetails(val) { DeclarationName = "int", ValueTexts = IntValueTexts },
					TestType.IntNullable => new TypeDetails(val, true) { DeclarationName = "int?", ValueTexts = IntValueTexts },
					TestType.UnsignedInt => new TypeDetails(val) { DeclarationName = "uint", ValueTexts = UnsignedIntValueTexts },
					TestType.UnsignedIntNullable => new TypeDetails(val, true) { DeclarationName = "uint?", ValueTexts = UnsignedIntValueTexts },
					TestType.Byte => new TypeDetails(val) { DeclarationName = "byte", ValueTexts = ByteValueTexts },
					TestType.ByteNullable => new TypeDetails(val, true) { DeclarationName = "byte?", ValueTexts = ByteValueTexts },
					_ => throw new ArgumentOutOfRangeException(nameof(@this), $"Unknown {nameof(TestType)}: {val}")
				};
			}

			return array;
		}
	}
}

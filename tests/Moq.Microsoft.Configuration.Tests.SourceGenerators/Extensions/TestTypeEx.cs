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
			IntValueTexts = { "-123", "123" },
			UintValueTexts = { "123u", "321u" },
			ByteValueTexts = { "123", "231" },
			SbyteValueTexts = { "-123", "123" },
			ShortValueTexts = { "-123", "123" },
			UshortValueTexts = { "123", "321" },
			LongValueTexts = { "-123L", "123L" },
			UlongValueTexts = { "123UL", "321UL" },
			DecimalValueTexts = { "-123.456m", "123.456m" },
			DoubleValueTexts = { "-123.456d", "123.456d" },
			FloatValueTexts = { "-123.456f", "123.456f" },
			StringValueTexts = { "\"abc\"", "\"cba\"" };

		public static TypeDetails[] CreateDetails(this Array @this)
		{
			var array = new TypeDetails[@this.Length];

			for (var i = 0; i < @this.Length; i++)
			{
				var val = (TestType)@this.GetValue(i);
				array[i] = val switch
				{
					TestType.Bool => new TypeDetails(val) { DeclarationName = "bool", ValueTexts = BoolValueTexts },
					TestType.BoolNullable => new TypeDetails(val, false) { DeclarationName = "bool?", ValueTexts = BoolValueTexts },
					TestType.Char => new TypeDetails(val) { DeclarationName = "char", ValueTexts = CharValueTexts },
					TestType.CharNullable => new TypeDetails(val, false) { DeclarationName = "char?", ValueTexts = CharValueTexts },
					TestType.Int => new TypeDetails(val) { DeclarationName = "int", ValueTexts = IntValueTexts },
					TestType.IntNullable => new TypeDetails(val, false) { DeclarationName = "int?", ValueTexts = IntValueTexts },
					TestType.IntUnsigned => new TypeDetails(val) { DeclarationName = "uint", ValueTexts = UintValueTexts },
					TestType.IntUnsignedNullable => new TypeDetails(val, false) { DeclarationName = "uint?", ValueTexts = UintValueTexts },
					TestType.Byte => new TypeDetails(val) { DeclarationName = "byte", ValueTexts = ByteValueTexts },
					TestType.ByteNullable => new TypeDetails(val, false) { DeclarationName = "byte?", ValueTexts = ByteValueTexts },
					TestType.SignedByte => new TypeDetails(val) { DeclarationName = "sbyte", ValueTexts = SbyteValueTexts },
					TestType.ByteSignedNullable => new TypeDetails(val, false) { DeclarationName = "sbyte?", ValueTexts = SbyteValueTexts },
					TestType.Short => new TypeDetails(val) { DeclarationName = "short", ValueTexts = ShortValueTexts },
					TestType.ShortNullable => new TypeDetails(val, false) { DeclarationName = "short?", ValueTexts = SbyteValueTexts },
					TestType.ShortUnsigned => new TypeDetails(val) { DeclarationName = "ushort", ValueTexts = UshortValueTexts },
					TestType.ShortUnsignedNullable => new TypeDetails(val, false) { DeclarationName = "ushort?", ValueTexts = UshortValueTexts },
					TestType.Long => new TypeDetails(val) { DeclarationName = "long", ValueTexts = LongValueTexts },
					TestType.LongNullable => new TypeDetails(val, false) { DeclarationName = "long?", ValueTexts = LongValueTexts },
					TestType.LongUnsigned => new TypeDetails(val) { DeclarationName = "ulong", ValueTexts = UlongValueTexts },
					TestType.LongUnsignedNullable => new TypeDetails(val, false) { DeclarationName = "ulong?", ValueTexts = UlongValueTexts },
					TestType.Decimal => new TypeDetails(val) { DeclarationName = "decimal", ValueTexts = DecimalValueTexts },
					TestType.DecimalNullable => new TypeDetails(val, false) { DeclarationName = "decimal?", ValueTexts = DecimalValueTexts },
					TestType.Double => new TypeDetails(val) { DeclarationName = "double", ValueTexts = DoubleValueTexts },
					TestType.DoubleNullable => new TypeDetails(val, false) { DeclarationName = "double?", ValueTexts = DoubleValueTexts },
					TestType.Float => new TypeDetails(val) { DeclarationName = "float", ValueTexts = FloatValueTexts },
					TestType.FloatNullable => new TypeDetails(val, false) { DeclarationName = "float?", ValueTexts = FloatValueTexts },
					TestType.String => new TypeDetails(val) { DeclarationName = "string", ValueTexts = StringValueTexts },
					_ => throw new ArgumentOutOfRangeException(nameof(@this), $"Unknown {nameof(TestType)}: {val}")
				};
			}

			return array;
		}
	}
}

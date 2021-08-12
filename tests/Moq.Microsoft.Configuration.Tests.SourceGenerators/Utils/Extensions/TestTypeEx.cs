using System;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Enums;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Interfaces;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Models;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Utils.AttributeValueConverters;

namespace Moq.Microsoft.Configuration.Tests.SourceGenerators.Utils.Extensions
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

		private static readonly IAttributeValueConverter
			CastAttributeValueConverter = new CastAttributeValueConverter(),
			DecimalAttributeValueConverter = new DecimalAttributeValueConverter();

		public static TypeDetails[] CreateDetails(this Array @this)
		{
			var array = new TypeDetails[@this.Length];

			for (var i = 0; i < @this.Length; i++)
			{
				var val = (TestType)@this.GetValue(i);
				array[i] = val switch
				{
					TestType.Bool => new TypeDetails(val, "bool") { ValueTexts = BoolValueTexts },
					TestType.BoolNullable => new TypeDetails(val, "bool", true) { ValueTexts = BoolValueTexts },
					TestType.Char => new TypeDetails(val, "char") { ValueTexts = CharValueTexts },
					TestType.CharNullable => new TypeDetails(val, "char", true) { ValueTexts = CharValueTexts },
					TestType.Int => new TypeDetails(val, "int") { ValueTexts = IntValueTexts },
					TestType.IntNullable => new TypeDetails(val, "int", true) { ValueTexts = IntValueTexts },
					TestType.IntUnsigned => new TypeDetails(val, "uint") { ValueTexts = UintValueTexts },
					TestType.IntUnsignedNullable => new TypeDetails(val, "uint", true) { ValueTexts = UintValueTexts },
					TestType.Byte => new TypeDetails(val, "byte") { ValueTexts = ByteValueTexts, AttributeValueConverter = CastAttributeValueConverter },
					TestType.ByteNullable => new TypeDetails(val, "byte", true) { ValueTexts = ByteValueTexts, AttributeValueConverter = CastAttributeValueConverter },
					TestType.SignedByte => new TypeDetails(val, "sbyte") { ValueTexts = SbyteValueTexts, AttributeValueConverter = CastAttributeValueConverter },
					TestType.ByteSignedNullable => new TypeDetails(val, "sbyte", true) { ValueTexts = SbyteValueTexts, AttributeValueConverter = CastAttributeValueConverter },
					TestType.Short => new TypeDetails(val, "short") { ValueTexts = ShortValueTexts, AttributeValueConverter = CastAttributeValueConverter },
					TestType.ShortNullable => new TypeDetails(val, "short", true) { ValueTexts = SbyteValueTexts, AttributeValueConverter = CastAttributeValueConverter },
					TestType.ShortUnsigned => new TypeDetails(val, "ushort") { ValueTexts = UshortValueTexts, AttributeValueConverter = CastAttributeValueConverter },
					TestType.ShortUnsignedNullable => new TypeDetails(val, "ushort", true) { ValueTexts = UshortValueTexts, AttributeValueConverter = CastAttributeValueConverter },
					TestType.Long => new TypeDetails(val, "long") { ValueTexts = LongValueTexts },
					TestType.LongNullable => new TypeDetails(val, "long", true) { ValueTexts = LongValueTexts },
					TestType.LongUnsigned => new TypeDetails(val, "ulong") { ValueTexts = UlongValueTexts },
					TestType.LongUnsignedNullable => new TypeDetails(val, "ulong", true) { ValueTexts = UlongValueTexts },
					TestType.Decimal => new TypeDetails(val, "decimal") { ValueTexts = DecimalValueTexts, AttributeValueConverter = DecimalAttributeValueConverter },
					TestType.DecimalNullable => new TypeDetails(val, "decimal", true) { ValueTexts = DecimalValueTexts, AttributeValueConverter = DecimalAttributeValueConverter },
					TestType.Double => new TypeDetails(val, "double") { ValueTexts = DoubleValueTexts },
					TestType.DoubleNullable => new TypeDetails(val, "double", true) { ValueTexts = DoubleValueTexts },
					TestType.Float => new TypeDetails(val, "float") { ValueTexts = FloatValueTexts },
					TestType.FloatNullable => new TypeDetails(val, "float", true) { ValueTexts = FloatValueTexts },
					TestType.String => new TypeDetails(val, "string", true) { ValueTexts = StringValueTexts },
					_ => throw new ArgumentOutOfRangeException(nameof(@this), $"Unknown {nameof(TestType)}: {val}")
				};
			}

			return array;
		}
	}
}

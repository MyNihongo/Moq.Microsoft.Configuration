using System.Globalization;

namespace Moq.Microsoft.Configuration;

internal static class ObjectEx
{
	public static string? SerialiseValue<T>(this T @this) =>
		@this switch
		{
			null => null,
			Enum x => x.ToString(),
			string x => x,
			bool x => x ? "true" : "false",
			char or byte or sbyte or int or uint or long or ulong or short or ushort => @this.ToString(),
			decimal x => x.ToString(CultureInfo.InvariantCulture),
			double x => x.ToString(CultureInfo.InvariantCulture),
			float x => x.ToString(CultureInfo.InvariantCulture),
			_ => throw new NotImplementedException($"Type {typeof(T).FullName} is not supported for configuration")
		};
}

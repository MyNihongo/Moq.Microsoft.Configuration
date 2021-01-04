using System;

namespace Moq.Microsoft.Configuration
{
	internal static class ObjectExtensions
	{
		public static string SerialiseValue<T>(this T @this) =>
			@this switch
			{
				string x => x,
				bool x => x ? "true" : "false",
				char or byte or sbyte or int or uint or long or ulong or short or ushort => @this.ToString(),
				_ => throw new NotImplementedException($"Type {typeof(T).FullName} is not supported for configuration")
			};
	}
}

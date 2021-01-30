namespace Moq.Microsoft.Configuration
{
	internal static class PathUtils
	{
		public static string Append(string basePath, string segment) =>
			string.IsNullOrEmpty(basePath)
				? segment
				: $"{basePath}:{segment}";
	}
}

namespace Moq.Microsoft.Configuration
{
	internal static class PathUtils
	{
		public static string Append(string basePath, string key) =>
			string.IsNullOrEmpty(basePath)
				? key
				: $"{basePath}:{key}";
	}
}

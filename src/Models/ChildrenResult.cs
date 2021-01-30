using System.Collections.Generic;

namespace Moq.Microsoft.Configuration
{
	internal readonly ref struct ChildrenResult
	{
		public ChildrenResult(IReadOnlyDictionary<int, string> values, string basePath)
		{
			Values = values;
			BasePath = basePath;
		}

		public IReadOnlyDictionary<int, string> Values { get; }

		public string BasePath { get; }
	}
}

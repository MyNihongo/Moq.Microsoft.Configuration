using System.Collections.Generic;

namespace Moq.Microsoft.Configuration
{
	public sealed record ConfigurationNode(
		string Name,
		object? Value = null)
	{
		public IList<ConfigurationNode> Children { get; } = new List<ConfigurationNode>();
	}
}

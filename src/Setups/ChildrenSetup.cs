using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace Moq.Microsoft.Configuration
{
	internal sealed class ChildrenSetup<T> : SetupBase, ISetup<IEnumerable<T>>
	{
		public ChildrenSetup(Mock<IConfiguration> mock, string path)
			: base(mock, path)
		{
		}

		public void Returns(IEnumerable<T> param)
		{
			var rootNode = new ConfigurationNode(Path, param);
			this.SetupConfigurationTree(rootNode);
		}
	}
}

using Microsoft.Extensions.Configuration;

namespace Moq.Microsoft.Configuration
{
	internal sealed class ValueSetup<T> : SetupBase, ISetup<T>
	{
		public ValueSetup(Mock<IConfiguration> mock, string path)
			: base(mock, path)
		{
			SetupReturns(default);
		}

		public void Returns(T param) =>
			SetupReturns(param);

		private void SetupReturns(T? param)
		{
			if (param == null)
				return;

			var rootNode = new ConfigurationNode(Path, param);
			this.SetupConfigurationTree(rootNode);

			//MockConfiguration.SetValue(RequireMockConfigurationSection, value);
		}
	}
}

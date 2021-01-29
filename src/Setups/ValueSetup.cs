using Microsoft.Extensions.Configuration;

namespace Moq.Microsoft.Configuration
{
	internal sealed class ValueSetup<T> : SetupBase, ISetup<T>
	{
		public ValueSetup(Mock<IConfiguration> mock, string path)
			: base(mock, path)
		{
		}

		public void Returns(T param)
		{
			MockConfigurationSection
				.SetupGet(x => x.Value)
				.Returns(param.SerialiseValue());
		}
	}
}

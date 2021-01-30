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

		private void SetupReturns(T? value)
		{
			if (value == null)
				return;

			MockConfiguration.SetValue(MockConfigurationSection, value);
		}
	}
}

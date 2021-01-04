using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace Moq.Microsoft.Configuration
{
	internal sealed class EnumerableSetup<T> : SetupBase, ISetup<IEnumerable<T>>
	{
		public EnumerableSetup(Mock<IConfiguration> mock, string path)
			: base(mock, path)
		{
		}

		public void Returns(IEnumerable<T> param)
		{
			var configs = param
				.Select(x =>
				{
					var mockSection = new Mock<IConfigurationSection>();

					mockSection
						.SetupGet(y => y.Value)
						.Returns(x.SerialiseValue());

					return mockSection.Object;
				});

			var mockConfigurationSection = new Mock<IConfigurationSection>();

			MockConfiguration
				.Setup(x => x.GetSection(Path))
				.Returns(mockConfigurationSection.Object);

			mockConfigurationSection
				.Setup(x => x.GetChildren())
				.Returns(configs);
		}
	}
}

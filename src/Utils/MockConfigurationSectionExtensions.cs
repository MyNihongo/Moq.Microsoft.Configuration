using System.Collections;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace Moq.Microsoft.Configuration
{
	internal static class MockConfigurationSectionExtensions
	{
		public static void SetupChildren(this Mock<IConfigurationSection> @this, IEnumerable props, string path)
		{
			IEnumerable<IConfigurationSection> CreateConfigurationSections()
			{
				var i = 0;
				foreach (var prop in props)
				{
					var mockSection = new Mock<IConfigurationSection>();

					var returnsValue = mockSection.SetupValue(prop);
					@this.SetupValueForPath(returnsValue, i.ToString(), path);

					yield return mockSection.Object;
					i++;
				}
			}

			@this
				.Setup(x => x.GetChildren())
				.Returns(CreateConfigurationSections);
		}

		public static string SetupValue<T>(this Mock<IConfigurationSection> @this, T prop)
		{
			var returnsValue = prop.SerialiseValue()!;

			@this
				.SetupGet(x => x.Value)
				.Returns(returnsValue);

			return returnsValue;
		}
	}
}

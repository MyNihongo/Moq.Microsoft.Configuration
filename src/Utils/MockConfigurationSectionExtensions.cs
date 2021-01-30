using System.Collections;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace Moq.Microsoft.Configuration
{
	internal static class MockConfigurationSectionExtensions
	{
		public static void SetupChildren(this Mock<IConfigurationSection> @this, IEnumerable props)
		{
			IEnumerable<IConfigurationSection> CreateConfigurationSections()
			{
				foreach (var prop in props)
				{
					var mockSection = new Mock<IConfigurationSection>();
					mockSection.SetupValue(prop);

					yield return mockSection.Object;
				}
			}

			@this
				.Setup(x => x.GetChildren())
				.Returns(CreateConfigurationSections);
		}

		public static void SetupValue<T>(this Mock<IConfigurationSection> @this, T prop) =>
			@this
				.SetupGet(x => x.Value)
				.Returns(prop.SerialiseValue()!);
	}
}

using System;
using Microsoft.Extensions.Configuration;

namespace Moq.Microsoft.Configuration
{
	internal abstract class SetupBase
	{
		protected SetupBase(Mock<IConfiguration> mock, string path)
		{
			MockConfiguration = mock;

			if (string.IsNullOrEmpty(path))
				return;

			MockConfigurationSection = new Mock<IConfigurationSection>();

			MockConfiguration
				.Setup(x => x.GetSection(path))
				.Returns(MockConfigurationSection.Object);

			MockConfigurationSection
				.SetupGet(x => x.Path)
				.Returns(path);
		}

		internal Mock<IConfiguration> MockConfiguration { get; }

		internal Mock<IConfigurationSection>? MockConfigurationSection { get; }

		protected Mock<IConfigurationSection> RequireMockConfigurationSection =>
			MockConfigurationSection ?? throw new NullReferenceException($"{nameof(MockConfigurationSection)} is NULL");
	}
}

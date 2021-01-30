using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace Moq.Microsoft.Configuration
{
	internal static class MockConfigurationExtensions
	{
		public static void SetValue<T>(this Mock<IConfiguration> @this, Mock<IConfigurationSection> mockConfigurationSection, T value) =>
			@this.SetSectionValue(mockConfigurationSection, value);

		public static void SetValue<T>(this Mock<IConfigurationSection> @this, Mock<IConfigurationSection> mockConfigurationSection, T value) =>
			@this.SetSectionValue(mockConfigurationSection, value);

		public static void SetChildren(this Mock<IConfiguration> @this, Mock<IConfigurationSection> mockConfigurationSection, IEnumerable props) =>
			@this.SetChildren<IConfiguration>(mockConfigurationSection, props);

		public static void SetChildren(this Mock<IConfigurationSection> @this, Mock<IConfigurationSection> mockConfigurationSection, IEnumerable props) =>
			@this.SetChildren<IConfigurationSection>(mockConfigurationSection, props);

		private static void SetPathValue<T>(this Mock<T> @this, string path, string value)
			where T : class, IConfiguration
		{
			@this
				.Setup(x => x[path])
				.Returns(value);
		}

		private static string SetSectionValue<T, TValue>(this Mock<T> @this, Mock<IConfigurationSection> mockConfigurationSection, TValue value)
			where T : class, IConfiguration
		{
			var returnsValue = value.SerialiseValue()!;

			mockConfigurationSection
				.SetupGet(x => x.Value)
				.Returns(returnsValue);

			@this.SetPathValue(mockConfigurationSection.Object.Path, returnsValue);
			return returnsValue;
		}

		private static void SetChildren<T>(this Mock<T> @this, Mock<IConfigurationSection> mockConfigurationSection, IEnumerable props)
			where T : class, IConfiguration
		{
			IEnumerable<IConfigurationSection> CreateConfigurationSections()
			{
				var i = 0;
				foreach (var prop in props)
				{
					var mockSection = new Mock<IConfigurationSection>();
					var pathSegment = i.ToString();

					mockSection
						.SetupGet(x => x.Path)
						.Returns(pathSegment);

					var value = mockConfigurationSection.SetSectionValue(mockSection, prop);
					var fullPath = PathUtils.Append(mockConfigurationSection.Object.Path, pathSegment);

					@this.SetPathValue(fullPath, value);

					yield return mockSection.Object;
					i++;
				}
			}

			// Enumeration must already be executed for `configuration[]` access
			var section = CreateConfigurationSections()
				.ToArray();

			mockConfigurationSection
				.Setup(x => x.GetChildren())
				.Returns(section);
		}
	}
}

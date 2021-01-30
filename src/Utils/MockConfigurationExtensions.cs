using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace Moq.Microsoft.Configuration
{
	internal static class MockConfigurationExtensions
	{
		public static void SetValue<T>(this Mock<IConfiguration> @this, Mock<IConfigurationSection> mockConfigurationSection, T value) =>
			@this.SetValue(mockConfigurationSection, value, string.Empty);

		public static void SetValue<T>(this Mock<IConfigurationSection> @this, Mock<IConfigurationSection> mockConfigurationSection, T value) =>
			@this.SetValue(mockConfigurationSection, value, @this.Object.Path);

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

		private static string SetValue<T, TValue>(this Mock<T> @this, Mock<IConfigurationSection> mockConfigurationSection, TValue value, string pathSegment)
			where T : class, IConfiguration
		{
			var returnsValue = value.SerialiseValue()!;

			mockConfigurationSection
				.SetupGet(x => x.Value)
				.Returns(returnsValue);

			@this.SetPathValue(pathSegment, returnsValue);
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
					var fullPath = PathUtils.Append(mockConfigurationSection.Object.Path, pathSegment);

					var value = mockConfigurationSection.SetValue(mockSection, prop, pathSegment);
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

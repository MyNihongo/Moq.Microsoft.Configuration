using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace Moq.Microsoft.Configuration
{
	internal static class MockConfigurationExtensions
	{
		//public static ValueResult SetValue<T>(this Mock<IConfigurationSection> @this, Mock<IConfigurationSection> mockConfigurationSection, T value)
		//{
		//	var (stringValue, path) = @this.SetSectionValue(mockConfigurationSection, value);
		//	path = PathUtils.Append(@this.Object.Path, path);

		//	return new ValueResult(stringValue, path);
		//}

		public static ChildrenResult SetChildren(this Mock<IConfigurationSection> @this, Mock<IConfigurationSection> mockConfigurationSection, IEnumerable props)
		{
			@this.SetChildren<IConfigurationSection>(mockConfigurationSection, props);

			var path = PathUtils.Append(@this.Object.Path, mockConfigurationSection.Object.Path);

			var values = mockConfigurationSection.Object
				.GetChildren()
				.Select((x, i) => new KeyValuePair<int, string>(i, x.Value))
				.ToDictionary(x => x.Key, x => x.Value);

			return new ChildrenResult(values, path);
		}


		private static void SetPathValue<T>(this Mock<T> @this, string path, string value)
			where T : class, IConfiguration
		{
			@this
				.Setup(x => x[path])
				.Returns(value);
		}

		private static ValueResult SetSectionValue<T, TValue>(this Mock<T> @this, Mock<IConfigurationSection> mockConfigurationSection, TValue value)
			where T : class, IConfiguration
		{
			var stringValue = value.SerialiseValue()!;
			var path = mockConfigurationSection.Object.Path;

			mockConfigurationSection
				.SetupGet(x => x.Value)
				.Returns(stringValue);

			@this.SetPathValue(path, stringValue);
			return new ValueResult(stringValue, path);
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

					var (value, _) = mockConfigurationSection.SetSectionValue(mockSection, prop);
					var fullPath = PathUtils.Append(mockConfigurationSection.Object.Path, pathSegment);

					@this.SetPathValue(fullPath, value);

					yield return mockSection.Object;
					i++;
				}
			}

			// Enumeration must already be executed for `configuration[]` access
			var sections = CreateConfigurationSections()
				.ToArray();

			mockConfigurationSection
				.Setup(x => x.GetChildren())
				.Returns(sections);
		}
	}
}

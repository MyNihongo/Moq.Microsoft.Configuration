using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace Moq.Microsoft.Configuration
{
	internal sealed class SectionSetup<T> : SetupBase, ISetup<T>
		where T : class
	{
		public SectionSetup(Mock<IConfiguration> mock, string path)
			: base(mock, path)
		{
		}

		public void Returns(T param)
		{
			var props = GetProperties();

			var configs = props
				.Select(x =>
				{
					var mockSection = new Mock<IConfigurationSection>();
					var value = x.GetValue(param)!;

					mockSection
						.SetupGet(y => y.Value)
						.Returns(value.SerialiseValue());

					return mockSection.Object;
				});

			MockConfigurationSection
				.Setup(x => x.GetChildren())
				.Returns(configs);
		}

		private static IEnumerable<PropertyInfo> GetProperties()
		{
			var props = typeof(T)
				.GetProperties();

			for (var i = 0; i < props.Length; i++)
			{
				if (!IsPrimitive(props[i].PropertyType))
					continue;

				yield return props[i];
			}
		}

		private static bool IsPrimitive(Type type)
		{
			if (type.IsPrimitive)
				return true;

			return Convert.GetTypeCode(type) switch
			{
				TypeCode.String => true,
				_ => false
			};
		}
	}
}

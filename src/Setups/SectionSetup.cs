using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace Moq.Microsoft.Configuration
{
	internal sealed class SectionSetup<T> : SetupBase, ISetup<T>
	{
		public SectionSetup(Mock<IConfiguration> mock, string path)
			: base(mock, path)
		{
		}

		public void Returns(T param)
		{
			var props = GetProperties();

			switch (props.Count)
			{
				case > 0:
					SetupPropsReturns(props, param);
					break;
				default:
					SetupValueReturns(param);
					break;
			}
		}

		private void SetupPropsReturns(IEnumerable<PropertyInfo> props, T param)
		{
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

		private void SetupValueReturns(T param)
		{
			MockConfigurationSection
				.SetupGet(x => x.Value)
				.Returns(param.SerialiseValue());
		}

		private static IReadOnlyCollection<PropertyInfo> GetProperties()
		{
			var type = typeof(T);

			if (type == typeof(string))
				return Array.Empty<PropertyInfo>();
			
			return typeof(T)
				.GetProperties()
				.Where(x => IsPrimitive(x.PropertyType))
				.ToArray();
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

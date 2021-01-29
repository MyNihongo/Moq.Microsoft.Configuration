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
			if (param == null)
				return;

			var props = GetProperties(param.GetType());

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
			foreach (var prop in props)
			{
				var mockSection = new Mock<IConfigurationSection>();
				var value = prop.GetValue(param)!;

				mockSection
					.SetupGet(y => y.Value)
					.Returns(value.SerialiseValue());

				MockConfigurationSection
					.Setup(x => x.GetSection(prop.Name))
					.Returns(mockSection.Object);
			}
		}

		private void SetupValueReturns(T param)
		{
			MockConfigurationSection
				.SetupGet(x => x.Value)
				.Returns(param.SerialiseValue());
		}

		private static IReadOnlyCollection<PropertyInfo> GetProperties(Type type)
		{
			if (type == typeof(string))
				return Array.Empty<PropertyInfo>();

			return type
				.GetProperties()
				.Where(x => IsPrimitive(x.PropertyType))
				.ToArray();
		}

		private static bool IsPrimitive(Type type)
		{
			if (type.IsPrimitive)
				return true;

			return Convert.GetTypeCode(type) == TypeCode.Object;
		}
	}
}

using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace Moq.Microsoft.Configuration
{
	public static class MoqConfigurationExtensions
	{
		public static ISetup<IEnumerable<T>> SetupChildren<T>(this Mock<IConfiguration> @this, string path) =>
			new EnumerableSetup<T>(@this, path);

		public static ISetup<T> SetupValue<T>(this Mock<IConfiguration> @this, string path) =>
			new ValueSetup<T>(@this, path);
	}
}

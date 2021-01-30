using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace Moq.Microsoft.Configuration
{
	public static class MoqConfigurationExtensions
	{
		/// <exception cref="ArgumentException"></exception>
		public static ISetup<IEnumerable<T>> SetupChildren<T>(this Mock<IConfiguration> @this, string path)
		{
			if (string.IsNullOrWhiteSpace(path))
				throw new ArgumentException("Path is an empty string", nameof(path));
			
			return new ChildrenSetup<T>(@this, path);
		}

		/// <exception cref="ArgumentException"></exception>
		public static ISetup<T> SetupValue<T>(this Mock<IConfiguration> @this, string path)
		{
			if (string.IsNullOrWhiteSpace(path))
				throw new ArgumentException("Path is an empty string", nameof(path));
			
			return new ValueSetup<T>(@this, path);
		}

		/// <exception cref="ArgumentException"></exception>
		public static ISetup<object> SetupSection(this Mock<IConfiguration> @this, string path)
		{
			if (string.IsNullOrWhiteSpace(path))
				throw new ArgumentException("Path is an empty string", nameof(path));
			
			return new SectionSetup(@this, path);
		}

		/// <exception cref="ArgumentException"></exception>
		public static ISetup<object> SetupRoot(this Mock<IConfiguration> @this) =>
			new SectionSetup(@this, string.Empty);
	}
}

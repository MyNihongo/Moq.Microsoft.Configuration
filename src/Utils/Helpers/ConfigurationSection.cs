using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

namespace Moq.Microsoft.Configuration
{
	internal sealed class ConfigurationSection : IConfigurationSection
	{
		public ConfigurationSection(string key)
		{
			Key = key;
			Path = $"Unknown:{key}";
		}

		public string Key { get; }

		public string Path { get; }

		public string? Value { get; set; }

		public IConfigurationSection GetSection(string key) =>
			throw new System.NotImplementedException();

		public IEnumerable<IConfigurationSection> GetChildren() =>
			throw new System.NotImplementedException();

		public IChangeToken GetReloadToken() =>
			throw new System.NotImplementedException();

		public string this[string key]
		{
			get => throw new System.NotImplementedException();
			set => throw new System.NotImplementedException();
		}
	}
}

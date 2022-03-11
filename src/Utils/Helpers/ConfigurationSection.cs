using Microsoft.Extensions.Primitives;

namespace Moq.Microsoft.Configuration;

internal sealed class ConfigurationSection : IConfigurationSection
{
	public ConfigurationSection(string key, string? path = null)
	{
		path ??= "Unknown";

		Key = key;
		Path = $"{path}:{key}";
	}

	public string Key { get; }

	public string Path { get; }

	public string? Value { get; set; }

	public IConfigurationSection GetSection(string key) =>
		new ConfigurationSection(key, Path);

	public IEnumerable<IConfigurationSection> GetChildren() =>
		Enumerable.Empty<IConfigurationSection>();

	public IChangeToken GetReloadToken() =>
		throw new NotImplementedException();

	public string this[string key]
	{
		get => throw new NotImplementedException();
		set => throw new NotImplementedException();
	}
}
namespace Moq.Microsoft.Configuration.Tests.Utils.ConfigurationSectionTests;

public abstract class ConfigurationSectionTestsBase
{
	internal static ConfigurationSection CreateClass() =>
		new("any");
}
using System.Dynamic;

namespace Moq.Microsoft.Configuration.Tests;

internal sealed class ExpandoObjectBuilder
{
	private readonly ExpandoObject _instance = new();

	private IDictionary<string, object?> Dictionary => _instance;

	public ExpandoObjectBuilder Set(string property, object data)
	{
		Dictionary.Add(property, data);
		return this;
	}

	public ExpandoObject Build() =>
		_instance;
}

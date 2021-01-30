namespace Moq.Microsoft.Configuration
{
	internal readonly ref struct ValueResult
	{
		public ValueResult(in string value, in string path)
		{
			Value = value;
			Path = path;
		}

		public string Value { get; }

		public string Path { get; }

		public void Deconstruct(out string value, out string path)
		{
			value = Value;
			path = Path;
		}
	}
}

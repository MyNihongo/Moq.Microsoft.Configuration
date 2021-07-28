namespace Moq.Microsoft.Configuration.Tests.Resources
{
	public sealed record TestRecord
	{
		public byte Number { get; set; }

		public string Name { get; set; } = string.Empty;
	}
}

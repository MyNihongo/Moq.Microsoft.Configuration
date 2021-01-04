using Microsoft.Extensions.Configuration;

namespace Moq.Microsoft.Configuration
{
	internal abstract class SetupBase
	{
		protected SetupBase(Mock<IConfiguration> mock, string path)
		{
			MockConfiguration = mock;
			Path = path;
		}

		protected Mock<IConfiguration> MockConfiguration { get; }
		
		public string Path { get; }
	}
}

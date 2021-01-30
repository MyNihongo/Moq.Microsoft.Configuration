using Microsoft.Extensions.Configuration;

namespace Moq.Microsoft.Configuration
{
	internal abstract class SetupBase
	{
		protected SetupBase(Mock<IConfiguration> mock, string path)
		{
			split by :
			
			MockConfiguration = mock;
			Path = path;
		}

		internal Mock<IConfiguration> MockConfiguration { get; }
		
		protected string Path { get; }
	}
}

using System;
using System.Text;
using Microsoft.Extensions.ObjectPool;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Generators.Base;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Interfaces;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Models;

namespace Moq.Microsoft.Configuration.Tests.SourceGenerators.Generators
{
	internal sealed class ReturnsValueGenerator : TestGeneratorBase
	{
		public ReturnsValueGenerator()
			: base("ReturnsValue")
		{
		}
	}
}

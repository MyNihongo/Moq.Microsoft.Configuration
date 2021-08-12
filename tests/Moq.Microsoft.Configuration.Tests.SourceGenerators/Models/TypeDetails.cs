﻿using System;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Enums;

namespace Moq.Microsoft.Configuration.Tests.SourceGenerators.Models
{
	internal sealed record TypeDetails
	{
		public TypeDetails(TestType testType, bool isConst = true)
		{
			TestType = testType;
			IsConst = isConst;
		}

		public TestType TestType { get; }

		public bool IsConst { get; }

		public string DeclarationName { get; set; } = string.Empty;

		public string[] ValueTexts { get; set; } = Array.Empty<string>();
	}
}

﻿using System;
using Moq.Microsoft.Configuration.Tests.SourceGenerators.Enums;

namespace Moq.Microsoft.Configuration.Tests.SourceGenerators.Models
{
	internal sealed record TypeDetails
	{
		public TypeDetails(TestType testType, string declarationName, bool isNullable = false, bool isConst = true)
		{
			TestType = testType;
			BasicDeclarationName = declarationName;
			DeclarationName = isNullable ? declarationName + '?' : declarationName;
			IsNullable = isNullable;
			IsConst = isConst;
		}

		public TestType TestType { get; }

		public string BasicDeclarationName { get; }

		public string DeclarationName { get; }

		public bool IsNullable { get; }

		public bool IsConst { get; }

		public string[] ValueTexts { get; set; } = Array.Empty<string>();
	}
}

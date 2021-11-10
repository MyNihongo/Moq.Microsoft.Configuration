using System;

namespace Moq.Microsoft.Configuration;

internal sealed record SectionInfo(
	string Name,
	object Value,
	Type SectionType);
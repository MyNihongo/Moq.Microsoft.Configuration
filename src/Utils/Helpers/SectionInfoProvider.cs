using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;

namespace Moq.Microsoft.Configuration;

internal class SectionInfoProvider
{
	private readonly ConcurrentDictionary<Type, PropertyInfo[]> _propertyMap = new();

	public IReadOnlyList<SectionInfo> Resolve(Type type, object obj)
	{
		var props = _propertyMap
			.GetOrAdd(type, x => x.GetProperties());

		var sectionInfos = new SectionInfo[props.Length];

		for (var i = 0; i < props.Length; i++)
			sectionInfos[i] = new SectionInfo(props[i].Name, props[i].GetValue(obj), props[i].PropertyType);

		return sectionInfos;
	}
}
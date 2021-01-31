using System.Reflection;

namespace Moq.Microsoft.Configuration
{
	internal static class PropertyInfoExtensions
	{
		public static SectionInfo ToSectionInfo(this PropertyInfo @this, object baseObject) =>
			new(@this.Name, @this.GetValue(baseObject), @this.PropertyType);
	}
}

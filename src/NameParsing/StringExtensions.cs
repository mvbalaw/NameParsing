using System;
using System.Linq;

namespace NameParsing
{
	public static class StringExtensions
	{
		public static NameParts ParseName(this string name)
		{
			var sections = name.Split(',');
			var nameParts = sections.First().Split(' ');
			var result = new NameParts
			             {
				             GivenName = nameParts.First(),
				             Surname = nameParts.Last()
			             };
			if (nameParts.Length > 2)
			{
				result.MiddleName = String.Join(" ", nameParts.Skip(1).Take(nameParts.Length - 2).ToArray());
			}
			if (sections.Length > 1)
			{
				result.Suffix = sections.Last();
			}
			return result;
		}
	}
}
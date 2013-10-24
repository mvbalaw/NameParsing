using System;
using System.Linq;

namespace NameParsing
{
	public static class StringExtensions
	{
		private static string NameWithoutAliases(string name)
		{
			var index = name.IndexOf(" aka ", StringComparison.OrdinalIgnoreCase);
			if (index != -1)
			{
				name = name.Substring(0, index);
			}
			index = name.IndexOf(" a/k/a ", StringComparison.OrdinalIgnoreCase);
			if (index != -1)
			{
				name = name.Substring(0, index);
			}
			index = name.IndexOf(" or ");
			if (index != -1)
			{
				name = name.Substring(0, index);
			}
			index = name.IndexOf('(');
			if (index != -1)
			{
				name = name.Substring(0, index);
			}
			return name.Trim();
		}

		public static NameParts ParseName(this string name)
		{
			var result = new NameParts();
			name = NameWithoutAliases(name);

			var sections = name.Split(',');
			var nameParts = sections.First().Split(' ');

			if (sections[0].EndsWith("."))
			{
				result.Suffix = nameParts.Last();
				nameParts = nameParts.Take(nameParts.Length - 1).ToArray();
			}
			else if (sections.Length > 1)
			{
				result.Suffix = sections.Last();
			}

			result.GivenName = nameParts.First();
			result.Surname = nameParts.Last();
			if (nameParts.Length > 2)
			{
				result.MiddleName = String.Join(" ", nameParts.Skip(1).Take(nameParts.Length - 2).ToArray());
			}

			return result;
		}
	}
}
﻿using System;
using System.Linq;

namespace NameParsing
{
	public static class StringExtensions
	{
		private static void HandleMultiPartSurname(NameParts result)
		{
			if (result.MiddleName == null)
			{
				return;
			}
			var parts = result.MiddleName.Split(' ');
			var middle = String.Join(" ", parts.TakeWhile(x => !x.Equals("de", StringComparison.OrdinalIgnoreCase)));
			if (middle.Length == result.MiddleName.Length)
			{
				return;
			}
			result.Surname = result.MiddleName.Substring(middle.Length).TrimStart() + " " + result.Surname;
			result.MiddleName = middle.Length == 0 ? null : middle;
		}

		private static string[] HandleNamePrefix(string[] nameParts, NameParts result)
		{
			if (nameParts[0].EndsWith(".") &&
				nameParts[0].Length > 2 &&
				nameParts[0].IndexOf('.') == nameParts[0].Length - 1)
			{
				result.Prefix = nameParts[0];
				nameParts = nameParts.Skip(1).ToArray();
			}
			return nameParts;
		}

		private static string[] HandleNameSuffix(string[] sections, NameParts result, string[] nameParts)
		{
			if (sections[0].EndsWith("."))
			{
				result.Suffix = nameParts.Last();
				nameParts = nameParts.Take(nameParts.Length - 1).ToArray();
			}
			else if (sections.Length > 1)
			{
				result.Suffix = sections.Last().Trim();
			}
			return nameParts;
		}

		private static string[] HandleRunTogetherInitialsInGivenName(string[] nameParts)
		{
			if (nameParts[0].IndexOf('.') != nameParts[0].LastIndexOf('.'))
			{
				var dotted = nameParts[0]
					.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries)
					.Where(x => x.Length > 0)
					.Select(x => x + ".");

				nameParts = dotted
					.Concat(nameParts.Skip(1))
					.ToArray();
			}
			return nameParts;
		}

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
			index = name.IndexOf(" dba ", StringComparison.OrdinalIgnoreCase);
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

			nameParts = HandleNameSuffix(sections, result, nameParts);
			nameParts = HandleNamePrefix(nameParts, result);
			nameParts = HandleRunTogetherInitialsInGivenName(nameParts);

			result.GivenName = nameParts.First();
			result.Surname = nameParts.Last();
			if (nameParts.Length > 2)
			{
				result.MiddleName = String.Join(" ", nameParts.Skip(1).Take(nameParts.Length - 2).ToArray());
			}

			HandleMultiPartSurname(result);

			return result;
		}
	}
}
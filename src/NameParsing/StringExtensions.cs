﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace NameParsing
{
	public static class StringExtensions
	{
		private static readonly string[] SingleWordNamePrefixes = { "al", "da", "de", "dela", "del", "den", "di", "du", "el", "la", "le", "lo", "mac", "mc", "saint", "san", "st", "st.", "van", "von" };

		private static void HandleDoubleWordSurnamePrefix(NameParts result, ICollection<string> parts)
		{
			if (!IsTwoPartSurnamePrefix(parts))
			{
				return;
			}

			result.Surname = String.Join(" ", parts.Skip(parts.Count - 2).Take(2)) + " " + result.Surname;
			result.MiddleName = parts.Count == 2 ? null : String.Join(" ", parts.Take(parts.Count - 2));
		}

		private static string[] HandleMultiPartGivenName(NameParts result, string[] nameParts)
		{
			var given = result.GivenName ?? "";
			var threeWordSurnamePrefix = new[] { given, nameParts[0] };
			if (nameParts.Length > 2 && nameParts[1].Length > 1 &&
				IsTwoPartSurnamePrefix(threeWordSurnamePrefix))
			{
				result.GivenName += " " + String.Join(" ", nameParts.Take(2));
				nameParts = nameParts.Skip(2).ToArray();
			}
			else if (nameParts.Length > 1 && nameParts[0].Length > 1 &&
				SingleWordNamePrefixes.Any(x => given.Equals(x, StringComparison.OrdinalIgnoreCase)))
			{
				result.GivenName += " " + nameParts.First();
				nameParts = nameParts.Skip(1).ToArray();
			}
			return nameParts;
		}

		private static void HandleMultiPartSurname(NameParts result)
		{
			if (result.MiddleName == null)
			{
				return;
			}
			var parts = result.MiddleName.Split(' ');

			HandleDoubleWordSurnamePrefix(result, parts);
			HandleSingleWordSurnamePrefixGivenAMiddleNameExists(result, parts);
			HandleSingleWordSurnamePrefix(result, parts);
		}

		private static string[] HandleNamePrefix(string[] nameParts, NameParts result)
		{
			while (nameParts[0].EndsWith(".") &&
				nameParts[0].Length > 2 &&
				nameParts[0].IndexOf('.') == nameParts[0].Length - 1 &&
				!nameParts[0].Equals("St.", StringComparison.OrdinalIgnoreCase))
			{
				if (!String.IsNullOrEmpty(result.Prefix))
				{
					result.Prefix += " " + nameParts[0];
				}
				else
				{
					result.Prefix = nameParts[0];
				}
				nameParts = nameParts.Skip(1).ToArray();
			}
			return nameParts;
		}

		private static string[] HandleNameSuffix(IList<string> sections, NameParts result, string[] nameParts)
		{
			if (new[] { ".", " II", " III", " IV", " Jr", " Sr", " V" }.Any(x => sections[0].EndsWith(x, StringComparison.OrdinalIgnoreCase)))
			{
				result.Suffix = nameParts.Last();
				nameParts = nameParts.Take(nameParts.Length - 1).ToArray();
			}
			else if (sections.Count > 1)
			{
				result.Suffix = String.Join(", ", sections.Skip(1).Select(x => x.Trim()));
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

		private static void HandleRunTogetherMiddleInitialAndSurname(NameParts result)
		{
			if (result.Surname != null && result.Surname.Length > 2 && result.Surname[1] == '.')
			{
				result.MiddleName = (result.MiddleName ?? "" + " " + result.Surname.Substring(0, 2)).Trim();
				result.Surname = result.Surname.Substring(2);
			}
		}

		private static void HandleSingleWordSurnamePrefix(NameParts result, ICollection<string> parts)
		{
			var indexOfPrefix = IndexOfAnyCaseInsensitive(parts, SingleWordNamePrefixes);
			if (indexOfPrefix != parts.Count - 1)
			{
				return;
			}

			result.Surname = parts.Last() + " " + result.Surname;
			result.MiddleName = parts.Count == 1 ? null : String.Join(" ", parts.Take(parts.Count - 1));
		}

		private static void HandleSingleWordSurnamePrefixGivenAMiddleNameExists(NameParts result, ICollection<string> parts)
		{
			if (parts.Count < 2)
			{
				return;
			}
			var indexOfPrefix = IndexOfAnyCaseInsensitive(parts, "o");
			if (indexOfPrefix != parts.Count - 1 ||
				result.Surname.StartsWith("o", StringComparison.OrdinalIgnoreCase))
			{
				return;
			}

			result.Surname = parts.Last() + " " + result.Surname;
			result.MiddleName = parts.Count == 1 ? null : String.Join(" ", parts.Take(parts.Count - 1));
		}

		private static int IndexOfAnyCaseInsensitive(this IEnumerable<string> items, params string[] values)
		{
			var index = 0;
			foreach (var item in items)
			{
				if (values.Any(x => x.Equals(item, StringComparison.OrdinalIgnoreCase)))
				{
					return index;
				}
				index++;
			}
			return -1;
		}

		private static int IndexOfAnyCaseInsensitive(this string item, params string[] values)
		{
			int? index = null;
			foreach (var value in values)
			{
				var valueIndex = item.IndexOf(value, StringComparison.OrdinalIgnoreCase);
				if (valueIndex == -1)
				{
					continue;
				}
				if (index == null || index.Value > valueIndex)
				{
					index = valueIndex;
				}
			}
			return index ?? -1;
		}

		private static int IndexOfCaseInsensitive(this IEnumerable<string> items, string value)
		{
			var index = 0;
			foreach (var item in items)
			{
				if (item.Equals(value, StringComparison.OrdinalIgnoreCase))
				{
					return index;
				}
				index++;
			}
			return -1;
		}

		private static bool IsDeXSurnamePrefix(ICollection<string> parts)
		{
			var indexOfDe = IndexOfCaseInsensitive(parts, "de");
			if (indexOfDe < 0 || indexOfDe != parts.Count - 2)
			{
				return false;
			}

			var lastLower = parts.Last().ToLower();
			if (!new[] { "la", "le", "los", "san", "st." }.Contains(lastLower))
			{
				return false;
			}
			return true;
		}

		private static bool IsTwoPartSurnamePrefix(ICollection<string> parts)
		{
			return IsDeXSurnamePrefix(parts) || IsVanXSurnamePrefix(parts);
		}

		private static bool IsVanXSurnamePrefix(ICollection<string> parts)
		{
			var indexOfDe = IndexOfCaseInsensitive(parts, "van");
			if (indexOfDe < 0 || indexOfDe != parts.Count - 2)
			{
				return false;
			}

			var lastLower = parts.Last().ToLower();
			if (!new[] { "de", "den", "der" }.Contains(lastLower))
			{
				return false;
			}
			return true;
		}

		private static string NameWithoutAliases(string name)
		{
			var index = name.IndexOfAnyCaseInsensitive(" aka ", " a/k/a ", " dba ", " d/b/a ", " fdba ", " fka ", " f/k/a ", " nka ", " n/k/a ");
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
				var end = name.IndexOf(')', index);
				if (end != -1)
				{
					name = name.Substring(0, index) + name.Substring(1+end);
				}
				else
				{
					name = name.Substring(0, index);
				}
			}
			return name.Trim();
		}

		public static NameParts ParseName(this string name)
		{
			var result = new NameParts();
			if (name == null)
			{
				return result;
			}
			name = name.Trim();
			if (String.IsNullOrEmpty(name))
			{
				return result;
			}
			name = NameWithoutAliases(name);

			name = name.Replace('\"', ' ');

			var sections = name.Split(',');
			var nameParts = sections.First().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

			nameParts = HandleNameSuffix(sections, result, nameParts);

			if (nameParts.Length > 1)
			{
				nameParts = HandleNamePrefix(nameParts, result);
				nameParts = HandleRunTogetherInitialsInGivenName(nameParts);
			}

			if (nameParts.Length > 1)
			{
				result.GivenName = nameParts.First();
				nameParts = nameParts.Skip(1).ToArray();
				nameParts = HandleMultiPartGivenName(result, nameParts);
			}

			if (nameParts.Length > 0)
			{
				result.Surname = nameParts.Last();
				if (nameParts.Length > 1)
				{
					result.MiddleName = String.Join(" ", nameParts.Take(nameParts.Length - 1).ToArray());
				}
			}

			HandleRunTogetherMiddleInitialAndSurname(result);
			HandleMultiPartSurname(result);

			return result;
		}
	}
}
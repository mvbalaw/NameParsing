using System;
using System.Collections.Generic;
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

			HandleSingleWordSurnamePrefix(result, parts);
			HandleSurnamePrefixDe(result, parts);
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

		private static string[] HandleNameSuffix(IList<string> sections, NameParts result, string[] nameParts)
		{
			if (sections[0].EndsWith("."))
			{
				result.Suffix = nameParts.Last();
				nameParts = nameParts.Take(nameParts.Length - 1).ToArray();
			}
			else if (sections.Count > 1)
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

		private static void HandleSingleWordSurnamePrefix(NameParts result, ICollection<string> parts)
		{
			var indexOfDela = IndexOfAnyCaseInsensitive(parts, "dela", "del", "mc", "van");
			if (indexOfDela != parts.Count - 1)
			{
				return;
			}

			result.Surname = parts.Last() + " " + result.Surname;
			result.MiddleName = parts.Count == 1 ? null : String.Join(" ", parts.Take(parts.Count - 1));
		}

		private static void HandleSurnamePrefixDe(NameParts result, ICollection<string> parts)
		{
			var indexOfDe = IndexOfCaseInsensitive(parts, "de");
			if (indexOfDe == -1 ||
				indexOfDe < parts.Count - 1 - 2)
			{
				return;
			}

			if (indexOfDe == parts.Count - 1)
			{
				result.Surname = parts.Last() + " " + result.Surname;
				result.MiddleName = parts.Count == 1 ? null : String.Join(" ", parts.Take(parts.Count - 1));
				return;
			}

			// indexOfDe == parts.Length - 2
			var lastLower = parts.Last().ToLower();
			if (!new[] { "la", "los" }.Contains(lastLower))
			{
				return;
			}

			result.Surname = String.Join(" ", parts.Skip(parts.Count - 2).Take(2)) + " " + result.Surname;
			result.MiddleName = parts.Count == 2 ? null : String.Join(" ", parts.Take(parts.Count - 2));
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
			return index == null ? -1 : index.Value;
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

		private static string NameWithoutAliases(string name)
		{
			var index = name.IndexOfAnyCaseInsensitive(" aka ", " a/k/a ", " dba ", " fdba ", " fka ", " f/k/a ");
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
			var nameParts = sections.First().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

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
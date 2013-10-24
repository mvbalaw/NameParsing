using System.Linq;

namespace NameParsing
{
	public static class StringExtensions
	{
		public static NameParts ParseName(this string name)
		{
			var parts = name.Split(' ');
			var nameParts = new NameParts
			                {
				                GivenName = parts.First(),
				                Surname = parts.Last()
			                };
			if (parts.Length == 3)
			{
				nameParts.MiddleName = parts.Skip(1).First();
			}
			return nameParts;
		}
	}
}
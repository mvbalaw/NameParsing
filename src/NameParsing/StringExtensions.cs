using System.Linq;

namespace NameParsing
{
	public static class StringExtensions
	{
		public static NameParts ParseName(this string name)
		{
			var parts = name.Split(' ');
			return new NameParts
			       {
				       GivenName = parts.First(),
				       Surname = parts.Last()
			       };
		}
	}
}
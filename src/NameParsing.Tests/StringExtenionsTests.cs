using FluentAssert;

using NUnit.Framework;

namespace NameParsing.Tests
{
// ReSharper disable once ClassNeverInstantiated.Global
	public class StringExtenionsTests
	{
		[TestFixture]
		public class When_asked_to_parse_a_name
		{
			[Test]
			public void Given__John_Smith__should_return_GivenName_John_Surname_Smith()
			{
				const string input = "John Smith";
				var result = input.ParseName();
				result.GivenName.ShouldBeEqualTo("John");
				result.Surname.ShouldBeEqualTo("Smith");
			}
		}
	}
}
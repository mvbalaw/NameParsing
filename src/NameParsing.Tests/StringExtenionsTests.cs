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
			public void Given__John_H_C_Smith__should_return_GivenName_John_MiddleName_H_C_Surname_Smith()
			{
				const string input = "John H C Smith";
				var result = input.ParseName();
				var expect = new NameParts
				             {
					             GivenName = "John",
					             MiddleName = "H C",
					             Surname = "Smith"
				             };
				Verify(result, expect);
			}

			[Test]
			public void Given__John_H_Smith__should_return_GivenName_John_MiddleName_H_Surname_Smith()
			{
				const string input = "John H Smith";
				var result = input.ParseName();
				var expect = new NameParts
				             {
					             GivenName = "John",
					             MiddleName = "H",
					             Surname = "Smith"
				             };
				Verify(result, expect);
			}

			[Test]
			public void Given__John_Smith_COMMA_Jr__should_return_GivenName_John_Surname_Smith_Suffix_Jr()
			{
				const string input = "John Smith, Jr";
				var result = input.ParseName();
				var expect = new NameParts
				             {
					             GivenName = "John",
					             Surname = "Smith",
					             Suffix = "Jr"
				             };
				Verify(result, expect);
			}

			[Test]
			public void Given__John_Smith_Jr_DOT__should_return_GivenName_John_Surname_Smith_Suffix_Jr_DOT()
			{
				const string input = "John Smith Jr.";
				var result = input.ParseName();
				var expect = new NameParts
				             {
					             GivenName = "John",
					             Surname = "Smith",
					             Suffix = "Jr."
				             };
				Verify(result, expect);
			}

			[Test]
			public void Given__John_Smith__should_return_GivenName_John_Surname_Smith()
			{
				const string input = "John Smith";
				var result = input.ParseName();
				var expect = new NameParts
				             {
					             GivenName = "John",
					             Surname = "Smith"
				             };
				Verify(result, expect);
			}

			[Test]
			public void Given__John_Smith_aka_John_Schmidt__should_return_GivenName_John_Surname_Smith()
			{
				const string input = "John Smith aka John Schmidt";
				var result = input.ParseName();
				var expect = new NameParts
				             {
					             GivenName = "John",
					             Surname = "Smith"
				             };
				Verify(result, expect);
			}

			private static void Verify(NameParts result, NameParts expected)
			{
				result.GivenName.ShouldBeEqualTo(expected.GivenName);
				result.MiddleName.ShouldBeEqualTo(expected.MiddleName);
				result.Surname.ShouldBeEqualTo(expected.Surname);
			}
		}
	}
}
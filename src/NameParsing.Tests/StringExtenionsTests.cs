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
			public void Given__JOHN_KAIDII__should_return_GivenName_JOHN_Surname_KAIDII()
			{
				const string input = "JOHN KAIDII";
				var result = input.ParseName();
				var expect = new NameParts
				             {
					             GivenName = "JOHN",
					             Surname = "KAIDII"
				             };
				Verify(result, expect);
			}

			[Test]
			public void Given__JOHN_SLODOV__should_return_GivenName_JOHN_Surname_SLODOV()
			{
				const string input = "JOHN SLODOV";
				var result = input.ParseName();
				var expect = new NameParts
				             {
					             GivenName = "JOHN",
					             Surname = "SLODOV"
				             };
				Verify(result, expect);
			}

			[Test]
			public void Given__JOHN_SMITH_JR__should_return_GivenName_JOHN_Surname_SMITH_Suffix_JR()
			{
				const string input = "JOHN SMITH JR";
				var result = input.ParseName();
				var expect = new NameParts
				             {
					             GivenName = "JOHN",
					             Surname = "SMITH",
					             Suffix = "JR"
				             };
				Verify(result, expect);
			}

			[Test]
			public void Given__JOHN_SULLIV__should_return_GivenName_JOHN_Surname_SULLIV()
			{
				const string input = "JOHN SULLIV";
				var result = input.ParseName();
				var expect = new NameParts
				             {
					             GivenName = "JOHN",
					             Surname = "SULLIV"
				             };
				Verify(result, expect);
			}

			[Test]
			public void Given__J_DOT_H_DOT_Smith__should_return_GivenName_J_DOT_MiddleName_H_DOT_Surname_Smith()
			{
				const string input = "J.H. Smith";
				var result = input.ParseName();
				var expect = new NameParts
				             {
					             GivenName = "J.",
					             MiddleName = "H.",
					             Surname = "Smith"
				             };
				Verify(result, expect);
			}

			[Test]
			public void Given__J_DOT_Smith__should_return_GivenName_J_DOT_Surname_Smith()
			{
				const string input = "J. Smith";
				var result = input.ParseName();
				var expect = new NameParts
				             {
					             GivenName = "J.",
					             Surname = "Smith"
				             };
				Verify(result, expect);
			}

			[Test]
			public void Given__John_Al_Sharif__should_return_GivenName_John_Surname_Al_Sharif()
			{
				const string input = "John Al Sharif";
				var result = input.ParseName();
				var expect = new NameParts
				             {
					             GivenName = "John",
					             Surname = "Al Sharif"
				             };
				Verify(result, expect);
			}

			[Test]
			public void Given__John_DeLa_Rosa__should_return_GivenName_John_Surname_DeLa_Rosa()
			{
				const string input = "John DeLa Rosa";
				var result = input.ParseName();
				var expect = new NameParts
				             {
					             GivenName = "John",
					             Surname = "DeLa Rosa"
				             };
				Verify(result, expect);
			}

			[Test]
			public void Given__John_De_Jesus_Reyes__should_return_GivenName_John_MiddleName_De_Jesus_Surname_Reyes()
			{
				const string input = "John De Jesus Reyes";
				var result = input.ParseName();
				var expect = new NameParts
				             {
					             GivenName = "John",
					             MiddleName = "De Jesus",
					             Surname = "Reyes"
				             };
				Verify(result, expect);
			}

			[Test]
			public void Given__John_De_La_Rosa__should_return_GivenName_John_Surname_De_La_Rosa()
			{
				const string input = "John De La Rosa";
				var result = input.ParseName();
				var expect = new NameParts
				             {
					             GivenName = "John",
					             Surname = "De La Rosa"
				             };
				Verify(result, expect);
			}

			[Test]
			public void Given__John_De_Le_Cerda__should_return_GivenName_John_Surname_De_Le_Cerda()
			{
				const string input = "John De Le Cerda";
				var result = input.ParseName();
				var expect = new NameParts
				             {
					             GivenName = "John",
					             Surname = "De Le Cerda"
				             };
				Verify(result, expect);
			}

			[Test]
			public void Given__John_De_Los_Santos__should_return_GivenName_John_Surname_De_Los_Santos()
			{
				const string input = "John De Los Santos";
				var result = input.ParseName();
				var expect = new NameParts
				             {
					             GivenName = "John",
					             Surname = "De Los Santos"
				             };
				Verify(result, expect);
			}

			[Test]
			public void Given__John_Du_Puis__should_return_GivenName_John_Surname_Du_Puis()
			{
				const string input = "John Du Puis";
				var result = input.ParseName();
				var expect = new NameParts
				             {
					             GivenName = "John",
					             Surname = "Du Puis"
				             };
				Verify(result, expect);
			}

			[Test]
			public void Given__John_El_Cid__should_return_GivenName_John_Surname_El_Cid()
			{
				const string input = "John El Cid";
				var result = input.ParseName();
				var expect = new NameParts
				             {
					             GivenName = "John",
					             Surname = "El Cid"
				             };
				Verify(result, expect);
			}

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
			public void Given__John_H_DOT_Smith__should_return_GivenName_John_MiddleName_H_DOT_Surname_Smith()
			{
				const string input = "John H.Smith"; // no space
				var result = input.ParseName();
				var expect = new NameParts
				             {
					             GivenName = "John",
					             MiddleName = "H.",
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
			public void Given__John_Henry_De_La_Rosa__should_return_GivenName_John_Surname_MiddleName_Henry_De_La_Rosa()
			{
				const string input = "John Henry De La Rosa";
				var result = input.ParseName();
				var expect = new NameParts
				             {
					             GivenName = "John",
					             MiddleName = "Henry",
					             Surname = "De La Rosa"
				             };
				Verify(result, expect);
			}

			[Test]
			public void Given__John_La_Grange__should_return_GivenName_John_Surname_La_Grange()
			{
				const string input = "John La Grange";
				var result = input.ParseName();
				var expect = new NameParts
				             {
					             GivenName = "John",
					             Surname = "La Grange"
				             };
				Verify(result, expect);
			}

			[Test]
			public void Given__John_Mac_Hugh__should_return_GivenName_John_Surname_Mac_Hugh()
			{
				const string input = "John Mac Hugh";
				var result = input.ParseName();
				var expect = new NameParts
				             {
					             GivenName = "John",
					             Surname = "Mac Hugh"
				             };
				Verify(result, expect);
			}

			[Test]
			public void Given__John_Mc_Smith__should_return_GivenName_John_Surname_Mc_Smith()
			{
				const string input = "John Mc Smith";
				var result = input.ParseName();
				var expect = new NameParts
				             {
					             GivenName = "John",
					             Surname = "Mc Smith"
				             };
				Verify(result, expect);
			}

			[Test]
			public void Given__John_SPACE_SPACE_H_Smith__should_return_GivenName_John_MiddleName_H_Surname_Smith()
			{
				const string input = "John  H Smith";
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
			public void Given__John_San_Angelo__should_return_GivenName_John_Surname_San_Angelo()
			{
				const string input = "John San Angelo";
				var result = input.ParseName();
				var expect = new NameParts
				             {
					             GivenName = "John",
					             Surname = "San Angelo"
				             };
				Verify(result, expect);
			}

			[Test]
			public void Given__John_Smijr__should_return_GivenName_John_Surname_Smijr()
			{
				const string input = "John Smijr";
				var result = input.ParseName();
				var expect = new NameParts
				             {
					             GivenName = "John",
					             Surname = "Smijr"
				             };
				Verify(result, expect);
			}

			[Test]
			public void Given__John_Smisr__should_return_GivenName_John_Surname_Smisr()
			{
				const string input = "John Smisr";
				var result = input.ParseName();
				var expect = new NameParts
				             {
					             GivenName = "John",
					             Surname = "Smisr"
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
			public void Given__John_Smith_COMMA_MD_COMMA_PA__should_return_GivenName_John_Surname_Smith_Suffix_MD_COMMA_PA()
			{
				const string input = "John Smith, MD, PA";
				var result = input.ParseName();
				var expect = new NameParts
				             {
					             GivenName = "John",
					             Surname = "Smith",
					             Suffix = "MD, PA"
				             };
				Verify(result, expect);
			}

			[Test]
			public void Given__John_Smith_III__should_return_GivenName_John_Surname_Smith_Suffix_III()
			{
				const string input = "John Smith III";
				var result = input.ParseName();
				var expect = new NameParts
				             {
					             GivenName = "John",
					             Surname = "Smith",
					             Suffix = "III"
				             };
				Verify(result, expect);
			}

			[Test]
			public void Given__John_Smith_II__should_return_GivenName_John_Surname_Smith_Suffix_II()
			{
				const string input = "John Smith II";
				var result = input.ParseName();
				var expect = new NameParts
				             {
					             GivenName = "John",
					             Surname = "Smith",
					             Suffix = "II"
				             };
				Verify(result, expect);
			}

			[Test]
			public void Given__John_Smith_IV__should_return_GivenName_John_Surname_Smith_Suffix_IV()
			{
				const string input = "John Smith IV";
				var result = input.ParseName();
				var expect = new NameParts
				             {
					             GivenName = "John",
					             Surname = "Smith",
					             Suffix = "IV"
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
			public void Given__John_Smith_Jr__should_return_GivenName_John_Surname_Smith_Suffix_Jr()
			{
				const string input = "John Smith Jr";
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
			public void Given__John_Smith_LPAREN_John_Schmidt_RPAREN__should_return_GivenName_John_Surname_Smith()
			{
				const string input = "John Smith (John Schmidt)";
				var result = input.ParseName();
				var expect = new NameParts
				             {
					             GivenName = "John",
					             Surname = "Smith"
				             };
				Verify(result, expect);
			}

			[Test]
			public void Given__John_Smith_Sr__should_return_GivenName_John_Surname_Smith_Suffix_Sr()
			{
				const string input = "John Smith Sr";
				var result = input.ParseName();
				var expect = new NameParts
				             {
					             GivenName = "John",
					             Surname = "Smith",
					             Suffix = "Sr"
				             };
				Verify(result, expect);
			}

			[Test]
			public void Given__John_Smith_V__should_return_GivenName_John_Surname_Smith_Suffix_V()
			{
				const string input = "John Smith V";
				var result = input.ParseName();
				var expect = new NameParts
				             {
					             GivenName = "John",
					             Surname = "Smith",
					             Suffix = "V"
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
			public void Given__John_Smith_a_SLASH_k_SLASH_a_John_Schmidt__should_return_GivenName_John_Surname_Smith()
			{
				const string input = "John Smith a/k/a John Schmidt";
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

			[Test]
			public void Given__John_Smith_d_SLASH_b_SLASH_a_John_Schmidt__should_return_GivenName_John_Surname_Smith()
			{
				const string input = "John Smith d/b/a John Schmidt";
				var result = input.ParseName();
				var expect = new NameParts
				             {
					             GivenName = "John",
					             Surname = "Smith"
				             };
				Verify(result, expect);
			}

			[Test]
			public void Given__John_Smith_dba_John_Schmidt__should_return_GivenName_John_Surname_Smith()
			{
				const string input = "John Smith dba John Schmidt";
				var result = input.ParseName();
				var expect = new NameParts
				             {
					             GivenName = "John",
					             Surname = "Smith"
				             };
				Verify(result, expect);
			}

			[Test]
			public void Given__John_Smith_f_SLASH_k_SLASH_a_John_Schmidt__should_return_GivenName_John_Surname_Smith()
			{
				const string input = "John Smith f/k/a John Schmidt";
				var result = input.ParseName();
				var expect = new NameParts
				             {
					             GivenName = "John",
					             Surname = "Smith"
				             };
				Verify(result, expect);
			}

			[Test]
			public void Given__John_Smith_fdba_John_Schmidt__should_return_GivenName_John_Surname_Smith()
			{
				const string input = "John Smith fdba John Schmidt";
				var result = input.ParseName();
				var expect = new NameParts
				             {
					             GivenName = "John",
					             Surname = "Smith"
				             };
				Verify(result, expect);
			}

			[Test]
			public void Given__John_Smith_fka_John_Schmidt__should_return_GivenName_John_Surname_Smith()
			{
				const string input = "John Smith fka John Schmidt";
				var result = input.ParseName();
				var expect = new NameParts
				             {
					             GivenName = "John",
					             Surname = "Smith"
				             };
				Verify(result, expect);
			}

			[Test]
			public void Given__John_Smith_n_SLASH_k_SLASH_a_John_Schmidt__should_return_GivenName_John_Surname_Smith()
			{
				const string input = "John Smith n/k/a John Schmidt";
				var result = input.ParseName();
				var expect = new NameParts
				             {
					             GivenName = "John",
					             Surname = "Smith"
				             };
				Verify(result, expect);
			}

			[Test]
			public void Given__John_Smith_nka_John_Schmidt__should_return_GivenName_John_Surname_Smith()
			{
				const string input = "John Smith nka John Schmidt";
				var result = input.ParseName();
				var expect = new NameParts
				             {
					             GivenName = "John",
					             Surname = "Smith"
				             };
				Verify(result, expect);
			}

			[Test]
			public void Given__John_Smith_or_John_Schmidt__should_return_GivenName_John_Surname_Smith()
			{
				const string input = "John Smith or John Schmidt";
				var result = input.ParseName();
				var expect = new NameParts
				             {
					             GivenName = "John",
					             Surname = "Smith"
				             };
				Verify(result, expect);
			}

			[Test]
			public void Given__John_St_DOT_Smith__should_return_GivenName_John_Surname_St_DOT_Smith()
			{
				const string input = "John St. Smith";
				var result = input.ParseName();
				var expect = new NameParts
				             {
					             GivenName = "John",
					             Surname = "St. Smith"
				             };
				Verify(result, expect);
			}

			[Test]
			public void Given__John_St_Smith__should_return_GivenName_John_Surname_St_Smith()
			{
				const string input = "John St Smith";
				var result = input.ParseName();
				var expect = new NameParts
				             {
					             GivenName = "John",
					             Surname = "St Smith"
				             };
				Verify(result, expect);
			}

			[Test]
			public void Given__John_Van_Der_Sharp__should_return_GivenName_John_Surname_Van_Der_Sharp()
			{
				const string input = "John Van Der Sharp";
				var result = input.ParseName();
				var expect = new NameParts
				             {
					             GivenName = "John",
					             Surname = "Van Der Sharp"
				             };
				Verify(result, expect);
			}

			[Test]
			public void Given__John_de_Jesus__should_return_GivenName_John_Surname_de_Jesus()
			{
				const string input = "John de Jesus";
				var result = input.ParseName();
				var expect = new NameParts
				             {
					             GivenName = "John",
					             Surname = "de Jesus"
				             };
				Verify(result, expect);
			}

			[Test]
			public void Given__John_de_St_DOT_Felix__should_return_GivenName_John_Surname_de_St_DOT_Felix()
			{
				const string input = "John de St. Felix";
				var result = input.ParseName();
				var expect = new NameParts
				             {
					             GivenName = "John",
					             Surname = "de St. Felix"
				             };
				Verify(result, expect);
			}

			[Test]
			public void Given__John_del_Toro__should_return_GivenName_John_Surname_Del_Toro()
			{
				const string input = "John del Toro";
				var result = input.ParseName();
				var expect = new NameParts
				             {
					             GivenName = "John",
					             Surname = "del Toro"
				             };
				Verify(result, expect);
			}

			[Test]
			public void Given__John_le_Toro__should_return_GivenName_John_Surname_Le_Toro()
			{
				const string input = "John Le Toro";
				var result = input.ParseName();
				var expect = new NameParts
				             {
					             GivenName = "John",
					             Surname = "Le Toro"
				             };
				Verify(result, expect);
			}

			[Test]
			public void Given__John_van_de_Smith__should_return_GivenName_John_Surname_van_de_Smith()
			{
				const string input = "John van de Smith";
				var result = input.ParseName();
				var expect = new NameParts
				             {
					             GivenName = "John",
					             Surname = "van de Smith"
				             };
				Verify(result, expect);
			}

			[Test]
			public void Given__John_von_Smith__should_return_GivenName_John_Surname_von_Smith()
			{
				const string input = "John von Smith";
				var result = input.ParseName();
				var expect = new NameParts
				             {
					             GivenName = "John",
					             Surname = "von Smith"
				             };
				Verify(result, expect);
			}

			[Test]
			public void Given__Mr_DOT_J_DOT_H_DOT_Smith__should_return_Prefix_Mr_DOT_GivenName_J_DOT_MiddleName_H_DOT_Surname_Smith()
			{
				const string input = "Mr. J.H. Smith";
				var result = input.ParseName();
				var expect = new NameParts
				             {
					             Prefix = "Mr.",
					             GivenName = "J.",
					             MiddleName = "H.",
					             Surname = "Smith"
				             };
				Verify(result, expect);
			}

			[Test]
			public void Given__Mr_DOT_John_Smith__should_return_Prefix_Mr_DOT_GivenName_John_Surname_Smith()
			{
				const string input = "Mr. John Smith";
				var result = input.ParseName();
				var expect = new NameParts
				             {
					             Prefix = "Mr.",
					             GivenName = "John",
					             Surname = "Smith"
				             };
				Verify(result, expect);
			}

			[Test]
			public void Given__Mr_DOT_Smith__should_return_Prefix_Mr_DOT_Surname_Smith()
			{
				const string input = "Mr. Smith";
				var result = input.ParseName();
				var expect = new NameParts
				             {
					             Prefix = "Mr.",
					             Surname = "Smith"
				             };
				Verify(result, expect);
			}

			[Test]
			public void Given__St_DOT_John_Smith__should_return_GivenName_St_DOT_John_Surname_Smith()
			{
				const string input = "St. John Smith";
				var result = input.ParseName();
				var expect = new NameParts
				             {
					             GivenName = "St. John",
					             Surname = "Smith"
				             };
				Verify(result, expect);
			}

			private static void Verify(NameParts result, NameParts expected)
			{
				result.Prefix.ShouldBeEqualTo(expected.Prefix);
				result.GivenName.ShouldBeEqualTo(expected.GivenName);
				result.MiddleName.ShouldBeEqualTo(expected.MiddleName);
				result.Surname.ShouldBeEqualTo(expected.Surname);
				result.Suffix.ShouldBeEqualTo(expected.Suffix);
			}
		}
	}
}
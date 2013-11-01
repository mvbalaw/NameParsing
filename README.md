NameParsing
===
### Description

A library for structurally splitting single field name data into multiple fields 
(prefix, given, middle, surname, and suffix)

   Most name parts are determined by markers (".", ",")
   
   Surnames with prefixes are supported 
   
      "de", "de la", "de los", "von", etc
	  
   Some special cases are handled positionally 
   
      suffixes without comma: II, III, etc
      split surname: Mc Cormick
      split given name: St. John
	  
   When name variation acronyms are detected, only the first name variation is parsed
   
      acronyms include: aka, fka, dba, nka, a/k/a
   
### Examples

   Mr. Smith
   
      Prefix: Mr.
      Surname: Smith
   
   Dr. John Henry William de la Vega, Jr., Esq.
   
      Prefix: Dr.
	  GivenName: John
	  MiddleName: Henry William
	  Surname: de la Vega
	  Suffix: Jr., Esq.

   John Smith d/b/a John's Tools

      GivenName: John
	  Surname: Smith
	  
### How To Build:

The build script requires Ruby with rake installed.

1. Run `InstallGems.bat` to get the ruby dependencies (only needs to be run once per computer)
1. open a command prompt to the root folder and type `rake` to execute rakefile.rb

If you do not have ruby:

1. You need to create a src\CommonAssemblyInfo.cs file. Go.bat will copy src\CommonAssemblyInfo.cs.default to src\CommonAssemblyInfo.cs
1. open src\NameParsing.sln with Visual Studio and build the solution

### License

[MIT License][mitlicense]

This project is part of [MVBA's Open Source Projects][MvbaLawGithub].

If you have questions or comments about this project, please contact us at <mailto:opensource@mvbalaw.com>

[MvbaLawGithub]: http://mvbalaw.github.io/
[mitlicense]: http://www.opensource.org/licenses/mit-license.php

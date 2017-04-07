using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using HtmlTags;

namespace CiteThisShit.MacLib
{
	public class HtmlStringGenerator
	{
		public async Task<string> QueryDoiReference(string doiQuery, string oldHtml = "")
		{
			var queryControl = new QueryControl();
			var queryResult = await queryControl.QueryDoiResult(doiQuery);

			string authorNames = string.Empty;

			for (int authorSequence = 0; authorSequence < queryResult.Message.Author.Count; authorSequence++)
			{
				var currentAuthor = queryResult.Message.Author[authorSequence];
				string authorSurname = currentAuthor.Family;
				string authorGivenname = FilterUpperCaseString(currentAuthor.Given);

				// Three cases, 
				//    1. the first one should be directly appended
				//    2. the second one until the last one should be appended with a comma
				//    3. the last one should be appended with "&" symbol
				if (authorSequence == 0)
				{
					authorNames += string.Format("{0}, {1}", authorSurname, authorGivenname);
				}
				else if (authorSequence == (queryResult.Message.Author.Count - 1))
				{
					authorNames += string.Format(" & {0}, {1}", authorSurname, authorGivenname);
				}
				else
				{
					authorNames += string.Format(", {0}, {1}", authorSurname, authorGivenname);
				}

			}

			// FINAL MERGE LOL!!!
			string doiHarvardRefString = string.Format(
				"{0} " +        // Name(s)
				"{1}," +        // Publish year
				"\'{2}\', " +   // Paper title
				"{3}, " +       // Paper's database or publisher
				"vol. {4}, " +  // Volume number
				"no. {5}, " +   // Issue number
				"pp. {6}, " +   // Page number
				"doi: {7}",     // DOI serial number
				authorNames,
				queryResult.Message.Issued.DateParts[0][0].ToString(), // The first element is the year
				queryResult.Message.Title[0],
				queryResult.Message.Publisher,
				queryResult.Message.Volume,
				queryResult.Message.Issue,
				queryResult.Message.Page,
				queryResult.Message.Doi
				);

			return doiHarvardRefString;

		}

		// Filter all upper case string, get all given name initial with upper case letter.
		// e.g. Foo Bar Baz -> FBB
		private string FilterUpperCaseString(string inputString)
		{
			string upperCaseLetters = string.Empty;

			foreach (char singleChar in inputString.ToCharArray())
			{
				if (string.Equals(singleChar.ToString().ToUpper(), singleChar.ToString()))
					upperCaseLetters += singleChar;
			}

			return upperCaseLetters;
		}
	}
}

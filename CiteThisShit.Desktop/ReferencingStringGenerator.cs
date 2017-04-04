using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Documents;
using System.Threading.Tasks;
using CiteThisShit.Data;
using CiteThisShit.NetStandard;
using System.Text.RegularExpressions;

namespace CiteThisShit.Desktop
{
    public class ReferencingStringGenerator
    {
        public async Task<Paragraph> GenerateDoiString(string doiString)
        {
            var queryControl = new QueryControl();
            var queryResult = await queryControl.QueryDoiResult(doiString);

            string authorNames = string.Empty;

            for(int authorSequence = 0; authorSequence < queryResult.Message.Author.Count; authorSequence++)
            {
                var currentAuthor = queryResult.Message.Author[authorSequence];
                string authorSurname = currentAuthor.Family;
                string authorGivenname = FilterUpperCaseString(currentAuthor.Given);

                // Three cases, 
                //    1. the first one should be directly appended
                //    2. the second one until the last one should be appended with a comma
                //    3. the last one should be appended with "&" symbol
                if(authorSequence == 0)
                {
                    authorNames += string.Format("{0}, {1}", authorSurname, authorGivenname);
                }
                else if(authorSequence  == (queryResult.Message.Author.Count - 1))
                {
                    authorNames += string.Format(" & {0}, {1}", authorSurname, authorGivenname);
                }
                else
                {
                    authorNames += string.Format(", {0}, {1}", authorSurname, authorGivenname);
                }

            }
            

            // Merge to paragraph with formatting
            var doiParagraph = new Paragraph();

            // Author names
            doiParagraph.Inlines.Add(new Run(string.Format("{0} ", authorNames)));

            // Publish year
            doiParagraph.Inlines.Add(new Run(string.Format("{0}, ", queryResult.Message.Issued.DateParts[0][0].ToString())));

            // Title
            doiParagraph.Inlines.Add(new Run(string.Format("\'{0}\', ", queryResult.Message.Title[0])));

            // Database or publisher (Italic format)
            doiParagraph.Inlines.Add(new Italic(new Run(string.Format("{0}, ", queryResult.Message.Publisher))));

            // Volume number
            doiParagraph.Inlines.Add(new Run(string.Format("vol. {0}, ", queryResult.Message.Volume)));

            // Issue number
            doiParagraph.Inlines.Add(new Run(string.Format("no. {0}, ", queryResult.Message.Issue)));

            // Page range
            doiParagraph.Inlines.Add(new Run(string.Format("pp. {0}, ", queryResult.Message.Page)));

            // Finally, DOI number
            doiParagraph.Inlines.Add(new Run(string.Format("doi: {0}.", queryResult.Message.Doi)));

            return doiParagraph;
        }

        public async Task<Paragraph> GenerateIsbnString(string bookIsbn)
        {
            var queryControl = new QueryControl();
            var queryResult = await queryControl.QueryOpenLibraryIsbnResult(bookIsbn);

            string authorNames = string.Empty;

            for (int authorSequence = 0; authorSequence < queryResult.Details.Authors.Count; authorSequence++)
            {
                string[] currentAuthor = queryResult.Details.Authors[authorSequence].Name.Split(' ');
                string authorSurname = currentAuthor[currentAuthor.Length - 1];
                string authorGivenname = string.Empty;

                for(int givenNameIndex = 0; givenNameIndex < (currentAuthor.Length - 1); givenNameIndex++)
                {
                    authorGivenname += string.Format("{0} ", currentAuthor[givenNameIndex]);
                }

                authorGivenname = FilterUpperCaseString(authorGivenname);

                // Three cases, 
                //    1. the first one should be directly appended
                //    2. the second one until the last one should be appended with a comma
                //    3. the last one should be appended with "&" symbol
                if (authorSequence == 0)
                {
                    authorNames += string.Format("{0}, {1}", authorSurname, authorGivenname);
                }
                else if (authorSequence == (queryResult.Details.Authors.Count - 1))
                {
                    authorNames += string.Format(" & {0}, {1}", authorSurname, authorGivenname);
                }
                else
                {
                    authorNames += string.Format(", {0}, {1}", authorSurname, authorGivenname);
                }

            }


            // Merge to paragraph with formatting
            var doiParagraph = new Paragraph();

            // Author names
            doiParagraph.Inlines.Add(new Run(string.Format("{0} ", authorNames)));

            // Publish year
            doiParagraph.Inlines.Add(new Run(string.Format("{0}, ", Regex.Match(queryResult.Details.PublishDate, @"\d+").Value)));

            // Title
            doiParagraph.Inlines.Add(new Italic(new Run(string.Format("{0}, ", queryResult.Details.Title))));

            // Revision
            doiParagraph.Inlines.Add(new Run(string.Format("{0}th edn, ", queryResult.Details.Revision.ToString())));

            // Publisher (get the first one only)
            doiParagraph.Inlines.Add(new Run(string.Format("{0}, ", queryResult.Details.Publishers[0])));

            // Publish Location
            doiParagraph.Inlines.Add(new Run(string.Format("{0}", queryResult.Details.PublishPlaces[0].Split(',')[1])));

            return doiParagraph;
        }

        // Filter all upper case string, get all given name initial with upper case letter.
        // e.g. Foo Bar Baz -> FBB
        private string FilterUpperCaseString(string inputString)
        {
            string upperCaseLetters = string.Empty;

            foreach (char singleChar in inputString.ToCharArray())
            {
                if(string.Equals(singleChar.ToString().ToUpper(), singleChar.ToString()))
                upperCaseLetters += singleChar;
            }

            return upperCaseLetters;
        }
    }
}

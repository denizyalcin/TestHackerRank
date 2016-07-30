using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LinkExtractionRegex
{
    class Program
    {
        static void Main(string[] args)
        {
            //string line = Console.ReadLine();

            string line = "";
            int lineCount = 0;

            System.IO.StreamReader file = null;
            try
            {
                file = new System.IO.StreamReader(@"..\..\TestData\test4.txt");
            }
            catch (Exception)
            {
                Console.WriteLine("File not found!");
                throw new Exception();
            }

            if ((line = file.ReadLine()) == null)
            {
                Console.WriteLine("Invalid file");
                return;
            }

            if (!int.TryParse(line, out lineCount) || lineCount < 1)
            {
                Console.WriteLine("Invalid first line");
                return;
            }

            for (int i = 0; i < lineCount; i++)
            {
                line = file.ReadLine();

                if (line == null)
                {
                    Console.WriteLine("Invalid line - line number : " + (i + 1));
                    return;
                }

                //find a tag and get outer html
                Regex rex = new Regex(RegexLib.Tag);

                Match match = rex.Match(line);

                while (match.Success)
                {
                    string matchString = match.Value;

                    // a tag find href inner text
                    Regex findHref = new Regex(RegexLib.ATagWithHref);

                    // find tags in match
                    Regex removeTags = new Regex(RegexLib.Tag);

                    string href = findHref.Match(matchString).Success ? findHref.Match(matchString).Groups[1].Value : "";
                    string contentText = removeTags.Replace(matchString, "");

                    //Trim results
                    href = string.IsNullOrEmpty(href) ? "" : href.Trim();
                    contentText = string.IsNullOrEmpty(contentText) ? "" : contentText.Trim();

                    Console.WriteLine(href + "," + contentText);

                    //search same line
                    line = line.Replace(matchString, "");
                    match = rex.Match(line);
                }
            }
            file.Close();

            Console.ReadLine();
            return;
        }
    }
}

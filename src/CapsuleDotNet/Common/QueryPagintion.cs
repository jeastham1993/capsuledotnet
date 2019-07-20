using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CapsuleDotNet.Common{
    public class QueryPagination{

        public void Parse(IEnumerable<string> linkHeader){

            foreach (string linkString in linkHeader)
            {
                var relMatch = Regex.Match(linkString, "(?<=rel=\").+?(?=\")", RegexOptions.IgnoreCase);
                var linkMatch = Regex.Match(linkString, "(?<=<).+?(?=>)", RegexOptions.IgnoreCase);

                if (relMatch.Success && linkMatch.Success)
                {
                    string rel = relMatch.Value.ToUpper();
                    string link = linkMatch.Value;

                    switch (rel)
                    {
                        case "FIRST":
                            this.FirstLink = link;
                            break;
                        case "PREV":
                            this.PrevLink = link;
                            break;
                        case "NEXT":
                            this.NextLink = link;
                            break;
                        case "LAST":
                            this.LastLink = link;
                            break;
                    }
                }
            }
        }
        public string NextLink { get; set; }

        public string PrevLink { get; set; }

        public string FirstLink { get; set; }
        
        public string LastLink { get; set; }
    }
}
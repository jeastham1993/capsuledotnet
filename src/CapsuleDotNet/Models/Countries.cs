using System.Linq;

namespace CapsuleDotNet.Models{
    internal static class Countries{
        internal static IQueryable<string> CountryList;
    }

    internal class CountryWrapper{
        public Country[] Countries {get;set;}
    }

    internal class Country
    {
        public string Name { get; set; }
    }
}
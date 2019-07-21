namespace CapsuleDotNet.Models
{
    public enum PartyType
    {
        PERSON,
        ORGANISATION
    }

    public static class PartyTypeExtensions
    {
        public static string ToFriendlyString(this PartyType me)
        {
            switch (me)
            {
                case PartyType.PERSON:
                    return "person";
                case PartyType.ORGANISATION:
                    return "organisation";
                default:
                    return "";
            }
        }
    }
}
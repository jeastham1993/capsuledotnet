namespace CapsuleDotNet.Common{
    public enum Embed{
        Tags,
        Fields,
        Organisation
    }

    public static class EmbedExtensions
    {
        public static string ToFriendlyString(this Embed me)
        {
            switch (me)
            {
                case Embed.Fields:
                    return "fields";
                case Embed.Organisation:
                    return "organisation";
                case Embed.Tags:
                    return "tags";
                default:
                    return "";
            }
        }
    }
}
namespace CapsuleDotNet.Common{
    public enum WebsiteType{
        Home,
        Work
    }

    public static class WebsiteTypeExtensions
    {
        public static string ToFriendlyString(this WebsiteType me)
        {
            switch (me)
            {
                case WebsiteType.Home:
                    return "home";
                case WebsiteType.Work:
                    return "work";
                default:
                    return "";
            }
        }
    }
}
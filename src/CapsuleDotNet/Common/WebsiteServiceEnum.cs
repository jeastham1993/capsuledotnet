namespace CapsuleDotNet.Common
{
    public enum WebsiteService
    {
        URL,
        SKYPE,
        TWITTER,
        LINKED_IN,
        FACEBOOK,
        XING,
        FEED,
        GOOGLE_PLUS,
        FLICKR,
        GITHUB,
        YOUTUBE,
        INSTAGRAM,
        PINTEREST
    }

    public static class WebsiteServiceExtensions
    {
        public static string ToFriendlyString(this WebsiteService me)
        {
            switch (me)
            {
                case WebsiteService.FACEBOOK:
                    return "facebook";
                case WebsiteService.FEED:
                    return "feed";
                case WebsiteService.FLICKR:
                    return "flickr";
                case WebsiteService.GITHUB:
                    return "github";
                case WebsiteService.GOOGLE_PLUS:
                    return "google_plus";
                case WebsiteService.INSTAGRAM:
                    return "instagram";
                case WebsiteService.LINKED_IN:
                    return "linked_in";
                case WebsiteService.PINTEREST:
                    return "pinterest";
                case WebsiteService.SKYPE:
                    return "skype";
                case WebsiteService.TWITTER:
                    return "twitter";
                case WebsiteService.URL:
                    return "url";
                case WebsiteService.XING:
                    return "xing";
                case WebsiteService.YOUTUBE:
                    return "youtube";
                default:
                    return "";
            }
        }
    }
}
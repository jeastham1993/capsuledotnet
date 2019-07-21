namespace CapsuleDotNet.Models{
    public enum Locale { en_US, en_GB }

    public static class LocaleExtensions
    {
        public static string ToFriendlyString(this Locale me)
        {
            switch (me)
            {
                case Locale.en_US:
                    return "en_us";
                case Locale.en_GB:
                    return "en_gb";
                default:
                    return "";
            }
        }
    }
}
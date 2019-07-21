namespace CapsuleDotNet.Models{
    public enum EmailPreference { GMAIL }

    public static class EmailPreferenceExtensions
    {
        public static string ToFriendlyString(this EmailPreference me)
        {
            switch (me)
            {
                case EmailPreference.GMAIL:
                    return "gmail";
                default:
                    return "";
            }
        }
    }
}
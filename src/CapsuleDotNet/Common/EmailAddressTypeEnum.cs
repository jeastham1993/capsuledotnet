namespace CapsuleDotNet.Common{
    public enum EmailAddressType{
        Home,
        Work
    }

    public static class EmailAddressTypeExtensions
    {
        public static string ToFriendlyString(this EmailAddressType me)
        {
            switch (me)
            {
                case EmailAddressType.Home:
                    return "home";
                case EmailAddressType.Work:
                    return "work";
                default:
                    return "";
            }
        }
    }
}
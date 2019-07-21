namespace CapsuleDotNet.Common{
    public enum AddressType{
        Home,
        Postal,
        Office
    }

    public static class AddressTypeExtensions
    {
        public static string ToFriendlyString(this AddressType me)
        {
            switch (me)
            {
                case AddressType.Home:
                    return "home";
                case AddressType.Office:
                    return "office";
                case AddressType.Postal:
                    return "postal";
                default:
                    return "";
            }
        }
    }
}
namespace CapsuleDotNet.Common{
    public enum PhoneNumberType{
        Home,
        Work,
        Mobile,
        Fax,
        Direct
    }

    public static class PhoneNumberTypeExtensions
    {
        public static string ToFriendlyString(this PhoneNumberType me)
        {
            switch (me)
            {
                case PhoneNumberType.Direct:
                    return "direct";
                case PhoneNumberType.Fax:
                    return "fax";
                case PhoneNumberType.Home:
                    return "home";
                case PhoneNumberType.Mobile:
                    return "mobile";
                case PhoneNumberType.Work:
                    return "work";
                default:
                    return "";
            }
        }
    }
}
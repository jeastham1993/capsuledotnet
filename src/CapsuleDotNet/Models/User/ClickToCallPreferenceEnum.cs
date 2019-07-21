namespace CapsuleDotNet.Models{
    public enum ClickToCallPreference { SIP, TEL, CALLTO, CIRCLELOOP }

    public static class ClickToCallPreferenceExtensions
    {
        public static string ToFriendlyString(this ClickToCallPreference me)
        {
            switch (me)
            {
                case ClickToCallPreference.CALLTO:
                    return "callto";
                case ClickToCallPreference.CIRCLELOOP:
                    return "circleloop";
                case ClickToCallPreference.SIP:
                    return "sip";
                case ClickToCallPreference.TEL:
                    return "tel";
                default:
                    return "";
            }
        }
    }
}
namespace CapsuleDotNet.Models{
    public enum ParticipantRole
    {
        TO,
        CC,
        FROM
    }

    public static class ParticipantRoleExtensions
    {
        public static string ToFriendlyString(this ParticipantRole me)
        {
            switch (me)
            {
                case ParticipantRole.TO:
                    return "to";
                case ParticipantRole.CC:
                    return "cc";
                case ParticipantRole.FROM:
                    return "from";
                default:
                    return "";
            }
        }
    }
}
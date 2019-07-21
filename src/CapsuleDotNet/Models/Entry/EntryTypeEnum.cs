namespace CapsuleDotNet.Models{
    public enum EntryType { NOTE, EMAIL, TASK }

    public static class EntryTypeExtensions
    {
        public static string ToFriendlyString(this EntryType me)
        {
            switch (me)
            {
                case EntryType.EMAIL:
                    return "email";
                case EntryType.NOTE:
                    return "note";
                case EntryType.TASK:
                    return "task";
                default:
                    return "";
            }
        }
    }
}
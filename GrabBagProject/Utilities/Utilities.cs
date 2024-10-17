namespace GrabBagProject.Utilities
{
    internal static class Utilities
    {
        public static bool CompareStrings(string str1, string str2)
        {
            return string.Equals(str1, str2, StringComparison.OrdinalIgnoreCase);
        }
    }
}

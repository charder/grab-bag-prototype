using GrabBagProject.Models.Items;
using GrabBagProject.Models.Modifiers;

namespace GrabBagProject.Utilities
{
    internal static class Utils
    {
        public static bool CompareStrings(string str1, string str2)
        {
            return string.Equals(str1, str2, StringComparison.OrdinalIgnoreCase);
        }

        public static T? FindModifier<T>(ICollection<Modifier> modifiers) where T : Modifier
        {
            return (T?)modifiers.FirstOrDefault(m => m is T);
        }
    }
}

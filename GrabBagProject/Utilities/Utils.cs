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

        public static T? FindModifier<T>(ICollection<Modifier>? modifiers) where T : Modifier
        {
            return (T?)modifiers?.FirstOrDefault(m => m is T);
        }

        public static ICollection<T> GetRandomFromCollection<T>(ICollection<T> collection, int count = 1) where T : class
        {
            List<T> results = new();
            Random random = new Random();
            count = Math.Min(count, collection.Count);

            for(int i = 0; i < count; i++)
            {
                T element = collection.ElementAt(random.Next(collection.Count));
                collection.Remove(element);
                results.Add(element);
            }

            foreach (var element in results)
                collection.Add(element);

            return results;
        }
    }
}

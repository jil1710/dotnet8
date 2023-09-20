using System.Collections.ObjectModel;

namespace FrozenDictionaryType
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
                new dictionary type which improves the performance of read operations.
                you are not allowed to make any changes to the keys and values once the collection is created.
             */

            FrozenDictionaryType frozenDictionaryType = new FrozenDictionaryType();

            Console.WriteLine(frozenDictionaryType.GetValue("key1"));

            Console.ReadKey();
        }
    }
}

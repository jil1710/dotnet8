using System.Security.Cryptography;
using System.Text.Json;

namespace RandomImprovements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>() { "one","two","three","four","five"};

            var readOnlyString = new ReadOnlySpan<string>(list.ToArray());
            // This will give me random value from string here i passing 1 it give 1 ramdom value if i pass 2 then two random value and so on..
            var getRandomValueFromList = RandomNumberGenerator.GetItems(readOnlyString,1);

            Console.WriteLine(JsonSerializer.Serialize(getRandomValueFromList));

            // Second feature
            var span = new Span<string>(list.ToArray());

            // it will shuffle the item in span put a debugger and hover on span
            RandomNumberGenerator.Shuffle(span);
            
            Console.ReadKey();
        }
    }
}

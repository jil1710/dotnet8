using InterfaceSerialization.Models;
using System.Text.Json;

namespace InterfaceSerialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Feature 1: Interface serialization
            IBmw detail = new CarDetails
            {
                Brand = "BMV Benz",
                Model = "AMG-6HG"
            };

            var serializedValue = JsonSerializer.Serialize(detail);
            Console.WriteLine(serializedValue);

            Console.ReadKey();

        }
    }
}

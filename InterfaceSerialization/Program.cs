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
            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower };
            
            var serializedValue = JsonSerializer.Serialize(detail,options); // ex : JsonSerializer.Serialize(new { PropertyName = "value" }, options); // { "property_name" : "value" }

            Console.WriteLine(serializedValue);

            Console.ReadKey();

        }
    }
}

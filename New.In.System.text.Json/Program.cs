using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using TestingForthPoint;
using TestingSeventhPoint;

namespace TestingForthPoint
{
    public class MyPoco
    {
        [JsonConstructor]
        internal MyPoco(int x) => X = x;

        [JsonInclude]
        internal int X { get; }
    }
}


namespace TestingSeventhPoint
{
    class CompanyInfo
    {
        public required string Name { get; set; }
        public string? PhoneNumber { get; set; }
    }

    [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
    class CustomerInfo
    {
        // Both of these properties are read-only.
        public string Name { get; } = "Anonymous";
        public CompanyInfo Company { get; } = new() { Name = "N/A", PhoneNumber = "N/A" };
    }
}

namespace New.In.System.text.Json
{
    

    public class Program
    {

        // 2. JsonNode.ParseAsync APIs
        public static async void JsonNodeParseApi()
        {
            using var stream = File.OpenRead("myJSON.json");
            JsonNode node = await JsonNode.ParseAsync(stream);

            Console.WriteLine(JsonSerializer.Serialize(node));
        } 

        static void Main(string[] args)
        {
            // 1. Naming Policy

            /*
                namespace System.Text.Json;

                public class JsonNamingPolicy
                {
                  public static JsonNamingPolicy CamelCase { get; }
                  public static JsonNamingPolicy KebabCaseLower { get; }
                  public static JsonNamingPolicy KebabCaseUpper { get; }
                  public static JsonNamingPolicy SnakeCaseLower { get; }
                  public static JsonNamingPolicy SnakeCaseUpper { get; }
                }
             */
            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower };
            Console.WriteLine(JsonSerializer.Serialize(new { PropertyName = "value" }, options)); // { "property_name" : "value" }

            // 2. JsonNode ParseAsync APIs
            JsonNodeParseApi();


            // 3. JsonSerializerOptions.MakeReadOnly()

            var data = new
            {
                Name = "ABC",
                Age = 21
            };
            JsonSerializerOptions CreateDefaultOptions()
            {
                var options = new JsonSerializerOptions
                {
                    TypeInfoResolver = new DefaultJsonTypeInfoResolver(),
                    WriteIndented = true
                };

                options.MakeReadOnly(); // prevent accidental modification outside the method
                return options;
            }
            Console.WriteLine(CreateDefaultOptions().IsReadOnly);
            JsonSerializer.Serialize(data, CreateDefaultOptions());

            // 4. Extend JsonIncludeAttribute and JsonConstructorAttribute support to non-public members

            string json = JsonSerializer.Serialize(new MyPoco(42)); // {"X":42}
            Console.WriteLine(JsonSerializer.Deserialize<MyPoco>(json)?.X);

            // 5. Built-in support for Memory<T> and ReadOnlyMemory<T>
            var string1 = JsonSerializer.Serialize<ReadOnlyMemory<byte>>(new byte[] { 1, 2, 3 }); // "AQID"
            var string2 = JsonSerializer.Serialize<ReadOnlyMemory<int>>(new int[] { 1, 2, 3 }); // [1,2,3]

            // 6. Built-in support for Half, Int128 and UInt128
            Console.WriteLine(JsonSerializer.Serialize(new object[] { Half.MaxValue, Int128.MaxValue, UInt128.MaxValue }));
            // [65500,170141183460469231731687303715884105727,340282366920938463463374607431768211455]


            // 7. Populate read-only members

            CustomerInfo customer = JsonSerializer.Deserialize<CustomerInfo>("""{"Name":"John Doe","Company":{"Name":"Contoso"}}""")!;
            Console.WriteLine(JsonSerializer.Serialize(customer));

        }
    }
}

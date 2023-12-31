

# <img src="https://github.com/jil1710/readmedemo/assets/125335932/0f20ab60-8575-408c-a861-1e0a9fd16a31" alt="drawing" width="100"/> What's new in .Net 8 Features

-  ASP.NET Core 8 has everything you need to build cutting-edge web user interfaces and robust back-end services on Windows, Linux, and macOS alike.Kindly note that to use .NET 8 in Visual Studio, we need to have a version of Visual Studio 2022 (v17.6 Preview 1) or a later version.

- .NET 8 is the successor to .NET 7. It will be supported for three years as a long-term support (LTS) release. You can download .NET 8 here. 

- This article discusses the biggest highlights in ASP.NET Core 8, and includes some code examples to get you started with the new features.

## Let's see all the .Net 8 features with examples

- ### **Frozen Dictionary Type :**
    
    With .NET 8 we are introduced to a new dictionary type which improves the performance of read operations. The catch: you are not allowed to make any changes to the keys and values once the collection is created. This type is particularly useful for collections that are populated on first use and then persisted for the duration of a long-lived service.
    

    ![image](https://github.com/jil1710/readmedemo/assets/125335932/f5e9d8c8-7ec5-4271-9351-81d54fd2c2b9)

    ![image](https://github.com/jil1710/readmedemo/assets/125335932/311515ec-10ac-4d0f-8d2f-9b8e4002447a)

    ![image](https://github.com/jil1710/readmedemo/assets/125335932/bc8125c0-7600-42dd-86ec-48c0683297e2)

    - Click here to see demo : [Frozen Dictionary Type](https://github.com/jil1710/dotnet8/tree/master/FrozenDictionaryType)


- ### **Interface Serialization :**

    .NET 8 adds support for serializing properties from interface hierarchies.

    The following code shows an example where the properties from both the immediately implemented interface and its base interface are serialized.

    ```csharp

        IDerived value = new DerivedImplement { Base = 0, Derived = 1 };
        JsonSerializer.Serialize(value); // {"Base":0,"Derived":1}

        public interface IBase
        {
            public int Base { get; set; }
        }

        public interface IDerived : IBase
        {
            public int Derived { get; set; }
        }

        public class DerivedImplement : IDerived
        {
            public int Base { get; set; }
            public int Derived { get; set; }
        }

    ```

    - Click here to see demo : [Interface Serialization](https://github.com/jil1710/dotnet8/tree/master/InterfaceSerialization) 

- ### **Keyed service DI injection :**

    With keyed services, another piece of information is stored with the ServiceDescriptor, a ServiceKey that identifies the service. The key can be any object, but it will commonly be a string or an enum (something that can be a constant so it can be used in attributes). For non-keyed services, the ServiceType identifies the registration; for keyed services, the combination of ServiceType and ServiceKey identifies the registration.

    Keyed services are useful when you have an interface/service with multiple implementations that you want to use in your app. What's more, you need to use each of those implementations in different places in your app.

    - **Without keyed services :**
        Without keyed services, you could register all these services like this:



    ```csharp
        builder.Services.AddSingleton<INotificationService, SmsNotificationService>();
        builder.Services.AddSingleton<INotificationService, EmailNotificationService>();
        builder.Services.AddSingleton<INotificationService, PushNotificationService>();
    ```

     But you could retrieve only the last registered service (PushNotificationService) like this :

     ```csharp
        public class NotifierService(INotificationService service){}
    ```

    - **With keyed services :**
        To register a keyed service, use one of the AddKeyedSingleton(), AddKeyedScoped(), or AddKeyedTransient() overloads, and provide an object as a key. In the following example I used a string, but you may want to use an enum or shared constants, for example:

    ```csharp
        builder.Services.AddKeyedSingleton<INotificationService, SmsNotificationService>("sms");
        builder.Services.AddKeyedSingleton<INotificationService, EmailNotificationService>("email");
        builder.Services.AddKeyedSingleton<INotificationService, PushNotificationService>("push");
    ```

    To retrive any service you want using `[FromkeyedService(object key)] just like belo:

    ![image](https://github.com/jil1710/readmedemo/assets/125335932/43707a63-02d7-46ab-9665-10d90278f1c1)

    - Click here to see demo : [Keyed Service DI injection](https://github.com/jil1710/dotnet8/tree/master/KeyedDIServices)



- ### **List Best Practice in .net 8 :**

    Let's understand it by example suppose you create one function that fetch List of User and return it, if User is empty you return `new List<User>()` that will cause memory and issue in perfomance. Instead we use .net 8 new feature to handle this case without affecting the perfomance. Let's dive into example below:

    ![image](https://github.com/jil1710/readmedemo/assets/125335932/f92decf5-4b05-4568-9f2c-d8bef612d184)

    ![benchmark](https://github.com/jil1710/readmedemo/assets/125335932/2f85eee0-3bb4-4230-9d5f-0a99fed54689)

    - Click here to see demo : [List Best Practice](https://github.com/jil1710/dotnet8/tree/master/ListBestPracticesInDotnet8)


- ### **New in System.Text.Json :**

    There are a lot of exciting updates for developers in System.Text.Json in .NET 8. In this release, we have substantially improved the user experience when using the library in Native AOT applications, as well as delivering a number of highly requested features and reliability enhancements. These include support for populating read-only members, customizable unmapped member handling, support for interface hierarchies, snake case and kebab case naming policies and much more.

    -  **JsonStringEnumConverter<TEnum> :**
        The JsonStringEnumConverter class is the API of choice for users looking to serialize enum types as string values. 
        ```csharp
            [JsonConverter(typeof(JsonStringEnumConverter<MyEnum>))]
            public enum MyEnum { Value1, Value2, Value3 }
        ```

    - **Populate read-only members :**
        You can now deserialize onto read-only fields or properties (that is, those that don't have a set accessor).

        Consider the following example:

        ```csharp
            MyPoco result = JsonSerializer.Deserialize<MyPoco>("""{ "Values" : [1,2,3], "Person" : { "Name" : "Brian" } }""");
            Console.WriteLine(result.Values.Count); // 3
            Console.WriteLine(result.Person.Name); // Brian

            [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
            public class MyPoco
            {
                public IList<int> Values { get; } = new List<int>();

                public Person Person { get; } = new();
            }

            public class Person
            {
                public string Name { get; set; }
            }
        
        ```

    - **Naming Policy :**
        JsonNamingPolicy includes new naming policies for snake_case (with an underscore) and kebab-case (with a hyphen) property name conversions.
        
        ```csharp
            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower };
            JsonSerializer.Serialize(new { PropertyName = "value" }, options); // { "property_name" : "value" }
        ```

    - **Non Public Members :**
        The JsonIncludeAttribute and JsonConstructorAttribute are annotations that let users opt specific members into the serialization contract for a given type (properties/fields and constructors respectively). Until now these were limited to public members, but this has now been relaxed to include non-public members:

        ```csharp

            string json = JsonSerializer.Serialize(new MyPoco(42)); // {"X":42}
            JsonSerializer.Deserialize<MyPoco>(json);

            public class MyPoco
            {
                [JsonConstructor]
                internal MyPoco(int x) => X = x;

                [JsonInclude]
                internal int X { get; }
            }
        ```

      ![image](https://github.com/jil1710/readmedemo/assets/125335932/45150c97-41b3-4688-a349-e3de9338aa6b)

    - Click here to see demo : [New in System.Json.Text](https://github.com/jil1710/dotnet8/tree/master/New.In.System.text.Json)

    - Click here to explore more in advanced : [What's new in System.Json.Text](https://devblogs.microsoft.com/dotnet/system-text-json-in-dotnet-8/)

- ### **New Data Validation Attributes :**

    - The DataAnnotations namespace, aimed specifically for validation in cloud-native services. The existing DataAnnotations validators are primarily used for validating user data, like form fields. However, the new attributes are meant to validate data, not entered by users, like configuration options. Apart from the new attributes, the RangeAttribute and RequiredAttribute types also received new properties.

    - **RequiredAttribute.DisallowAllDefaultValues :** The attribute forces that structs for inequality with their default values.
    - **RangeAttribute.MinimumIsExclusive & RangeAttribute.MaximumIsExclusive :** Specifies whether the allowable range includes its boundaries or not.
    - **DataAnnotations.LengthAttribute :** Specifies the lower and upper limits for strings or collections using the Length attribute. For instance, the [Length(5, 100)] attribute specifies that a collection must have at least 5 elements and at most 100 elements.
    - **DataAnnotations.Base64StringAttribute :** Validates a valid Base64 format.
    - **DataAnnotations.AllowedValuesAttribute & DataAnnotations.DeniedValuesAttribute :** Specifies accepted allow lists or not allowed deny lists. For instance: [AllowedValues("red", "green", "blue")] or [DeniedValues("yellow", "purple")].

    ![image](https://github.com/jil1710/dotnet8/assets/125335932/d648d439-02de-4489-ac09-f8b5301495d4)


    - Click here to see demo : [New Validation Data Attributes](https://github.com/jil1710/dotnet8/tree/master/ValidationTypesInDotnet8)


- ### **Improvement in random :**

    The System.Random and System.Security.Cryptography.RandomNumberGenerator types introduce two new methods for working with randomness.

    - `GetItems<T>` :
        This methods let you randomly choose a specified number of items from an input set. The following example shows how to use System.Random.GetItems<T>() to randomly insert 31 items into an array.
    
        ```csharp
            private static ReadOnlySpan<Button> s_allButtons = new[]
            {
                Button.Red,
                Button.Green,
                Button.Blue,
                Button.Yellow,
            };

            // ...

            Button[] thisRound = Random.Shared.GetItems(s_allButtons, 31);
        ```

    - `Shuffle<T>` : 
        This method help us to shuffle the items into list, basically These methods are useful for reducing training bias in machine learning (so the first thing isn't always training, and the last thing always test).

        ```csharp
            YourType[] trainingData = LoadTrainingData();
            Random.Shared.Shuffle(trainingData);
        ```

    - Click here to see demo : [Improvement in Random](https://github.com/jil1710/dotnet8/tree/master/RandomImprovements)


- ### **Replacing the call with Interceptor  in .net 8 :**

    Interceptors are an interesting new experimental feature coming in C#12 and .Net 8 that allow you to replace (or "intercept") a method call in your application with an alternative method. When your app is compiled, the compiler automatically "swaps out" the call to the original method with your substitute.

    ![image](https://github.com/jil1710/readmedemo/assets/125335932/ef644b79-8ec8-423d-92bb-50a653cd6bf4)

    ![image](https://github.com/jil1710/readmedemo/assets/125335932/6f5a74c2-9dd3-42d4-8ff0-a80ae65c5371)

    Output :

    ![image](https://github.com/jil1710/readmedemo/assets/125335932/81f82dfd-2fee-4b0b-91aa-a08e9f31fbef)

    Add this two properties in Project File :

    ![image](https://github.com/jil1710/readmedemo/assets/125335932/fd93c4b4-9323-4ae5-ac28-2ee96ce59e91)


    - Click here to see demo : [Replacing the call with Interceptor  in .net 8](https://github.com/jil1710/dotnet8/tree/master/ReplaceMethodCallWithInterseptor)


- ### **Authentication change in .net 8 :**

    From .net 8 Authentication made simple using `app.MapIndentity<T>()` we can move forward it will automatically create `/register`, `/login`, `/refresh-token` etc....

    The following code snippet shows how MapIndentity<T> can be used.

    ![image](https://github.com/jil1710/readmedemo/assets/125335932/c187bea9-44d8-4218-9bb8-a7cdc0910f1c)

    ![image](https://github.com/jil1710/readmedemo/assets/125335932/622f37f4-a824-46dc-9a80-d46b9665906e)


    - Click here to see demo : [Authentication change in .net 8](https://github.com/jil1710/dotnet8/tree/master/AuthChangeInDotNet8)


- ### **Background Tasks improve :**

   Hosted services now have more options for execution during the application lifecycle. Microsoft.Extensions.Hosting.IHostedService provided StartAsync and StopAsync, and now Microsoft.Extensions.Hosting.IHostedLifecycleService provides these additional methods:

    - Microsoft.Extensions.Hosting.IHostedLifecycleService.StartingAsync(System.Threading.CancellationToken)
    - Microsoft.Extensions.Hosting.IHostedLifecycleService.StartedAsync(System.Threading.CancellationToken)
    - Microsoft.Extensions.Hosting.IHostedLifecycleService.StoppingAsync(System.Threading.CancellationToken)
    - Microsoft.Extensions.Hosting.IHostedLifecycleService.StoppedAsync(System.Threading.CancellationToken)

    These methods run before and after the existing points respectively.
  
    - IHostedService example

      ![image](https://github.com/jil1710/readmedemo/assets/125335932/0682bb23-5473-4af0-ad0d-25e208f9f5e3)

    - IHostedLifecycleService example which has application lifecycle
 
      ![image](https://github.com/jil1710/readmedemo/assets/125335932/ff6bf254-feb3-4cc2-b8e8-30e2bf22080c)

    - Click here to see demo : [Background Tasks improve](https://github.com/jil1710/dotnet8/tree/master/BackgroundTaskFixedInDotnet8)


- ### **Builtin Guard Clause :**

    As C# 12 is release with .Net 8 reference so in .Net 8 we have built in guard clause that help us in code minimization and perfomance improve:

    ![image](https://github.com/jil1710/readmedemo/assets/125335932/85234179-cf11-494d-8992-f22f0bb22f8d)

    - Click here to see demo : [Builtin Guard Types](https://github.com/jil1710/dotnet8/tree/master/BuiltInGuardClauses)


- ### **TimeProvider Abstract class :**

    In ASP.NET 8, new abstract class is introduce that will give system time with accurate precidence:

    ```csharp
        // Get system time.
        DateTimeOffset utcNow = TimeProvider.System.GetUtcNow();
        DateTimeOffset localNow = TimeProvider.System.GetLocalNow();
    ```

    - Click here to see demo : [TimeProvider Abstract class](https://github.com/jil1710/dotnet8/tree/master/TimeProviderClass)
 
- ### **Form Binding in minimal Api :**

    In ASP.NET 8, Form binding with complem type optimize and add stop automatic validation of anti forgery token by using middleware `DisableAntiforgery()`:

    ![image](https://github.com/jil1710/readmedemo/assets/125335932/582b4bff-4629-4a4b-a6bd-7694f82ee04a)


    - Click here to see demo : [Form Binding in minimal Api](https://github.com/jil1710/dotnet8/tree/master/FormBindingInMinimalApi)

 
- ### **Short Circuiting in .net 8 :**

    .NET 8 has a new feature for short circuiting routes.

    When routing matches an endpoint it typically lets the rest of the middleware pipeline run before invoking the endpoint logic. If that's not necessary or desirable, there's a new option that will cause routing to invoke the endpoint logic immediately and then end the request. This can be used to efficiently respond to requests that don't require additional features like authentication, CORS, etc., such as requests for robots.txt or favicon.ico.

    For Example :
    ```csharp
        app.MapGet("/health", () => "Hello World").ShortCircuit();
    ```
    You can also use the MapShortCircuit method to setup endpoints that send a quick 404 or other status code for matched resources that you don't want to further process.

    ```csharp
        app.MapShortCircuit(404, "robots.txt", "favicon.ico");
    ```

    - Click here to see demo : [Short Circuiting in .Net 8](https://github.com/jil1710/dotnet8/tree/master/ShoetCircuitInDotNet8)
 
  



    

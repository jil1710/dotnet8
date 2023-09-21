
namespace ReplaceMethodCallWithInterseptor
{

    public static class GenerateInterseptor
    {
        [System.Runtime.CompilerServices.InterceptsLocation("""C:\Users\jil\source\repos\dotnet8\ReplaceMethodCallWithInterseptor\Program.cs""", 32,17)]
        public static void MyInterseptorMethod(this Example example,string msg)
        {
            Console.WriteLine("Message from interseptor : " + msg);
        }
    }

    public class Example
    {
        public void Greet(string msg)
        {
            Console.WriteLine(msg);
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {

            // Now i want to intersept the 2 call to with another call then i use .net 8 interseptor feature

            var exp = new Example();
            exp.Greet("Good morning");
            exp.Greet("Good night"); // Message form interseptor Good night
            exp.Greet("Good evening");
        }
    }
}

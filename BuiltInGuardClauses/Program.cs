namespace BuiltInGuardClauses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string? name = null;
            int age = 0;

            // old way
            if(name == null )
            {
                throw new ArgumentNullException("name is null");
            }


            // new  way
            ArgumentNullException.ThrowIfNull("name is null");
            //or
            ArgumentNullException.ThrowIfNullOrEmpty("name is null or empty");


            // old way
            if(age < 18)
            {
                throw new ArgumentOutOfRangeException(" Age is nor less than 18");
            }

            // new way
            ArgumentOutOfRangeException.ThrowIfLessThan(age, 18);
        }
    }
}

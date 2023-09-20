namespace TimeProviderClass
{
    public class GreetService
    {
        private readonly TimeProvider timeProvider;

        public GreetService(TimeProvider timeProvider)
        {
            this.timeProvider = timeProvider;
        }

        public string GenerateGreetText()
        {
            var dateTimeNow = timeProvider.GetLocalNow();

            return dateTimeNow.Hour switch
            {
                >= 5 and < 12 => "Good Morning",
                >= 12 and < 18 => "Good Afternoon",
                _ => "Good Evening"
            };
        }
    }
}

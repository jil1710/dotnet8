
namespace BackgroundTaskFixedInDotnet8
{
    public class ExcecuteInBackground : IHostedService
    {
        private readonly ILogger<ExcecuteInBackground> logger;

        public ExcecuteInBackground(ILogger<ExcecuteInBackground> logger)
        {
            this.logger = logger;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            // Let's this is invoke when the appication is started and take 10000 or even more to process some logic at starting of app

            logger.LogInformation("Background process starts");

            await Task.Delay(10000);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("Background process stopped");

            await Task.CompletedTask;
        }
    }
}

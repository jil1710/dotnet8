
namespace BackgroundTaskFixedInDotnet8
{
    public class ExecuteInBackgroundWithLifeCycle : IHostedLifecycleService
    {
        private readonly ILogger<ExecuteInBackgroundWithLifeCycle> logger;

        public ExecuteInBackgroundWithLifeCycle(ILogger<ExecuteInBackgroundWithLifeCycle> logger)
        {
            this.logger = logger;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            // Let's this is invoke when the appication is start

            logger.LogInformation("StartAsync");

            await Task.CompletedTask;
        }

        public async Task StartedAsync(CancellationToken cancellationToken)
        {
            // Invoke when app is started run
            logger.LogInformation("StartedAsync");

            await Task.CompletedTask;
        }

        public async Task StartingAsync(CancellationToken cancellationToken)
        {
            // Invoke when app is starting
            logger.LogInformation("StartingAsync");

            await Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("StopAsync");

            await Task.CompletedTask;
        }

        public async Task StoppedAsync(CancellationToken cancellationToken)
        {
            // Invoke when app is completely stopped
            logger.LogInformation("StoppedAsync");

            await Task.CompletedTask;
        }

        public async Task StoppingAsync(CancellationToken cancellationToken)
        {
            // Invoke when app is stopping
            logger.LogInformation("StoppingAsync");

            await Task.CompletedTask;
        }
    }
}

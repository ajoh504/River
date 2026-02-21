using River.BackgroundServices.Interfaces;

namespace River.BackgroundServices.Workers
{
    public class Worker(ILogger<Worker> logger, IFileChangeListener fileChangeListener) : BackgroundService, IFileChangeListener
    {
        private IFileChangeListener FileChangeListener { get; } = fileChangeListener;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (logger.IsEnabled(LogLevel.Information))
                {
                    logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                }
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}

using SeetourAPI.DAL.Repos;

namespace SeetourAPI.Services
{
    public class TimedTrrendingService : IHostedService, IDisposable
    {
        private int executionCount = 0;
        private readonly ILogger<TimedTrrendingService> _logger;
        private readonly IServiceProvider _serviceProvider;
        private Timer? _timer = null;

        public TimedTrrendingService(ILogger<TimedTrrendingService> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Trending Service running.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromDays(1));

            return Task.CompletedTask;
        }

        private async void DoWork(object? state)
        {
            var count = Interlocked.Increment(ref executionCount);
            await UpdateTrendingTours(count);
        }

		private async Task UpdateTrendingTours(int count)
        {
            _logger.LogInformation(
                            "Trending Tours Service is working. Count: {Count}", count);

            bool result_update = false;

            using (var scope = _serviceProvider.CreateScope())
            {

                var _trendingRepo = scope.ServiceProvider.GetRequiredService<ITrendingTourRepo>();

                result_update = await _trendingRepo.TryUpdateAll();
            }

            _logger.LogInformation(
                "Trending Tours Hosted Service Result: {Result}", result_update);
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}

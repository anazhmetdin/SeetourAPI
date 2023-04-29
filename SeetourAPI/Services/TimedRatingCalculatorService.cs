using SeetourAPI.DAL.Repos;

namespace SeetourAPI.Services
{
    public class TimedRatingCalculatorService: IHostedService, IDisposable
    {
        private int executionCount = 0;
        private readonly ILogger<TimedRatingCalculatorService> _logger;
        private readonly IServiceProvider _serviceProvider;
        private Timer? _timer = null;

        public TimedRatingCalculatorService(ILogger<TimedRatingCalculatorService> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Rating calculator Service running.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromDays(1));

            return Task.CompletedTask;
        }

        private void DoWork(object? state)
        {
            var count = Interlocked.Increment(ref executionCount);
            CalculateRatings(count);

        }

        private void CalculateRatings(int count)
        {
            _logger.LogInformation(
                            "Rating Calculator Service is working. Count: {Count}", count);

            bool result_rating = false;

            using (var scope = _serviceProvider.CreateScope())
            {

                var _TGRating = scope.ServiceProvider.GetRequiredService<ITourGuideRatingRepo>();

                result_rating = _TGRating.TryUpdateAll();
            }

            _logger.LogInformation(
                "Rating Calculator Timed Hosted Service Result: {Result}", result_rating);
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

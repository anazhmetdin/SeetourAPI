using SeetourAPI.DAL.Repos;

namespace SeetourAPI.Services
{
    public class TimedBookingCheckerService : IHostedService, IDisposable
    {
        private int executionCount = 0;
        private readonly ILogger<TimedBookingCheckerService> _logger;
        private readonly IServiceProvider _serviceProvider;
        private Timer? _timer = null;

        public TimedBookingCheckerService(ILogger<TimedBookingCheckerService> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Booking Service running.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromHours(1));

            return Task.CompletedTask;
        }

        private async void DoWork(object? state)
        {
            var count = Interlocked.Increment(ref executionCount);
            await UpdateBookings(count);
        }

		private async Task UpdateBookings(int count)
        {
            _logger.LogInformation(
                            "Booking Update Service is working. Count: {Count}", count);

            bool result_update = false;

            using (var scope = _serviceProvider.CreateScope())
            {

                var _BookingRepo = scope.ServiceProvider.GetRequiredService<IBookingRepo>();

                result_update = await _BookingRepo.TryUpdateAll();
            }

            _logger.LogInformation(
                "Booking Update Timed Hosted Service Result: {Result}", result_update);
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

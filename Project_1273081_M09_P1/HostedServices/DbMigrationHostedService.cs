namespace Project_1273081_M09_P1.HostedServices
{
    public class DbMigrationHostedService : IHostedService
    {
        private readonly IServiceProvider serviceProvider;
        public DbMigrationHostedService(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = serviceProvider.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<ApplyMigrationService>();
            await service.ApplyAsync();
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }
    }
}

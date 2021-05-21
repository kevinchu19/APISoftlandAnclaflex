using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APISoftlandAnclaflex.Services
{
    public class ConsumeScopedServiceHostedService : BackgroundService
    {
        private readonly ILogger _logger;
        private Timer _timer { get; set; }
        public ConsumeScopedServiceHostedService(IServiceScopeFactory services,
            ILogger logger)
        {
            Services = services;
            _logger = logger;
        }

        public IServiceScopeFactory Services { get; }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //_logger.Information(
            //    "Consume Scoped Service Hosted Service running.");
            try
            {
                _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));
            }
            catch (Exception ex)
            {

                _logger.Fatal($"Error al ejecutar el servicio {ex.Message}");
            }

        }

        private async void DoWork(object state)
        {
            //_logger.Information(
            //    "Consume Scoped Service Hosted Service is working.");

            using (var scope = Services.CreateScope())
            {
                var scopedProcessingService =
                    scope.ServiceProvider
                        .GetRequiredService<IScopedProcessingService>();

                await scopedProcessingService.DoWork();
            }
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.Information(
                "Consume Scoped Service Hosted Service is stopping.");

            await base.StopAsync(stoppingToken);
        }
    }
}

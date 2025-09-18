using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cookbook.Distributed.Background;

public class DemoWorker : BackgroundService
{
    private readonly ILogger<DemoWorker> _logger;

    public DemoWorker(ILogger<DemoWorker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        int counter = 0;
        while (!stoppingToken.IsCancellationRequested)
        {
            counter++;
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation("Background service iteration: {Counter} at: {Time}", counter, DateTimeOffset.Now);
            }
            await Task.Delay(2000, stoppingToken);
        }
    }
}

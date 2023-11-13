using BankAccountProject.Presentation.ApiConnection.ApiInterface;
using BankAccountProject.Services.Interfaces;
using BankAccountProject.Services.Services;
using System.Diagnostics;

namespace BankAccountProject.Presentation.ApiConnection
{
    public sealed class UpdateInformationWithTimer : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public UpdateInformationWithTimer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        private static int SecondsUntilFiveMinutes()
        {
            return (int)(DateTime.Today.AddMinutes(5.0) - DateTime.Now).TotalSeconds;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var countdown = SecondsUntilFiveMinutes();

            while (!stoppingToken.IsCancellationRequested)
            {                
                if (countdown-- <= 0)
                {
                    try
                    {
                        await OnTimerFiredAsync(stoppingToken);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(message:ex.Message);
                    }
                    finally
                    {
                        countdown = SecondsUntilFiveMinutes();
                    }
                }
                await Task.Delay(1000, stoppingToken);
            }
        }

        private async Task OnTimerFiredAsync(CancellationToken stoppingToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var apiConnectionService = scope.ServiceProvider.GetService<IApiConnection>();
                var dbConnectionService = scope.ServiceProvider.GetService<IBankAccountService>();

                try
                {
                    var apiData = await apiConnectionService.GetBankAccounts();
                    var dbData = await dbConnectionService.GetAllBankAccountsAsync();

                    foreach (var apiAccount in apiData)
                    {
                        var dbAccount = dbData.FirstOrDefault(ba => ba.id == apiAccount.id);
                        if (dbAccount != null)
                        {
                            if (dbAccount.Equals(apiAccount)) continue;

                            if (apiAccount.borc is null) apiAccount.borc = 0;

                            await dbConnectionService.UpdateBankAccountAsync(apiAccount);
                        }
                        else
                        {
                            if (apiAccount.borc is null) apiAccount.borc = 0;
                            await dbConnectionService.AddBankAccountAsync(apiAccount);
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(message: ex.Message);
                }
                Debug.WriteLine("Simulating heavy I/O bound work");
                await Task.Delay(2000, stoppingToken);
            }
           
        }
    }
}

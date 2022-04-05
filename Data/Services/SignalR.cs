using Microsoft.AspNetCore.SignalR.Client;

namespace PrviBlazorServerApp.Data.Services
{
    public class SignalR
    {
        public HubConnection HC { get; set; }
        public bool ConnectionOK { get; set; }

        public SignalR()
        {
            HC = new HubConnectionBuilder()
                .WithUrl("http://localhost:5104/CRUDhub")
                .Build();
            StartUp();
        }
        private async Task StartUp()
        {
            await HC.StartAsync();
            ConnectionOK = true;
        }
    }
}

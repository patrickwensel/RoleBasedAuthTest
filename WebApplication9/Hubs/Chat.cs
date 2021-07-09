using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace WebApplication9.Hubs
{
    public class Chat : Hub
    {
        public string GetConnectionId()
        {
            return Context.ConnectionId;
        }
        public async Task SendMessage(string message)
        {
            //var user = await _userManager.GetUserAsync();
            await Clients.All.SendAsync("ReceiveMessage", Context.User.Identity.Name ?? "anonymous", message);
        }
        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("ReceiveSystemMessage", $"{Context.UserIdentifier} joined.");
            await base.OnConnectedAsync();
        }
        public Task SendPrivateMessage(string userId, string message)
        {
            return Clients.User(userId).SendAsync("ReceiveMessage", userId, message);
        }
        public async Task SendToUser(string user, string message)
        {
            await Clients.User(user).SendAsync("ReceiveDirectMessage", $"{Context.UserIdentifier}: {message}");
        }

        public async Task Send(string connectionId, string message)
        {
            await Clients.Client(connectionId).SendAsync("ReceiveDirectMessage", $"{Context.UserIdentifier}: {message}");
        }
        //public Task SendMessageToCaller(string user, string message)
        //{
        //    return Clients.Caller.SendAsync("ReceiveMessage", user, message);
        //}

        //public Task SendMessageToGroup(string user, string message)
        //{
        //    return Clients.Group("SignalR Users").SendAsync("ReceiveMessage", user, message);
        //}
    }

}

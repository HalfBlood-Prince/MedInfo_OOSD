using Microsoft.AspNet.Identity;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace MedInfo_OOSD.Core
{
    [HubName("chatHub")]
    public class ChatHub : Hub
    {
        public void Announce(string massage)
        {
            var userName = Context.User.Identity.GetUserName();

            Clients.All.addMassage(userName, massage);
        }
    }
}
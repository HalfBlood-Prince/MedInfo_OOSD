using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedInfo_OOSD.Core.Domain;
using MedInfo_OOSD.Models.Constants;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace MedInfo_OOSD.Controllers.Chat
{
    [HubName("chatHub")]
    public class ChatHub : Hub
    {
        public static List<User> Users = new List<User>();


        //
        /// <summary>
        ///     This method takes a massage and push that massage 
        ///     to all connected clients.
        /// </summary>
        /// <param name="massage">It takes a string massage</param>
        public void Announce(string massage)
        {
            var userName = Context.User.Identity.GetUserName();
            
            Clients.All.addMassage(userName, massage);
        }


        //
        /// <summary>
        ///     This method make peer to peer connection between admin
        ///     and a single user.
        /// </summary>
        public async Task AddUser()
        {
            var user = new User
            {
                UserName = Context.User.Identity.GetUserName(),
                IsAdmin = Context.User.IsInRole(Roles.SuperAdmin) || Context.User.IsInRole(Roles.Moderator),
                ConnectionId = Context.ConnectionId,
                
            };

            if (user.IsAdmin)
            {
                user.IsAvailable = true;

                user.ChatGroup = Context.User.Identity.GetUserName();

                await Groups.Add(user.ConnectionId, user.ChatGroup);

                Users.Add(user);

                Clients.Caller.onConnected();
            }
            else
            {
                var userInList = Users.FirstOrDefault(u => u.IsAdmin && u.IsAvailable);

                if (userInList != null)
                {
                    userInList.IsAvailable = false;

                    user.ChatGroup = userInList.ChatGroup;

                    await Groups.Add(user.ConnectionId, user.ChatGroup);

                    Users.Add(user);

                    Clients.Caller.onConnected();
                }
                else
                {
                    Clients.Caller.showError();
                }
            }
        }


        //
        /// <summary>
        ///     This method push massage to user or 
        ///     admin when they are connected in a 
        ///     peer to peer connection.
        /// </summary>
        /// <param name="massage">It takes a string massagey</param>
        public void SendMassage(string massage)
        {
            if (!Users.Any()) return;


            var user = Users.SingleOrDefault(u => u.ConnectionId.Equals(Context.ConnectionId));

            if(user == null)
                throw new NullReferenceException("There is no user with this connectionId");

            Clients.Group(user.ChatGroup).writeMassage(user.UserName, massage);
        }



        //
        /// <inheritdoc />
        /// <summary>
        ///     Its an overridden method.
        ///     This application handles when a user 
        ///     gets disconnected.
        /// </summary>
        /// <param name="stopCalled">stopCalled parent methods parameter</param>
        public override Task OnDisconnected(bool stopCalled)
        {
            var user = Users.SingleOrDefault(u => u.ConnectionId == Context.ConnectionId);

            if (user == null) return base.OnDisconnected(stopCalled);
            
            if (!user.IsAdmin)
            {
                var admin = Users.SingleOrDefault(u => u.ChatGroup == user.ChatGroup);

                if (admin != null) admin.IsAvailable = true;
            }

            Users.Remove(user);

            return base.OnDisconnected(stopCalled);
        }
    }
}
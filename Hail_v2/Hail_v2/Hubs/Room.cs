using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using BLL.ChatRoom;
using Microsoft.Practices.Unity;
using Hail_v2.App_Start;

namespace Hail_v2.Hubs
{
    public enum Messagetype
    {
            Text,
            Math,
            Picture
    }
    public class Room : Hub
    {

        
        private static IUnityContainer _unityContainer =UnityConfig.GetConfiguredContainer();

        private  IChatRoomBLL _chatRoom = _unityContainer.Resolve<IChatRoomBLL>();

        public Task JoinRoom(string groupName)
        {
            return Groups.Add(Context.ConnectionId, groupName);
        }
        private List<string> connections = new List<string>();
        public void connectToGroup(string groupName)
        {
            JoinRoom(groupName);
        }
        //public void SendMessage(string message, string messageType, string name, string groupName)
        public void SendMessage( string name, string message, string groupName , string messageType)
        {
            var chat = _chatRoom.GetById(Convert.ToInt32(groupName));

            Clients.Group(groupName).ShowMessage(name, message, DateTime.Now.ToShortTimeString());
        }

    }
  
}
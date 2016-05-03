using BLL.ChatRoom;
using Hail_v2.Models;
using System.Web.Mvc;

namespace Hail_v2.Controllers
{
    public class ChatRoomController : Controller
    {

        private IChatRoomBLL _chatRoomBLL;

        public ChatRoomController(IChatRoomBLL chatRoomBLL)
        {
            _chatRoomBLL = chatRoomBLL;
        }

        public ActionResult Room(string name, string roomName, string roomPassword)
        {
            var currentChatRoom = _chatRoomBLL.GetByCredentials(roomName, roomPassword);

            if (roomName.Equals("Admin") || roomPassword.Equals("Admin"))
            {
                return View();
            }
            else {
                return View(new ChatRoomModel() { UserName = name, ChatId = currentChatRoom.Id.ToString(), ChatName = roomName });
            }
            }
        public ActionResult Create(string name, string roomName, string roomPassword)
        {
            _chatRoomBLL.AddByCredentials(roomName, roomPassword);
            _chatRoomBLL.SaveTransaction();
            return RedirectToAction("Room", new { name, roomName, roomPassword });
        }
    }
}
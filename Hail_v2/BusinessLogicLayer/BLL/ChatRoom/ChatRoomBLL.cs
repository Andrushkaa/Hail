using DAL.ChatRoom;
using System;
namespace BLL.ChatRoom
{
    public class ChatRoomBLL : IChatRoomBLL
    {
        private  IChatRoomRepository _chatRoomRepository;

        public ChatRoomBLL(IChatRoomRepository chatRoomRepository)
        {
            _chatRoomRepository = chatRoomRepository;
        }

        public DBLayer.ChatRoom GetByCredentials(string name, string password)
        {
            return _chatRoomRepository.GetByCredentials(name, password);
        }

        public DBLayer.ChatRoom GetById(int Id)
        {
            return _chatRoomRepository.GetSingle(Id);
        }

        public void AddByCredentials(string name, string password)
        {
            DBLayer.ChatRoom chatRoomToAdd = new DBLayer.ChatRoom() { CRName = name ,CRPassword = password , CRActive= true , CRDeleted = false };
            _chatRoomRepository.Add(chatRoomToAdd);
        }

        public void SaveTransaction()
        {
            _chatRoomRepository.Save();
        }
    }
}

namespace BLL.ChatRoom
{
    public interface IChatRoomBLL
    {

        DBLayer.ChatRoom GetByCredentials(string name, string password);

        void AddByCredentials(string name, string password);

        void SaveTransaction();

        DBLayer.ChatRoom GetById(int Id);
    }
}

namespace DAL.ChatRoom
{
    public interface IChatRoomRepository
    {
        DBLayer.ChatRoom GetSingle(int Id);
        DBLayer.ChatRoom GetByCredentials(string name, string password);
        void Add(DBLayer.ChatRoom entity);
        void Save();
    }
}

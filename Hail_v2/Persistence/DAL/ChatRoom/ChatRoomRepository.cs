using DBLayer;
using System.Linq;

namespace DAL.ChatRoom
{
    public class ChatRoomRepository : GenericRepository<HailEntities, DBLayer.ChatRoom> , IChatRoomRepository
    {
        public DBLayer.ChatRoom GetSingle(int Id)
        {
            return Context.ChatRooms.FirstOrDefault(cr => cr.Id == Id && cr.CRActive && !cr.CRDeleted);
        }

        public DBLayer.ChatRoom GetByCredentials(string name , string password)
        {
            return Context.ChatRooms.FirstOrDefault(cr => cr.CRName == name && cr.CRPassword == password && cr.CRActive && !cr.CRDeleted);
        }

        public override void Add(DBLayer.ChatRoom entity)
        {
            base.Add(entity);
        }

        public override void Save()
        {
            base.Save();
        }
    }
}

using BLL.ChatRoom;
using DAL.ChatRoom;
using Microsoft.Practices.Unity;

namespace Hail_v2.App_Start
{
    public static class UnityBootstrap
    {

        static UnityBootstrap()
        {
            IUnityContainer container = UnityConfig.GetConfiguredContainer();
            container.RegisterType<IChatRoomRepository, ChatRoomRepository>();
            container.RegisterType<IChatRoomBLL, ChatRoomBLL>();
        }

        public static void Init()
        {
            //constructor will be activeted on this methot 
        }
    }
}
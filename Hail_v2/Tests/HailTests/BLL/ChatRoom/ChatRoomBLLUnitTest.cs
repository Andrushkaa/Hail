using System;
using NUnit.Framework;
using NUnit;
using Moq;
using DAL.ChatRoom;
using BLL.ChatRoom;

namespace HailTests.BLL.ChatRoom
{
    [TestFixture]
    public class ChatRoomBLLUnitTest
    {
        private Mock<IChatRoomRepository> _chatRoomRepository = new Mock<IChatRoomRepository>();
        private ChatRoomBLL _chatRoomBLL;
        private DBLayer.ChatRoom _chatRoomStub = new DBLayer.ChatRoom() {CRName = "name",CRPassword="pass",CRActive=true,CRDeleted=false,CRTheme="none" };
        private int IdToGetChatRoom = 1;
        private string UName = String.Empty;
        private string UPass = String.Empty;
        private bool checkSave = false;
        private bool checkAdd = false;
        [TestFixtureSetUp]
        public void SetUp()
        {
            _chatRoomRepository.Setup(v => v.GetByCredentials(UName, UPass)).Returns(_chatRoomStub);
            _chatRoomRepository.Setup(v => v.GetSingle(IdToGetChatRoom)).Returns(_chatRoomStub);
            _chatRoomRepository.Setup(v => v.Save()).Callback(()=> { checkSave = true; }) ;
            _chatRoomRepository.Setup(v => v.Add(_chatRoomStub)).Callback(() => { checkAdd = true; });

            _chatRoomBLL = new ChatRoomBLL(_chatRoomRepository.Object);
        }
        [Test]
        public void Test_Correct_Returns_ChatRoom_By_Credentials()
        {
            DBLayer.ChatRoom chatRoomToCheck = _chatRoomBLL.GetByCredentials(UName, UPass);
            Assert.AreEqual(chatRoomToCheck, _chatRoomStub);
        }

        [Test]
        public void Test_Correct_Returns_ChatRoom_By_Id()
        {
            DBLayer.ChatRoom chatRoomToCheck = _chatRoomBLL.GetById(IdToGetChatRoom);
            Assert.Are(chatRoomToCheck, _chatRoomStub);
        }

        [Test]
        public void Test_Correct_Save()
        {
            _chatRoomBLL.SaveTransaction();
            Assert.IsTrue(checkSave);
        }
    }
}

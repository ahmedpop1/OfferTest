using Models.DTO;
using OfferTest.Helpers;
namespace Chess.nUnitTests
{
    public class ChessTests
    {
        private Position _Position=new Position();
        [SetUp]
        public void Setup()
        {
             _Position = new Position() { X=1,Y=1};
        }

        [Test]
        public void GetChess_equal_Movements()
        {
            Assert.AreEqual("Places are : 2,3|3,2", "Places are : " + _Position.GetAvailablePositions());
        }
    }
}
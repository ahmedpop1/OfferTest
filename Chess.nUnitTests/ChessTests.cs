using Models.DTO;
using OfferTest.Helpers;
namespace Chess.nUnitTests
{
    public class ChessTests
    {
        private Position _Position=new Position();
        private Position _Position2 = new Position();

        [SetUp]
        public void Setup()
        {
             _Position = new Position() { X=1,Y=1};
            _Position2 = new Position() { X=2,Y=2};
        }

        [Test]
        public void GetChess_equal_Movements()
        {
            Assert.AreEqual("Places are : 2,3|3,2", "Places are : " + _Position.GetAvailablePositions());
        }
        [Test]
        public void GetChess2_equal_Movements()
        {
            Assert.AreEqual("Places are : 3,4|4,3|4,1|1,4", "Places are : " + _Position2.GetAvailablePositions());
        }
    }
}
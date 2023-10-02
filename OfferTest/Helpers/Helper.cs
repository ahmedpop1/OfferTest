using Models.DTO;
using System.Collections.Generic;

namespace OfferTest.Helpers
{
    public static class Helper
    {
       public static bool  IsInsideChessArea(this Position Position )
        {
            if (Position.X > 8 || Position.X < 1 || Position.Y > 8 || Position.Y < 1)
                return false;
            return true;

        }
        public static string GetAvailablePositions(this Position Position)
        {
            List<Position>AvailableList= new List<Position>() { 
            new Position() { X = Position.X + 1, Y = Position.Y +2},
            new Position() { X = Position.X + 1, Y = Position.Y -2},
            new Position() { X = Position.X + 2, Y = Position.Y +1},
            new Position() { X = Position.X + 2, Y = Position.Y -1}, 
            new Position() { X = Position.X - 1, Y = Position.Y +2},
            new Position() { X = Position.X - 1, Y = Position.Y -2},
            new Position() { X = Position.X - 2, Y = Position.Y +1},
            new Position() { X = Position.X - 2, Y = Position.Y -1}
            };
           return AvailableList.Where(P=>P.IsInsideChessArea()).GroupBy(p=> new { p.X, p.Y }).Select(group => group.First()).ToList().ToStrng();
        }
        public  static string ToStrng(this List<Position> Positions)
        {
          return  string.Join("|", Positions.Select(P => P.X.ToString() + "," + P.Y.ToString()));
          
        }
    }
}

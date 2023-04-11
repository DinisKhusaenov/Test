
namespace Test
{
    public class Coordinate
    {
        private int _x;
        private int _y;

        public int X 
        {
            get { return _x; }
            set { if (value >= 0 && value <= 100) _x = value; } 
        }
        public int Y
        {
            get { return _y; }
            set { if (value >= 0 && value <= 100) _y = value; }
        }

        public double FindingDistanceBetweenCoordinates(Car _first, Car _second)
        {
            double _firstTerm = Math.Pow(_second.CarCoordinate.X - _first.CarCoordinate.X, 2);
            double _secondTerm = Math.Pow(_second.CarCoordinate.Y - _first.CarCoordinate.Y, 2);

            double _distance = Math.Sqrt(_firstTerm + _secondTerm);
            
            return (_distance);
        }
    }
}

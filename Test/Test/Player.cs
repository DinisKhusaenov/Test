
namespace Test
{
    public class Player
    {
        private string _name;
        private Coordinate _playerCoordinate = new Coordinate();

        public string Name 
        {
            get { return _name; }
            set { if (value.Length > 0) _name = value; } 
        }

        public Coordinate PlayerCoordinate 
        { 
            get { return _playerCoordinate; } 
            set { _playerCoordinate = value; } 
        }
    }
}

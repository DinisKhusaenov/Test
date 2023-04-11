
namespace Test
{
    public class Car
    {
        private string _carName;
        private Coordinate _carCoordinate = new Coordinate();
        private Player _driver = new Player();
        private List<Player> _passengers = new List<Player>();

        public string CarName 
        { 
            get { return _carName; } 
            set { if (value.Length > 0) _carName = value; } 
        }

        public Coordinate CarCoordinate 
        { 
            get { return _carCoordinate; } 
            set { _carCoordinate = value; } 
        }

        public Player Driver 
        { 
            get { return _driver; } 
            set { _driver = value; } 
        }

        public List<Player> Passengers 
        { 
            get { return _passengers; } 
            set {if (value.Count <= 3) _passengers = value; } 
        }

    }
}


namespace Test
{
    public class Test
    {
        private List<Player> _players = new List<Player>();
        private List<Car> _cars = new List<Car>();

        public string NameGenerator()
        {
            string _name = "";
            var _random = new Random();
            while (_name.Length < 6)
            {
                Char _letter = (char)_random.Next(97, 122);
                if (Char.IsLetterOrDigit(_letter))
                    _name += _letter;
            }
            return _name;
        }

        private void DataFilling()
        {
            for (int i = 0; i < 1000; i++)
            {
                Player _newPlayer = new Player();
                _newPlayer.Name = NameGenerator();
                _newPlayer.PlayerCoordinate.X = Random.Shared.Next(0, 100);
                _newPlayer.PlayerCoordinate.Y = Random.Shared.Next(0, 100);

                _players.Add(_newPlayer);

                if (i < 200)
                {
                    Car _newCar = new Car();
                    _newCar.CarName = NameGenerator();
                    _newCar.CarCoordinate.X = Random.Shared.Next(0, 100);
                    _newCar.CarCoordinate.Y = Random.Shared.Next(0, 100);

                    _cars.Add(_newCar);
                }
            }
        }

        private void CarFilling()
        {
            int _numberOfCars = 0;
            int _numberofPeople = 0;
            while (_numberOfCars < _cars.Count && _numberofPeople < _players.Count)
            {
                _cars[_numberOfCars].Driver = _players[_numberofPeople];
                _players[_numberofPeople].PlayerCoordinate.X = _cars[_numberOfCars].CarCoordinate.X;
                _players[_numberofPeople].PlayerCoordinate.Y = _cars[_numberOfCars].CarCoordinate.Y;
                for (int j = 1; j < 4; j++)
                {
                    _cars[_numberOfCars].Passengers.Add(_players[j + _numberofPeople]);
                    _players[j + _numberofPeople].PlayerCoordinate.X = _cars[_numberOfCars].CarCoordinate.X;
                    _players[j + _numberofPeople].PlayerCoordinate.Y = _cars[_numberOfCars].CarCoordinate.Y;
                }
                _numberOfCars += 1;
                _numberofPeople += 4;
            }
        }

        private Dictionary<Player, double> GetNearbyPlayers(int _distance, Car _car)
        {
            var _nearestPlayers = new Dictionary<Player, double>();

            for (int i = 0; i < _cars.Count; i++)
            {
                if (!_cars[i].Equals(_car))
                {
                    double _distanceBetweenCoordinates = Coordinate.FindingDistanceBetweenCoordinates(_car, _cars[i]);
                    if (_distanceBetweenCoordinates <= _distance){
                        _nearestPlayers.Add(_cars[i].Driver, _distanceBetweenCoordinates);
                        for (int j = 0; j < _cars[i].Passengers.Count; j++) {
                            _nearestPlayers.Add(_cars[i].Passengers[j], _distanceBetweenCoordinates);
                        }
                    }
                }
            }

            return _nearestPlayers;
        }

        private void CarInfo(int _count)
        {
            Console.WriteLine("Название автомобиля - " + _cars[_count].CarName);
            Console.WriteLine("Координаты автомобиля - (" + _cars[_count].CarCoordinate.X + "," + _cars[_count].CarCoordinate.Y + ")");
            Console.WriteLine("Водитель - " + _cars[_count].Driver.Name);
            Console.Write("Пассажиры - ");
            for (int i = 0; i < _cars[_count].Passengers.Count; i++)
            {
                Console.Write(_cars[_count].Passengers[i].Name + " ");
            }
            Console.WriteLine();
        }

        static void Main()
        {
            Test test = new();
            test.DataFilling();

            Thread _thread = new Thread(test.CarFilling);
            _thread.Start();

            for (int i = 0; i < 5; i++)
            {
                var _random = Random.Shared.Next(0, test._cars.Count);
                test.CarInfo(_random);
                Console.WriteLine("------------------");
            }

            int _distance = 15;
            if (!_thread.IsAlive)
            {
                var _nearestPlayers = test.GetNearbyPlayers(_distance, test._cars[Random.Shared.Next(0, test._cars.Count)]);
                foreach (var _player in _nearestPlayers)
                {
                    Console.WriteLine(_player.Key.Name + ":" + (int)_player.Value);
                }
            }
        }
    }
}

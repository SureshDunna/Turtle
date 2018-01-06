using System;
using Turtle.Common;

namespace Turtle
{
    public interface ITurtle
    {
        void Move();
        void Left();
        void Right();
        string Report();
    }

    public class Turtle : ITurtle
    {
        private readonly ITable _table;
        private readonly IRotation _rotation;
        private readonly Position _currentPosition;
        private readonly Angle _rotationAngle;

        public Turtle(ITable table, IRotation rotation, Position position, Angle rotationAngle)
        {
            _table = table;
            _rotation = rotation;
            _currentPosition = position;
            _rotationAngle = rotationAngle;
        }

        public void Move()
        {
            var newPosition = new Position { X = _currentPosition.X, Y = _currentPosition.Y };

            switch(_currentPosition.Face)
            {
                case Face.EAST:
                    newPosition.X++;
                    break;
                case Face.WEST:
                    newPosition.X--;
                    break;
                case Face.NORTH:
                    newPosition.Y++;
                    break;
                case Face.SOUTH:
                    newPosition.Y--;
                    break;
            }

            if(!_table.IsPositionValid(newPosition))
            {
                throw new InvalidOperationException("Can't move anymore as I am at the edge of the table");
            }

            _currentPosition.X = newPosition.X;
            _currentPosition.Y = newPosition.Y;
        }

        public void Left()
        {
            _currentPosition.Face = _rotation.GetDirection(_currentPosition.Face, _rotationAngle, Direction.Left);
        }

        public void Right()
        {
            _currentPosition.Face = _rotation.GetDirection(_currentPosition.Face, _rotationAngle, Direction.Right);
        }

        public string Report()
        {
            return $"{_currentPosition.X}, {_currentPosition.Y}, {_currentPosition.Face}";
        }
    }
}

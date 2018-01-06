using System;
using System.Collections.Generic;
using Turtle.Common;

namespace Turtle
{
    public interface IRotation
    {
        Face GetDirection(Face currentFace, Angle angleRotation, Direction movingDirection);
    }

    public class Rotation : IRotation
    {
        public static readonly IRotation Instance = new Rotation();

        private readonly Dictionary<Tuple<Face, Angle, Direction>, Face> _directions;

        private Rotation()
        {
            _directions = new Dictionary<Tuple<Face, Angle, Direction>, Face>
            {
                { Tuple.Create(Face.EAST, Angle.Degree90, Direction.Left), Face.NORTH },
                { Tuple.Create(Face.EAST, Angle.Degree90, Direction.Right), Face.SOUTH },
                { Tuple.Create(Face.NORTH, Angle.Degree90, Direction.Left), Face.WEST },
                { Tuple.Create(Face.NORTH, Angle.Degree90, Direction.Right), Face.EAST },
                { Tuple.Create(Face.WEST, Angle.Degree90, Direction.Left), Face.SOUTH },
                { Tuple.Create(Face.WEST, Angle.Degree90, Direction.Right), Face.NORTH },
                { Tuple.Create(Face.SOUTH, Angle.Degree90, Direction.Left), Face.EAST },
                { Tuple.Create(Face.SOUTH, Angle.Degree90, Direction.Right), Face.WEST }
            };
        }

        public Face GetDirection(Face currentFace, Angle rotationAngle, Direction movingDirection)
        {
            var directionKey = Tuple.Create(currentFace, rotationAngle, movingDirection);

            if(!_directions.ContainsKey(directionKey))
            {
                throw new ArgumentException(nameof(directionKey));
            }

            return _directions[directionKey];
        }
    }
}

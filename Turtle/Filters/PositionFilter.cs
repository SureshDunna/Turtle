using System;
using Turtle.Common;
using Turtle.Exceptions;

namespace Turtle.Filters
{
    public interface IPositionFilter : IFilter
    {
        Position Position { get; set; }
    }

    public class PositionFilter : IPositionFilter
    {
        private const string Delimeter = ",";

        public Position Position { get; set; }

        public void Execute(string argumentTemplate)
        {
            if (string.IsNullOrWhiteSpace(argumentTemplate))
            {
                throw new BadCommandException();
            }

            var positionArguments = argumentTemplate.Split(new[] { Delimeter }, StringSplitOptions.RemoveEmptyEntries);

            if (positionArguments.Length != 3)
            {
                throw new BadCommandException();
            }

            if (!int.TryParse(positionArguments[0], out var positionX))
            {
                throw new BadCommandException();
            }

            if (!int.TryParse(positionArguments[1], out var positionY))
            {
                throw new BadCommandException();
            }

            if (!Enum.TryParse<Face>(positionArguments[2], true, out var face))
            {
                throw new BadCommandException();
            }

            Position = new Position
            {
                X = positionX,
                Y = positionY,
                Face = face
            };
        }
    }
}

using System;
using Turtle.Common;
using Turtle.Exceptions;

namespace Turtle.Filters
{
    public interface ITurtleFilter : IFilter
    {
        TurtleCommand TurtleCommand { get; set; }
        Position Position { get; set; }
    }

    public class TurtleFilter : ITurtleFilter
    {
        private const string CommandDelimeter = " ";

        private readonly IPositionFilter _positionFilter;

        public TurtleFilter(IPositionFilter positionFilter)
        {
            _positionFilter = positionFilter;
        }

        public TurtleCommand TurtleCommand { get; set; }
        public Position Position { get; set; }

        public void Execute(string turtleCommandTemplate)
        {
            if (string.IsNullOrWhiteSpace(turtleCommandTemplate))
            {
                throw new BadCommandException();
            }

            var turtleCommands = turtleCommandTemplate.Split(new[] { CommandDelimeter }, StringSplitOptions.RemoveEmptyEntries);

            if (turtleCommands.Length > 2)
            {
                throw new BadCommandException();
            }

            if (!Enum.TryParse<TurtleCommand>(turtleCommands[0], true, out var command))
            {
                throw new BadCommandException();
            }

            switch(command)
            {
                case TurtleCommand.PLACE:
                    if (turtleCommands.Length != 2)
                    {
                        throw new BadCommandException();
                    }

                    //validating the positioning arguments
                    _positionFilter.Execute(turtleCommands[1]);
                    break;
                default:
                    if (turtleCommands.Length != 1)
                    {
                        throw new BadCommandException();
                    }
                    break;
            }

            //all good and getting the command and position values
            TurtleCommand = command;
            Position = _positionFilter.Position;
        }
    }
}

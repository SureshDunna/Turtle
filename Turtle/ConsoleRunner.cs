using System;
using Turtle.Common;
using Turtle.Filters;

namespace Turtle
{
    public class ConsoleRunner
    {
        private ITurtle _turtle;

        private readonly ITurtleFilter _turtleFilter;
        private readonly IRotation _rotation;
        private readonly ITable _table;

        public ConsoleRunner()
        {
            _turtleFilter = new TurtleFilter(new PositionFilter());
            _rotation = Rotation.Instance;
            _table = new Table(TableDimensions.Size); //Table is defined with size
        }

        public void Execute(string userInput, Action<string> writeOutput)
        {
            _turtleFilter.Execute(userInput);

            switch (_turtleFilter.TurtleCommand)
            {
                case TurtleCommand.PLACE:
                    if (_turtle != null)
                    {
                        throw new InvalidOperationException("Turtle has already been placed and please try other commands.");
                    }

                    //Turtle is defined and getting placed on the table now
                    _turtle = new Turtle(_table, _rotation, _turtleFilter.Position, TurtleMovements.RotationAngle);
                    break;
                case TurtleCommand.LEFT:
                    if (_turtle == null)
                    {
                        throw new InvalidOperationException("Turtle has not been placed and please place before runnig this command.");
                    }

                    _turtle.Left();
                    break;
                case TurtleCommand.RIGHT:
                    if (_turtle == null)
                    {
                        throw new InvalidOperationException("Turtle has not been placed and please place before runnig this command.");
                    }

                    _turtle.Right();
                    break;
                case TurtleCommand.MOVE:
                    if (_turtle == null)
                    {
                        throw new InvalidOperationException("Turtle has not been placed and please place before runnig this command.");
                    }

                    _turtle.Move();
                    break;
                case TurtleCommand.REPORT:
                    if (_turtle == null)
                    {
                        throw new InvalidOperationException("Turtle has not been placed and please place before runnig this command.");
                    }

                    writeOutput(_turtle.Report());
                    break;
            }
        }
    }
}

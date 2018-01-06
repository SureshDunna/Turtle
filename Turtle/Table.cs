using System;

namespace Turtle
{
    public interface ITable
    {
        bool IsPositionValid(Position position);
    }

    public class Table : Square, ITable
    {
        public Table(int size): base(size)
        {
        }

        public bool IsPositionValid(Position position)
        {
            if(position == null)
            {
                throw new ArgumentNullException(nameof(position));
            }

            if(position.X > Size || position.Y > Size)
            {
                return false;
            }

            if(position.X < 0 || position.Y < 0)
            {
                return false;
            }

            return true;
        }
    }
}

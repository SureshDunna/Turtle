using System.Diagnostics.CodeAnalysis;

namespace Turtle
{
    [ExcludeFromCodeCoverage]
    public abstract class Square
    {
        protected int Size { get; private set; }

        public Square(int size)
        {
            Size = size;
        }
    }
}
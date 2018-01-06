using System.Diagnostics.CodeAnalysis;
using Turtle.Common;

namespace Turtle
{
    [ExcludeFromCodeCoverage]
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Face Face { get; set; }
    }
}

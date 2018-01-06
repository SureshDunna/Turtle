using System;
using Xunit;

namespace Turtle.UnitTests
{
    public class TableTests
    {
        private readonly ITable _table = new Table(5);

        [Fact]
        public void must_throw_exception_if_position_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => _table.IsPositionValid(null));
        }

        [Fact]
        public void is_not_valid_when_x_position_greater_than_size()
        {
            Assert.False(_table.IsPositionValid(new Position { X = 6 }));
        }

        [Fact]
        public void is_not_valid_when_y_position_greater_than_size()
        {
            Assert.False(_table.IsPositionValid(new Position { Y = 6 }));
        }

        [Fact]
        public void is_not_valid_when_x_position_less_than_zero()
        {
            Assert.False(_table.IsPositionValid(new Position { X = -1 }));
        }
        [Fact]
        public void is_not_valid_when_y_position_less_than_zero()
        {
            Assert.False(_table.IsPositionValid(new Position { Y = -1 }));
        }

        [Fact]
        public void is_valid_when_x_and_y_position_within_table_area()
        {
            Assert.True(_table.IsPositionValid(new Position { X = 0, Y = 5 }));
        }
    }
}

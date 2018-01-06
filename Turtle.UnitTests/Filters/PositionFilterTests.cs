using Turtle.Common;
using Turtle.Exceptions;
using Turtle.Filters;
using Xunit;

namespace Turtle.UnitTests.Filters
{
    public class PositionFilterTests
    {
        private readonly IPositionFilter _positionFilter = new PositionFilter();

        [Fact]
        public void bad_command_when_argument_template_empty_or_null()
        {
            Assert.Throws<BadCommandException>(() => _positionFilter.Execute(string.Empty));
            Assert.Throws<BadCommandException>(() => _positionFilter.Execute(null));
        }

        [InlineData("1")]
        [InlineData("1,2")]
        [InlineData("1,2,3,4")]
        [Theory]
        public void bad_command_when_argument_parameters_length_not_equal_three(string argumentTemplate)
        {
            Assert.Throws<BadCommandException>(() => _positionFilter.Execute(argumentTemplate));
        }

        [Fact]
        public void bad_command_when_first_argument_is_not_number()
        {
            Assert.Throws<BadCommandException>(() => _positionFilter.Execute("one,2,North"));
        }

        [Fact]
        public void bad_command_when_second_argument_is_not_number()
        {
            Assert.Throws<BadCommandException>(() => _positionFilter.Execute("1,two,North"));
        }

        [Fact]
        public void bad_command_when_third_argument_is_not_valid()
        {
            Assert.Throws<BadCommandException>(() => _positionFilter.Execute("1,2,invalidface"));
        }

        [InlineData("1,1,EAST", 1, 1, Face.EAST)]
        [InlineData("1,2,WEST", 1, 2, Face.WEST)]
        [InlineData("3,4,NORTH", 3, 4, Face.NORTH)]
        [InlineData("0,5,SOUTH", 0, 5, Face.SOUTH)]
        [Theory]
        public void can_return_position_if_arguments_are_valid(string argumentTemplate, int x, int y, Face face)
        {
            _positionFilter.Execute(argumentTemplate);

            var position = _positionFilter.Position;

            Assert.Equal(x, position.X);
            Assert.Equal(y, position.Y);
            Assert.Equal(face, position.Face);
        }
    }
}

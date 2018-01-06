using Moq;
using Turtle.Common;
using Turtle.Exceptions;
using Turtle.Filters;
using Xunit;

namespace Turtle.UnitTests.Filters
{
    public class TurtleFilterTests
    {
        private readonly ITurtleFilter _turtleFilter;

        private readonly Mock<IPositionFilter> _positionFilter;

        public TurtleFilterTests()
        {
            _positionFilter = new Mock<IPositionFilter>();

            _turtleFilter = new TurtleFilter(_positionFilter.Object);
        }

        [Fact]
        public void bad_command_when_argument_template_empty_or_null()
        {
            Assert.Throws<BadCommandException>(() => _turtleFilter.Execute(string.Empty));
            Assert.Throws<BadCommandException>(() => _turtleFilter.Execute(null));
        }

        [InlineData("command1 command2 command3")]
        [InlineData("command1 command2 command3 command4")]
        [Theory]
        public void bad_command_when_argument_parameters_count_is_not_valid(string argumentTemplate)
        {
            Assert.Throws<BadCommandException>(() => _turtleFilter.Execute(argumentTemplate));
        }

        [Fact]
        public void bad_command_when_invalid_turtle_command()
        {
            Assert.Throws<BadCommandException>(() => _turtleFilter.Execute("invalidturtlecommand 1,2,North"));
        }

        [Fact]
        public void bad_command_when_no_position_argument_found_for_place_command()
        {
            Assert.Throws<BadCommandException>(() => _turtleFilter.Execute("Place"));
        }

        [InlineData("Move 1,2,EAST")]
        [InlineData("Left 1,2,EAST")]
        [InlineData("Right 1,2,EAST")]
        [InlineData("Report 1,2,EAST")]
        [Theory]
        public void bad_command_when_position_argument_found_for_non_place_command(string argumentTemplate)
        {
            Assert.Throws<BadCommandException>(() => _turtleFilter.Execute(argumentTemplate));
        }

        [Fact]
        public void bad_command_when_position_argument_throws_bad_command()
        {
            _positionFilter.Setup(x => x.Execute(It.IsAny<string>())).Throws<BadCommandException>();

            Assert.Throws<BadCommandException>(() => _turtleFilter.Execute("Place 1"));
        }

        [InlineData("Place 1,2,EAST", TurtleCommand.PLACE)]
        [InlineData("Move", TurtleCommand.MOVE)]
        [InlineData("Left", TurtleCommand.LEFT)]
        [InlineData("Right", TurtleCommand.RIGHT)]
        [InlineData("Report", TurtleCommand.REPORT)]
        [Theory]
        public void can_return_command_and_position_if_arguments_are_valid(string argumentTemplate, TurtleCommand command)
        {
            _turtleFilter.Execute(argumentTemplate);

            Assert.Equal(command, _turtleFilter.TurtleCommand);
        }
    }
}

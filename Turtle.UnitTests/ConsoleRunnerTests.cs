using System;
using Xunit;

namespace Turtle.UnitTests
{
    public class ConsoleRunnerTests
    {
        [Fact]
        public void cannot_place_turtle_if_its_already_placed_on_table()
        {
            var consoleRunner = new ConsoleRunner();

            consoleRunner.Execute("PLace 1,2,EAST", null);

            Assert.Throws<InvalidOperationException>(() => consoleRunner.Execute("PLace 1,2,EAST", null));
        }

        [Fact]
        public void can_place_turtle_on_the_table()
        {
            var consoleRunner = new ConsoleRunner();

            var reportedValue = string.Empty;

            consoleRunner.Execute("PLace 1,2,EAST", (textToOutput) => { reportedValue = textToOutput;  });
            consoleRunner.Execute("Report", (textToOutput) => { reportedValue = textToOutput; });

            Assert.Equal("1, 2, EAST", reportedValue);
        }

        [Fact]
        public void cannot_issue_left_command_if_turtle_is_not_place_on_the_table()
        {
            Assert.Throws<InvalidOperationException>(() => new ConsoleRunner().Execute("LEFT", null));
        }

        [Fact]
        public void cannot_issue_right_command_if_turtle_is_not_place_on_the_table()
        {
            Assert.Throws<InvalidOperationException>(() => new ConsoleRunner().Execute("Right", null));
        }

        [Fact]
        public void cannot_issue_move_command_if_turtle_is_not_place_on_the_table()
        {
            Assert.Throws<InvalidOperationException>(() => new ConsoleRunner().Execute("Move", null));
        }

        [Fact]
        public void cannot_issue_report_command_if_turtle_is_not_place_on_the_table()
        {
            Assert.Throws<InvalidOperationException>(() => new ConsoleRunner().Execute("Report", null));
        }
        
        [InlineData("Place 1,1,EAST", "Move", "2, 1, EAST")]
        [InlineData("Place 2,1,West", "Left", "2, 1, SOUTH")]
        [InlineData("Place 3,4,South", "Right", "3, 4, WEST")]
        [Theory]
        public void can_turtle_move_on_the_table_if_commands_are_valid(string placeCommand, string subSequencialCommand, string expectedReportedValue)
        {
            var consoleRunner = new ConsoleRunner();

            var actualReportedValue = string.Empty;

            consoleRunner.Execute(placeCommand, (textToOutput) => { actualReportedValue = textToOutput; });
            consoleRunner.Execute(subSequencialCommand, (textToOutput) => { actualReportedValue = textToOutput; });
            consoleRunner.Execute("Report", (textToOutput) => { actualReportedValue = textToOutput; });

            Assert.Equal(expectedReportedValue, actualReportedValue);
        }
    }
}

using Moq;
using System;
using Xunit;

namespace Turtle.UnitTests
{
    public class TurtleTests
    {
        private readonly Mock<ITable> _table;
        private readonly Mock<IRotation> _rotation;

        public TurtleTests()
        {
            _table = new Mock<ITable>();
            _rotation = new Mock<IRotation>();


            _rotation.Setup(x => x.GetDirection(Common.Face.EAST, Common.Angle.Degree90, Common.Direction.Left)).Returns(Common.Face.NORTH);
            _rotation.Setup(x => x.GetDirection(Common.Face.NORTH, Common.Angle.Degree90, Common.Direction.Left)).Returns(Common.Face.WEST);
            _rotation.Setup(x => x.GetDirection(Common.Face.WEST, Common.Angle.Degree90, Common.Direction.Left)).Returns(Common.Face.SOUTH);
            _rotation.Setup(x => x.GetDirection(Common.Face.SOUTH, Common.Angle.Degree90, Common.Direction.Left)).Returns(Common.Face.EAST);

            _rotation.Setup(x => x.GetDirection(Common.Face.EAST, Common.Angle.Degree90, Common.Direction.Right)).Returns(Common.Face.SOUTH);
            _rotation.Setup(x => x.GetDirection(Common.Face.NORTH, Common.Angle.Degree90, Common.Direction.Right)).Returns(Common.Face.EAST);
            _rotation.Setup(x => x.GetDirection(Common.Face.WEST, Common.Angle.Degree90, Common.Direction.Right)).Returns(Common.Face.NORTH);
            _rotation.Setup(x => x.GetDirection(Common.Face.SOUTH, Common.Angle.Degree90, Common.Direction.Right)).Returns(Common.Face.WEST);
        }

        [Fact]
        public void can_place_turtle_on_table()
        {
            var turtle = new Turtle(_table.Object, _rotation.Object, new Position { X = 1, Y = 1, Face = Common.Face.EAST }, Common.Angle.Degree90);

            var reportedPosition = turtle.Report();

            Assert.Equal("1, 1, EAST", reportedPosition);
        }

        [Fact]
        public void can_move_to_east_direction()
        {
            var turtle = new Turtle(_table.Object, _rotation.Object, new Position { X = 1, Y = 1, Face = Common.Face.EAST }, Common.Angle.Degree90);

            _table.Setup(x => x.IsPositionValid(It.IsAny<Position>())).Returns(true);

            turtle.Move();

            var reportedPosition = turtle.Report();

            Assert.Equal("2, 1, EAST", reportedPosition);
        }

        [Fact]
        public void can_move_to_west_direction()
        {
            var turtle = new Turtle(_table.Object, _rotation.Object, new Position { X = 1, Y = 1, Face = Common.Face.WEST }, Common.Angle.Degree90);

            _table.Setup(x => x.IsPositionValid(It.IsAny<Position>())).Returns(true);

            turtle.Move();

            var reportedPosition = turtle.Report();

            Assert.Equal("0, 1, WEST", reportedPosition);
        }

        [Fact]
        public void can_move_to_north_direction()
        {
            var turtle = new Turtle(_table.Object, _rotation.Object, new Position { X = 1, Y = 1, Face = Common.Face.NORTH }, Common.Angle.Degree90);

            _table.Setup(x => x.IsPositionValid(It.IsAny<Position>())).Returns(true);

            turtle.Move();

            var reportedPosition = turtle.Report();

            Assert.Equal("1, 2, NORTH", reportedPosition);
        }

        [Fact]
        public void can_move_to_south_direction()
        {
            var turtle = new Turtle(_table.Object, _rotation.Object, new Position { X = 1, Y = 1, Face = Common.Face.SOUTH }, Common.Angle.Degree90);

            _table.Setup(x => x.IsPositionValid(It.IsAny<Position>())).Returns(true);

            turtle.Move();

            var reportedPosition = turtle.Report();

            Assert.Equal("1, 0, SOUTH", reportedPosition);
        }

        [Fact]
        public void cannot_move_to_south_direction_if_its_in_edge()
        {
            var turtle = new Turtle(_table.Object, _rotation.Object, new Position { X = 1, Y = 0, Face = Common.Face.SOUTH }, Common.Angle.Degree90);

            Assert.Throws<InvalidOperationException>(() => turtle.Move());

            var reportedPosition = turtle.Report();

            Assert.Equal("1, 0, SOUTH", reportedPosition);
        }

        [Fact]
        public void cannot_move_to_north_direction_if_its_in_edge()
        {
            var turtle = new Turtle(_table.Object, _rotation.Object, new Position { X = 1, Y = 0, Face = Common.Face.NORTH }, Common.Angle.Degree90);

            Assert.Throws<InvalidOperationException>(() => turtle.Move());

            var reportedPosition = turtle.Report();

            Assert.Equal("1, 0, NORTH", reportedPosition);
        }

        [Fact]
        public void cannot_move_to_east_direction_if_its_in_edge()
        {
            var turtle = new Turtle(_table.Object, _rotation.Object, new Position { X = 5, Y = 0, Face = Common.Face.EAST }, Common.Angle.Degree90);

            Assert.Throws<InvalidOperationException>(() => turtle.Move());

            var reportedPosition = turtle.Report();

            Assert.Equal("5, 0, EAST", reportedPosition);
        }

        [Fact]
        public void cannot_move_to_west_direction_if_its_in_edge()
        {
            var turtle = new Turtle(_table.Object, _rotation.Object, new Position { X = 0, Y = 0, Face = Common.Face.WEST }, Common.Angle.Degree90);

            Assert.Throws<InvalidOperationException>(() => turtle.Move());

            var reportedPosition = turtle.Report();

            Assert.Equal("0, 0, WEST", reportedPosition);
        }

        [Fact]
        public void can_move_to_right_direction_from_east_direction()
        {
            var turtle = new Turtle(_table.Object, _rotation.Object, new Position { X = 1, Y = 1, Face = Common.Face.EAST }, Common.Angle.Degree90);

            turtle.Right();

            var reportedPosition = turtle.Report();

            Assert.Equal("1, 1, SOUTH", reportedPosition);
        }

        [Fact]
        public void can_move_to_right_direction_from_west_direction()
        {
            var turtle = new Turtle(_table.Object, _rotation.Object, new Position { X = 1, Y = 1, Face = Common.Face.WEST }, Common.Angle.Degree90);

            turtle.Right();

            var reportedPosition = turtle.Report();

            Assert.Equal("1, 1, NORTH", reportedPosition);
        }

        [Fact]
        public void can_move_to_right_direction_from_north_direction()
        {
            var turtle = new Turtle(_table.Object, _rotation.Object, new Position { X = 1, Y = 1, Face = Common.Face.NORTH }, Common.Angle.Degree90);

            turtle.Right();

            var reportedPosition = turtle.Report();

            Assert.Equal("1, 1, EAST", reportedPosition);
        }

        [Fact]
        public void can_move_to_right_direction_from_south_direction()
        {
            var turtle = new Turtle(_table.Object, _rotation.Object, new Position { X = 1, Y = 1, Face = Common.Face.SOUTH }, Common.Angle.Degree90);

            turtle.Right();

            var reportedPosition = turtle.Report();

            Assert.Equal("1, 1, WEST", reportedPosition);
        }

        [Fact]
        public void can_move_to_left_direction_from_east_direction()
        {
            var turtle = new Turtle(_table.Object, _rotation.Object, new Position { X = 1, Y = 1, Face = Common.Face.EAST }, Common.Angle.Degree90);

            turtle.Left();

            var reportedPosition = turtle.Report();

            Assert.Equal("1, 1, NORTH", reportedPosition);
        }

        [Fact]
        public void can_move_to_left_direction_from_west_direction()
        {
            var turtle = new Turtle(_table.Object, _rotation.Object, new Position { X = 1, Y = 1, Face = Common.Face.WEST }, Common.Angle.Degree90);

            turtle.Left();

            var reportedPosition = turtle.Report();

            Assert.Equal("1, 1, SOUTH", reportedPosition);
        }

        [Fact]
        public void can_move_to_left_direction_from_north_direction()
        {
            var turtle = new Turtle(_table.Object, _rotation.Object, new Position { X = 1, Y = 1, Face = Common.Face.NORTH }, Common.Angle.Degree90);

            turtle.Left();

            var reportedPosition = turtle.Report();

            Assert.Equal("1, 1, WEST", reportedPosition);
        }

        [Fact]
        public void can_move_to_left_direction_from_south_direction()
        {
            var turtle = new Turtle(_table.Object, _rotation.Object, new Position { X = 1, Y = 1, Face = Common.Face.SOUTH }, Common.Angle.Degree90);

            turtle.Left();

            var reportedPosition = turtle.Report();

            Assert.Equal("1, 1, EAST", reportedPosition);
        }
    }
}

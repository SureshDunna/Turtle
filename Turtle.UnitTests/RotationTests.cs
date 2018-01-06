using Xunit;

namespace Turtle.UnitTests
{
    public class RotationTests
    {
        private readonly IRotation _rotation = Rotation.Instance;

        [Fact]
        public void can_move_to_left_direction_from_east_direction()
        {
            Assert.Equal(Common.Face.NORTH, _rotation.GetDirection(Common.Face.EAST, Common.Angle.Degree90, Common.Direction.Left));
        }

        [Fact]
        public void can_move_to_left_direction_from_north_direction()
        {
            Assert.Equal(Common.Face.WEST, _rotation.GetDirection(Common.Face.NORTH, Common.Angle.Degree90, Common.Direction.Left));
        }

        [Fact]
        public void can_move_to_left_direction_from_west_direction()
        {
            Assert.Equal(Common.Face.SOUTH, _rotation.GetDirection(Common.Face.WEST, Common.Angle.Degree90, Common.Direction.Left));
        }

        [Fact]
        public void can_move_to_left_direction_from_south_direction()
        {
            Assert.Equal(Common.Face.EAST, _rotation.GetDirection(Common.Face.SOUTH, Common.Angle.Degree90, Common.Direction.Left));
        }

        [Fact]
        public void can_move_to_right_direction_from_east_direction()
        {
            Assert.Equal(Common.Face.SOUTH, _rotation.GetDirection(Common.Face.EAST, Common.Angle.Degree90, Common.Direction.Right));
        }

        [Fact]
        public void can_move_to_right_direction_from_north_direction()
        {
            Assert.Equal(Common.Face.EAST, _rotation.GetDirection(Common.Face.NORTH, Common.Angle.Degree90, Common.Direction.Right));
        }

        [Fact]
        public void can_move_to_right_direction_from_west_direction()
        {
            Assert.Equal(Common.Face.NORTH, _rotation.GetDirection(Common.Face.WEST, Common.Angle.Degree90, Common.Direction.Right));
        }

        [Fact]
        public void can_move_to_right_direction_from_south_direction()
        {
            Assert.Equal(Common.Face.WEST, _rotation.GetDirection(Common.Face.SOUTH, Common.Angle.Degree90, Common.Direction.Right));
        }
    }
}

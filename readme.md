# Turtle
The application is a simulation of a turtle moving on a square tabletop.

There are no other obstructions on the table surface.

The turtle is free to roam around the surface of the table, it is prevented from
falling to destruction and further valid movement commands are still be allowed.

Application that can read in commands of the following form:

- PLACE X,Y,F
- MOVE
- LEFT
- RIGHT
- REPORT

PLACE will put the turtle on the table in position X,Y and facing NORTH, SOUTH, EAST or
WEST.

The first valid command to the turtle is a PLACE command, after that, any sequence of
commands may be issued, in any order, including another PLACE command. The application
discards all commands in the sequence until a valid PLACE command has been executed with valid message.

MOVE will move the turtle one unit forward in the direction it is currently facing.
LEFT and RIGHT will rotate the turtle 90 degrees in the specified direction without changing
the position of the turtle.

REPORT will announce the X,Y and F of the turtle in standard output.

A turtle that is not on the table ignores the MOVE, LEFT, RIGHT and REPORT commands.

Input can be from a file or from standard input. 

## Example Input and Output:
```
-- - Input -- -
PLACE 0,0,NORTH
MOVE
REPORT

-- - Output -- -
0,1,NORTH

-- - Input -- -
PLACE 0,0,NORTH
LEFT
REPORT

-- - Output -- -
0,0,WEST

-- - Input -- -
PLACE 1,2,EAST
MOVE
MOVE
LEFT
MOVE
REPORT

-- - Output -- -
3,3,NORTH
```



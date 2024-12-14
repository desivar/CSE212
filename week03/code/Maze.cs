/// <summary>
/// Defines a maze using a dictionary. The dictionary will contain the following mapping:
///
/// (x, y) : [left, right, up, down]
///
/// 'x' and 'y' are integers representing locations in the maze.
/// Each boolean value in the array indicates if the direction is passable.
/// Throws an InvalidOperationException if movement is not allowed.
/// </summary>
public class Maze
{
    private readonly Dictionary<(int, int), bool[]> _mazeMap;
    private int _currX;
    private int _currY;

    public Maze(Dictionary<(int, int), bool[]> mazeMap, int startX = 1, int startY = 1)
    {
        // Validate all entries in the dictionary
        foreach (var entry in mazeMap.Values)
        {
            if (entry.Length != 4)
            {
                throw new ArgumentException("Each value in the maze map must have exactly 4 elements representing directions.");
            }
        }

        _mazeMap = mazeMap;

        // Ensure the starting position is valid
        if (!_mazeMap.ContainsKey((startX, startY)))
        {
            throw new ArgumentException("Starting position is invalid. It does not exist in the maze map.");
        }

        _currX = startX;
        _currY = startY;
    }

    public void MoveLeft()
    {
        MoveInDirection(0, -1, 0);
    }

    public void MoveRight()
    {
        MoveInDirection(1, 1, 0);
    }

    public void MoveUp()
    {
        MoveInDirection(2, 0, -1);
    }

    public void MoveDown()
    {
        MoveInDirection(3, 0, 1);
    }

    private void MoveInDirection(int directionIndex, int deltaX, int deltaY)
    {
        if (_mazeMap.TryGetValue((_currX, _currY), out var directions) && directions[directionIndex])
        {
            _currX += deltaX;
            _currY += deltaY;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    public string GetStatus()
    {
        return $"Current location: (x={_currX}, y={_currY})";
    }
}

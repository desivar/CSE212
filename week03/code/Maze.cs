/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represent locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean values that represent valid directions.
///
/// If a direction is false, there is a wall in that direction, and an 
/// InvalidOperationException is thrown with the message "Can't go that way!".  
/// If there is no wall, the 'currX' and 'currY' values are updated.
/// </summary>
public class Maze
{
    private readonly Dictionary<(int, int), bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<(int, int), bool[]> mazeMap)
    {
        // Validate that all bool[] entries have exactly 4 elements
        foreach (var entry in mazeMap.Values)
        {
            if (entry.Length != 4)
            {
                throw new ArgumentException("Each value in the maze map must have exactly 4 elements representing directions.");
            }
        }

        _mazeMap = mazeMap;
    }

    public void MoveLeft()
    {
        if (_mazeMap.TryGetValue((_currX, _currY), out var directions) && directions[0])
        {
            _currX -= 1;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    public void MoveRight()
    {
        if (_mazeMap.TryGetValue((_currX, _currY), out var directions) && directions[1])
        {
            _currX += 1;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    public void MoveUp()
    {
        if (_mazeMap.TryGetValue((_currX, _currY), out var directions) && directions[2])
        {
            _currY -= 1;
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    public void MoveDown()
    {
        if (_mazeMap.TryGetValue((_currX, _currY), out var directions) && directions[3])
        {
            _currY += 1;
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

   
        
       

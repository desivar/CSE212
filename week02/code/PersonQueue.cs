/// <summary>
/// A basic implementation of a Queue.
/// </summary>
public class PersonQueue
{
    private readonly List<Person> _queue = new();

    public int Length => _queue.Count;

    /// <summary>
    /// Add a person to the queue.
    /// </summary>
    /// <param name="person">The person to add.</param>
    public void Enqueue(Person person)
    {
        _queue.Add(person); // Add to the end of the list
    }

    /// <summary>
    /// Remove a person from the queue.
    /// </summary>
    /// <returns>The person removed from the front of the queue.</returns>
    public Person Dequeue()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Queue is empty.");
        }

        var person = _queue[0]; // Get the first person
        _queue.RemoveAt(0); // Remove from the front
        return person;
    }

    /// <summary>
    /// Check if the queue is empty.
    /// </summary>
    /// <returns>True if the queue is empty; otherwise, false.</returns>
    public bool IsEmpty()
    {
        return _queue.Count == 0;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}


  

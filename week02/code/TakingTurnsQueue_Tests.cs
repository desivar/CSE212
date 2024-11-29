using System;
using System.Collections.Generic;

public class TakingTurnsQueue
{
    private readonly Queue<Person> _people = new();

    public int Length => _people.Count;

    /// <summary>
    /// Add new people to the queue with a name and number of turns.
    /// </summary>
    /// <param name="name">Name of the person.</param>
    /// <param name="turns">Number of turns remaining. 0 or negative indicates infinite turns.</param>
    public void AddPerson(string name, int turns)
    {
        _people.Enqueue(new Person(name, turns));
    }

    /// <summary>
    /// Get the next person in the queue and return them. The person should
    /// go to the back of the queue again unless their turn count has expired.
    /// </summary>
    /// <returns>The next person in the queue.</returns>
    public Person GetNextPerson()
    {
        if (_people.Count == 0)
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        var person = _people.Dequeue();

        if (person.Turns <= 0 || person.Turns > 1)
        {
            if (person.Turns > 1)
            {
                person.Turns--; // Decrement for finite turns
            }

            _people.Enqueue(person); // Re-enqueue person with remaining or infinite turns
        }

        return person;
    }
}

public class Person
{
    public string Name { get; private set; }
    public int Turns { get; set; }

    public Person(string name, int turns)
    {
        Name = name;
        Turns = turns;
    }

    public override string ToString()
    {
        return $"{Name} ({Turns})";
    }
}

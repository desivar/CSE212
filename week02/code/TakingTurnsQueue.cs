using System;

public class TakingTurnsQueue {
    private readonly PersonQueue _people = new PersonQueue();

    public int Length => _people.Length;

    public void AddPerson(string name, int turns) {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    public void GetNextPerson() {
        if (_people.IsEmpty())
            Console.WriteLine("No one in the queue.");
        else {
            Person person = _people.Dequeue();
            if (person.Turns > 1 || person.Turns <= 0) {
                person.Turns -= 1;
                _people.Enqueue(person);
            }
            else
                Console.WriteLine($"{person.Name} has no more turns.");
        }
    }

    public override string ToString() {
        return _people.ToString();
    }
}

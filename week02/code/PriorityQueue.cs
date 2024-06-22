public class PriorityQueue<T>
{
    private class PriorityQueueItem : IComparable<PriorityQueueItem>
    {
        public T Item { get; }
        public int Priority { get; }

        public PriorityQueueItem(T item, int priority)
        {
            Item = item;
            Priority = priority;
        }

        public int CompareTo(PriorityQueueItem other)
        {
            // Compare based on priority (lower values have higher priority)
            return Priority.CompareTo(other.Priority);
        }
    }

    private readonly PriorityQueue<PriorityQueueItem> _inner = new PriorityQueue<PriorityQueueItem>();

    public void Enqueue(T item, int priority)
    {
        _inner.Enqueue(new PriorityQueueItem(item, priority));
    }

    public T Dequeue()
    {
        return _inner.Dequeue().Item;
    }
}

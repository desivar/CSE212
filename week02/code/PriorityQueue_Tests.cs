using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue multiple items with different priorities.
    // Expected Result: Items are dequeued in the order of their priority (lowest value first).
    public void TestPriorityQueue_EnqueueDequeue()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low priority", 3);
        priorityQueue.Enqueue("High priority", 1);
        priorityQueue.Enqueue("Medium priority", 2);

        Assert.AreEqual("High priority", priorityQueue.Dequeue());
        Assert.AreEqual("Medium priority", priorityQueue.Dequeue());
        Assert.AreEqual("Low priority", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from an empty queue.
    // Expected Result: An InvalidOperationException is thrown with the message "Queue is empty."
    public void TestPriorityQueue_EmptyDequeue()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                string.Format("Unexpected exception of type {0} caught: {1}",
                e.GetType(), e.Message)
            );
        }
    }

    [TestMethod]
    // Scenario: Check if the queue is empty after enqueuing and dequeuing all items.
    // Expected Result: The queue should be empty.
    public void TestPriorityQueue_IsEmpty()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item", 1);
        priorityQueue.Dequeue();

        Assert.IsTrue(priorityQueue.Count == 0);
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the same priority.
    // Expected Result: Items with the same priority are dequeued in the order they were added.
    public void TestPriorityQueue_SamePriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item 1", 1);
        priorityQueue.Enqueue("Item 2", 1);
        priorityQueue.Enqueue("Item 3", 1);

        Assert.AreEqual("Item 1", priorityQueue.Dequeue());
        Assert.AreEqual("Item 2", priorityQueue.Dequeue());
        Assert.AreEqual("Item 3", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items with varying priorities and dequeue multiple items in a row.
    // Expected Result: Dequeue should consistently return the correct items in priority order.
    public void TestPriorityQueue_ComplexEnqueueDequeue()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item 4", 4);
        priorityQueue.Enqueue("Item 1", 1);
        priorityQueue.Enqueue("Item 3", 3);
        priorityQueue.Enqueue("Item 2", 2);

        Assert.AreEqual("Item 1", priorityQueue.Dequeue());
        Assert.AreEqual("Item 2", priorityQueue.Dequeue());
        priorityQueue.Enqueue("Item 0", 0);
        Assert.AreEqual("Item 0", priorityQueue.Dequeue());
        Assert.AreEqual("Item 3", priorityQueue.Dequeue());
        Assert.AreEqual("Item 4", priorityQueue.Dequeue());
    }
}


       
   
   

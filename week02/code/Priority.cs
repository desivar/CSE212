public static class Priority {
    public static void Test() {
        // TODO Problem 2 - Write and run test cases and fix the code to match requirements
        // Example of creating and using the priority queue
        var priorityQueue = new PriorityQueue();
        Console.WriteLine(priorityQueue);

        // Test Cases

        // Test 1
        // Scenario: Create a queue with multiple priorities and confirm they were correctly added, value and priority
        // Expected Result: Banana.
        Console.WriteLine("Test 1");
        priorityQueue.Enqueue("Banana-1.1",1);
        priorityQueue.Enqueue("Apple-3.1",3);
        priorityQueue.Enqueue("Cherry-2.1",2);
        
        Console.WriteLine(priorityQueue);
        
        // Defect(s) Found: 
        // Pass - values and priorities are correctly added to the queue.
        Console.WriteLine("---------");

        // Test 2
    
        // Scenario: Calling dequeue from empty list should retun error message
        // Expected Result: The queue is empty.
        Console.WriteLine("Test 4");
        priorityQueue = new PriorityQueue();
        Console.WriteLine(priorityQueue.Dequeue());
        // Defect(s) Found: 
        // Pass. calling Dequeue method on an empty queue shows the message
        Console.WriteLine("---------");
    }
}

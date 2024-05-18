using System;
using System.Collections.Generic;
using System.Linq;

namespace prove_04
{
    public class PriorityQueueItem<T>
    {
        public T Data { get; set; }
        public int Priority { get; set; }
    }

    public class PriorityQueue<T>
    {
        private List<PriorityQueueItem<T>> items = new List<PriorityQueueItem<T>>();

        // Enqueue with priority
        public void Enqueue(T data, int priority)
        {
            items.Add(new PriorityQueueItem<T> { Data = data, Priority = priority });
        }

        // Dequeue the highest priority item
        public T Dequeue()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("Error: The queue is empty.");
                return default(T);
            }

            var highestPriorityItem = items.OrderByDescending(i => i.Priority).ThenBy(i => items.IndexOf(i)).First();
            items.Remove(highestPriorityItem);
            return highestPriorityItem.Data;
        }
    }

    public static class Priority
    {
        public static void Test()
        {
            var priorityQueue = new PriorityQueue<string>();

            // Test 1: Basic functionality
            // Scenario: Enqueue items with different priorities and dequeue them
            // Expected Result: Items are dequeued in order of highest priority first
            Console.WriteLine("Test 1");
            priorityQueue.Enqueue("LowPriority", 1);
            priorityQueue.Enqueue("HighPriority", 10);
            Console.WriteLine(priorityQueue.Dequeue() == "HighPriority"); // High priority should be dequeued first
            Console.WriteLine(priorityQueue.Dequeue() == "LowPriority");  // Then low priority
            Console.WriteLine("---------");

            // Test 2: Same priority, FIFO
            // Scenario: Enqueue items with the same priority and dequeue them
            // Expected Result: Items are dequeued in the order they were enqueued (FIFO)
            Console.WriteLine("Test 2");
            priorityQueue.Enqueue("First", 5);
            priorityQueue.Enqueue("Second", 5);
            Console.WriteLine(priorityQueue.Dequeue() == "First"); // "First" should be dequeued before "Second"
            Console.WriteLine(priorityQueue.Dequeue() == "Second");
            Console.WriteLine("---------");

            // Test 3: Empty queue
            // Scenario: Dequeue from an empty queue
            // Expected Result: Error message is displayed
            Console.WriteLine("Test 3");
            Console.WriteLine(priorityQueue.Dequeue() == null); // Should print error and return null
            Console.WriteLine("---------");

            // Additional test cases
            Console.WriteLine("Additional Tests");
            priorityQueue.Enqueue("A", 3);
            priorityQueue.Enqueue("B", 2);
            priorityQueue.Enqueue("C", 3);
            priorityQueue.Enqueue("D", 1);
            Console.WriteLine(priorityQueue.Dequeue() == "A"); // "A" and "C" have the same priority, "A" first
            Console.WriteLine(priorityQueue.Dequeue() == "C"); // Then "C"
            Console.WriteLine(priorityQueue.Dequeue() == "B"); // Then "B"
            Console.WriteLine(priorityQueue.Dequeue() == "D"); // Finally "D"
        }
    }
}
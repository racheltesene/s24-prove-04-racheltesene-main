using System;
using System.Collections.Generic;

namespace prove_04
{
    public class Person
    {
        public string Name { get; set; }
        public int Turns { get; set; }
    }

    public class TakingTurnsQueue
    {
        private Queue<Person> queue = new Queue<Person>();

        public int Length => queue.Count;

        // Add a person to the queue
        public void AddPerson(string name, int turns)
        {
            queue.Enqueue(new Person { Name = name, Turns = turns });
        }

        // Get the next person from the queue
        public void GetNextPerson()
        {
            if (queue.Count == 0)
            {
                Console.WriteLine("Error: The queue is empty.");
                return;
            }

            Person person = queue.Dequeue();
            Console.WriteLine(person.Name);

            if (person.Turns <= 0)
            {
                queue.Enqueue(person); // Infinite turns
            }
            else
            {
                person.Turns--;
                if (person.Turns > 0)
                {
                    queue.Enqueue(person);
                }
            }
        }
    }
}

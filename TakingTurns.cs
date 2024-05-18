﻿using System;

namespace prove_04
{
    public static class TakingTurns
    {
        public static void Test()
        {
            // Test Cases

            // Test 1
            // Scenario: Create a queue with the following people and turns: Bob (2), Tim (5), Sue (3) and
            //           run until the queue is empty
            // Expected Result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, Sue, Tim, Tim
            Console.WriteLine("Test 1");
            var players = new TakingTurnsQueue();
            players.AddPerson("Bob", 2);
            players.AddPerson("Tim", 5);
            players.AddPerson("Sue", 3);
            for (int i = 0; i < 10; i++)
                players.GetNextPerson();
            Console.WriteLine("---------");

            // Test 2
            // Scenario: Create a queue with the following people and turns: Bob (2), Tim (5), Sue (3)
            //           After running 5 times, add George with 3 turns.  Run until the queue is empty.
            // Expected Result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, George, Sue, Tim, George, Tim, George
            Console.WriteLine("Test 2");
            players = new TakingTurnsQueue();
            players.AddPerson("Bob", 2);
            players.AddPerson("Tim", 5);
            players.AddPerson("Sue", 3);
            for (int i = 0; i < 5; i++)
                players.GetNextPerson();
            players.AddPerson("George", 3);
            for (int i = 0; i < 8; i++)
                players.GetNextPerson();
            Console.WriteLine("---------");

            // Test 3
            // Scenario: Create a queue with the following people and turns: Bob (2), Tim (Forever), Sue (3)
            //           Run 10 times.
            // Expected Result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, Sue, Tim, Tim
            Console.WriteLine("Test 3");
            players = new TakingTurnsQueue();
            players.AddPerson("Bob", 2);
            players.AddPerson("Tim", 0);
            players.AddPerson("Sue", 3);
            for (int i = 0; i < 10; i++)
                players.GetNextPerson();
            Console.WriteLine("---------");

            // Test 4
            // Scenario: Try to get the next person from an empty queue
            // Expected Result: Error message should be displayed
            Console.WriteLine("Test 4");
            players = new TakingTurnsQueue();
            players.GetNextPerson();
            Console.WriteLine("---------");
        }
    }
}

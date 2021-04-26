using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
        public enum CardValue
        {
            two,
            three,
            four,
            five,
            six,
            seven,
            eight,
            nine,
            ten,
            jack,
            queen,
            king,
            ace
        }
        
        class Card : IComparable
        {
            public char Suit { get; set; }
            public CardValue Value { get; set; }

            public Card(string card)
            {
                Suit = card.Last();
                var value = card.Substring(0, card.Length - 1);
                switch (value)
                {
                    case "2":
                        Value = CardValue.two;
                        break;
                    case "3":
                        Value = CardValue.three;
                        break;
                    case "4":
                        Value = CardValue.four;
                        break;
                    case "5":
                        Value = CardValue.five;
                        break;
                    case "6":
                        Value = CardValue.six;
                        break;
                    case "7":
                        Value = CardValue.seven;
                        break;
                    case "8":
                        Value = CardValue.eight;
                        break;
                    case "9":
                        Value = CardValue.nine;
                        break;
                    case "10":
                        Value = CardValue.ten;
                        break;
                    case "J":
                        Value = CardValue.jack;
                        break;
                    case "Q":
                        Value = CardValue.queen;
                        break;
                    case "K":
                        Value = CardValue.king;
                        break;
                    case "A":
                        Value = CardValue.ace;
                        break;
                    default:
                        throw new ArgumentException(nameof(CardValue)+ ": " + value);
                }
            }

            public int CompareTo(object obj)
            {
                return Value.CompareTo(((Card) obj).Value);
            }
        }
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); // the number of cards for player 1
            var p1Queue = new Queue<Card>();
            for (int i = 0; i < n; i++)
            {
                string cardp1 = Console.ReadLine(); // the n cards of player 1
                p1Queue.Enqueue(new Card(cardp1));
            }
            var p2Queue = new Queue<Card>();
            int m = int.Parse(Console.ReadLine()); // the number of cards for player 2
            for (int i = 0; i < m; i++)
            {
                string cardp2 = Console.ReadLine(); // the m cards of player 2
                p2Queue.Enqueue(new Card(cardp2));
            }

            // Write an answer using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");
            int turn = 0;
            while (p1Queue.Count > 0 && p2Queue.Count > 0)
            {
                turn++;
                Fight(p1Queue, p2Queue);

            }
            if (p1Queue.Count > 0)
                Console.Write("1 ");
            else
                Console.Write("2 ");
            Console.WriteLine(turn);
        }

        static void Fight(Queue<Card> p1Queue, Queue<Card> p2Queue, Queue<Card> tmpP1Queue = null, Queue<Card> tmpP2Queue = null)
        {
            var p1Card = p1Queue.Dequeue();
            var tempP1Queue = tmpP1Queue ?? new Queue<Card>();
            tempP1Queue.Enqueue(p1Card);
            var p2Card = p2Queue.Dequeue();
            var tempP2Queue = tmpP2Queue ?? new Queue<Card>();
            tempP2Queue.Enqueue(p2Card);
            if (p1Card.CompareTo(p2Card) == 1)
            {
                foreach (var t1 in tempP1Queue)
                {
                    p1Queue.Enqueue(t1);
                }

                foreach (var t2 in tempP2Queue)
                {
                    p1Queue.Enqueue(t2);
                }
            }
            else if (p1Card.CompareTo(p2Card) == -1)
            {
                foreach (var t1 in tempP1Queue)
                {
                    p2Queue.Enqueue(t1);
                }

                foreach (var t2 in tempP2Queue)
                {
                    p2Queue.Enqueue(t2);
                }    
            }
            else
            {
                DoWar(p1Queue, p2Queue, tempP1Queue, tempP2Queue);
                Fight(p1Queue, p2Queue, tempP1Queue, tempP2Queue);
            }
        }

        static void DoWar(Queue<Card> p1Queue, Queue<Card> p2Queue, Queue<Card> p1TmpQueue, Queue<Card> p2TmpQueue)
        {
            if (p1Queue.Count < 4 || p2Queue.Count < 4)
            {
                Console.WriteLine("PAT");
                Environment.Exit(0);
            }

            for (int i = 0; i < 3; i++)
            {
                p1TmpQueue.Enqueue(p1Queue.Dequeue());
                p2TmpQueue.Enqueue(p2Queue.Dequeue());
            }
        }
    }
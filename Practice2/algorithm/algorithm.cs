using Practice2.entities;
using Practice2.extra;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2.algorithm
{
    public class Algorithm
    {
        public static void HandleLinkedListSum()
        {
            Console.WriteLine("Enter 2 number: xxx yyy");
            string line = Console.ReadLine();

            var firstNumber = line.Substring(0, 3);
            var secondNumber = line.Substring(4, 3);

            LinkedList<int> firstValue = new LinkedList<int>();
            LinkedList<int> secondValue = new LinkedList<int>();

            firstValue.AddFirst(Convert.ToInt32(char.GetNumericValue(firstNumber[0])));
            firstValue.AddFirst(Convert.ToInt32(char.GetNumericValue(firstNumber[1])));
            firstValue.AddFirst(Convert.ToInt32(char.GetNumericValue(firstNumber[2])));

            secondValue.AddFirst(Convert.ToInt32(char.GetNumericValue(secondNumber[0])));
            secondValue.AddFirst(Convert.ToInt32(char.GetNumericValue(secondNumber[1])));
            secondValue.AddFirst(Convert.ToInt32(char.GetNumericValue(secondNumber[2])));

            var result = LinkedListSum(firstValue, secondValue).Last;

            while (result != null)
            {
                Console.Write(result.Value);
                result = result.Previous;
            }
        }

        public static void HandleDialNumberWord()
        {
            Console.WriteLine("Type four digit here...");
            var digits = Console.ReadLine().ToArray().Select(c => Convert.ToInt32(Char.GetNumericValue(c))).ToArray();
            var list = DigitalWordGenerator(digits);
            Console.WriteLine("Results...");
            foreach (string word in list)
            {
                Console.WriteLine(word);
            }
        }

        public static void HandlePeople()
        {
            var ran = new Random();
            var peoples = new List<Person>();
            for (int i = 0; i < 20; i++)
            {
                var birth = ran.Next(1900, 1999);
                var death = ran.Next(birth, 2000);
                var person = new Person("Person " + (i + 1), birth, death);
                peoples.Add(person);
                Console.WriteLine(person);
            }
            Console.WriteLine("Most people alive was in = " + LivingPeople(peoples));
        }

        private static LinkedList<int> LinkedListSum(LinkedList<int> first, LinkedList<int> second)
        {
            var resultLinkedList = new LinkedList<int>();

            var firstNode = first.First;
            var secondNode = second.First;
            var carried = 0;

            while (firstNode != null || secondNode != null)
            {
                var result = firstNode.Value + secondNode.Value + carried;
                if (result > 9)
                {
                    result = result % 10;
                    carried = 1;
                }
                else
                {
                    carried = 0;
                }

                resultLinkedList.AddLast(result);

                firstNode = firstNode.Next;
                secondNode = secondNode.Next;
            }

            if (carried == 1)
            {
                resultLinkedList.AddLast(carried);
            }

            return resultLinkedList;
        }

        private static int LivingPeople(List<Person> peoples) // O(n*y)
        {
            var years = new Dictionary<int, int>();

            foreach (Person p in peoples) //O(n)
            {
                for (int year = p.BirthYear; year < p.DeathYear; year++) //O(y)
                {
                    if (years.ContainsKey(year))
                    {
                        years[year] += 1;
                    }
                    else
                    {
                        years.Add(year, 1);
                    }
                }
            }

            return years.ToList().OrderByDescending(o => o.Value).ToList().First().Key; //O(nlog n)
        }

        private static List<string> DigitalWordGenerator(int[] digits)
        {
            var file = new System.IO.StreamReader("../../resources/4letterword.txt");
            var stateMachine = new StateMachine('0');
            string word;
            while ((word = file.ReadLine()) != null)
            {
                stateMachine.AddElement(word);
            }
            file.Close();

            var digitToLetters = new Dictionary<int, char[]>()
            {
                { 2, new char[]{ 'a', 'b', 'c' } },
                { 3, new char[]{ 'd', 'e', 'f' } },
                { 4, new char[]{ 'g', 'h', 'i' } },
                { 5, new char[]{ 'j', 'k', 'l' } },
                { 6, new char[]{ 'm', 'n', 'o' } },
                { 7, new char[]{ 'p', 'q', 'r', 's' } },
                { 8, new char[]{ 't', 'u', 'v' } },
                { 9, new char[]{ 'w', 'y', 'y', 'z' } }
            };

            var letters = new char[4][];

            for (int i = 0; i < digits.Length; i++) // O(n)
            {
                if (digitToLetters.ContainsKey(digits[i]))
                {
                    letters[i] = digitToLetters[digits[i]];
                }
                else
                {
                    throw new Exception($"{digits[i]} is not a valid digit");
                }
            }

            string composeWord = "";
            var validWords = new List<string>();
            for (int i = 0; i < letters[0].Length; i++)
            {
                composeWord += letters[0][i];
                for (int j = 0; j < letters[1].Length; j++)
                {
                    composeWord += letters[1][j];
                    for (int k = 0; k < letters[2].Length; k++)
                    {
                        composeWord += letters[2][k];
                        for (int l = 0; l < letters[3].Length; l++)
                        {
                            composeWord += letters[3][l];
                            if (stateMachine.ValidWord(composeWord))
                            {
                                validWords.Add(composeWord);
                            }
                            composeWord = composeWord.Substring(0, composeWord.Length - 1);
                        }
                        composeWord = composeWord.Substring(0, composeWord.Length - 1);
                    }
                    composeWord = composeWord.Substring(0, composeWord.Length - 1);
                }
                composeWord = composeWord.Substring(0, composeWord.Length - 1);
            }

            return validWords;
        }
    }
}

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

        public static void HandleMonochromeScreen()
        {
            const int width = 64;
            const int height = 64;
            var monochromeScreen = new byte[(width / 8) * height];
            DrawLine(ref monochromeScreen, width, 10, 50, height / 2);
            Console.WriteLine("Screen");
            for (int i = 0; i < (width / 8); i++)
            {
                for (int j = 0; j < height; j++)
                {
                    var value = monochromeScreen[j + (i * height)] + "";
                    value = value.PadLeft(3);
                    Console.Write(value);
                }
                Console.WriteLine();
            }
        }

        private static int LivingPeople(List<Person> peoples)
        {
            var years = new Dictionary<int, int>();

            foreach (Person p in peoples)
            {
                for (int year = p.BirthYear; year < p.DeathYear; year++)
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

            return years.ToList().OrderByDescending(o => o.Value).ToList().First().Key;
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

            for (int i = 0; i < digits.Length; i++)
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

        private static void DrawLine(ref byte[] screen, int width, int x1, int x2, int y)
        {
            var widthBytes = width / 8;
            var height = screen.Length / widthBytes;
            var i = x1;
            int arrayIndex, byteIndex;
            while (i <= x2)
            {
                var index = i + (y * width);
                arrayIndex = index / 8;
                byteIndex = (index % 8);
                byte addedbinary = 128;
                if (byteIndex > 0)
                {
                    byte shift = (byte)(byteIndex + 1);
                    addedbinary = (byte)(screen[arrayIndex] + (128 >> (shift - 1)));
                }
                screen[arrayIndex] = addedbinary;
                i++;
            }
        }
    }
}

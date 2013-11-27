using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShortName
{
    class Program
    {
        static void Main(string[] args)
        {
            Libs lib = new Libs();
            Console.WriteLine("Enter ! to end the program \n");
            do
            {
                Console.Write("Enter your full name: ");
                string input = Console.ReadLine();
                input = input.Trim();
                if (input.Trim() == "!")
                    break;

                if (lib.checkValidName(input) != true)
                {
                    Console.WriteLine("\n\nType only first name and last name");
                    continue;
                }

                //to print length
                Console.WriteLine("\n\nNumber of Letters: " + lib.findLength(input));

                //to compare length of fname and Lname
                if (lib.compareLength(input))
                    Console.WriteLine("Good one");
                else
                    Console.WriteLine("Not bad though");


                //to print hungarian
                Console.WriteLine("\n\nName in Hungarian Notation: " + lib.printInHungarian(input));

                Console.WriteLine("\n\nNumber of Vowels in name is: " + lib.countVowels(input));

                Console.WriteLine("\n\nName without vowels:  " + lib.removeVowels(input));

            } while (1 == 1);

        }
    }
    class Libs
    {
        public string removeVowels(string name)
        {
            string vowels = "aeiou";
            string name2 = printInHungarian(name).ToLower();
            String name3 = new string(name2.Where(a => !vowels.Contains(a)).ToArray());
            return name3;
        }


        public string printInHungarian(string name)
        {
            string[] nameArray = splitName(name);
            string returnText = nameArray[0].ToLower() + nameArray[1][0].ToString().ToUpper() + nameArray[1].Substring(1).ToLower();
            return returnText;
        }


        public int countVowels(string name)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            string name2 = printInHungarian(name);
            name2 = name2.ToLower();
            int count = 0;
            for (int i = 0; i < name2.Length; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (name2[i].ToString() == vowels[j].ToString())
                    {
                        count++;
                        break;
                    }
                }
            }
            return count;
        }


        public string[] splitName(string name)
        {
            string[] nameArray = name.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            return nameArray;
        }


        public bool checkValidName(string name)
        {
            //check if name has only firstname and last name or not                            
            string[] nameArray = splitName(name);
            if (nameArray.Length == 2)
                return true;
            else
                return false;
        }


        public bool compareLength(string name)
        {
            name = name.Trim();
            string[] nameArray = splitName(name);
            if (nameArray[0].Length == nameArray[1].Length)
                return true;
            else
                return false;
        }


        public int findLength(string name)
        {
            int count = 0;
            for (int i = 0; i < name.Length; i++)
            {
                if (name[i] == ' ')
                    continue;
                count++;
            }
            return count;
        }
    }
}

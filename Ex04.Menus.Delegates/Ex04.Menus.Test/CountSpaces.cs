using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class CountSpaces : IManipulateUserChoice
    {
        public void ExecuteUserChoice()
        {
            Console.WriteLine("Please enter a sentence:");
            string inputFromUser = Console.ReadLine();
            int numberOfSpacesInSentence = countNumOfSpacesInSentence(inputFromUser);
            Console.WriteLine("there are {0} Spaces in the sentence", numberOfSpacesInSentence);
        }

        private int countNumOfSpacesInSentence(string i_SentenceFromUser)
        {
            int countNumOfSpaces = 0;

            foreach (char letter in i_SentenceFromUser.ToLower())
            {
                if (letter == ' ')
                {
                    countNumOfSpaces++;
                }
            }

            return countNumOfSpaces;
        }
    }
}

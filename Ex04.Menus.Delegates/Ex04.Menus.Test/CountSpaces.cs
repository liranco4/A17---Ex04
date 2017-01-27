using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class CountSpaces : IManipulateUserChoice
    {
        public void ExecuteUserChoice()
        {
            Console.WriteLine("Please enter a sentence:");
            string inputFromUser = Console.ReadLine();
            int numberOfSpacesInSentence = this.countNumOfSpacesInSentence(inputFromUser);
            Console.WriteLine("There are {0} Spaces in the sentence", numberOfSpacesInSentence);
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

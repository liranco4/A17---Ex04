using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class CharsCount : IManipulateUserChoice
    {
        public void ExecuteUserChoice()
        {
            Console.WriteLine("Please enter a sentence:");
            string inputFromUser = Console.ReadLine();
            int numberOfLettersInSentence = this.countNumOfLettersInSentence(inputFromUser);
            Console.WriteLine("there are {0} letters in the sentence", numberOfLettersInSentence);
        }

        private int countNumOfLettersInSentence(string i_SentenceFromUser)
        {
            int countNumOfLetters = 0;

            foreach (char letter in i_SentenceFromUser.ToLower())
            {
                if (letter >= 'a' && letter <= 'z')
                {
                    countNumOfLetters++;
                }
            }

            return countNumOfLetters;
        }
    }
}
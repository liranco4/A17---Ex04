using System;

namespace Ex04.Menus.Test
{
   public class Program
    {
        public static void Main()
        {
            RunDelegateMenu();
            RunInterfaceMenu();
        }

        private static void RunInterfaceMenu()
        {
            Interfaces.MainMenu mainMenuInterface = new Interfaces.MainMenu("Main Menu - Interface");
            Interfaces.MenuItemsList timeDateMenuItemInterface = new Interfaces.MenuItemsList("Show Date/Time");
            Interfaces.MenuItemsList versionAndActionsMenuItemInterface = new Interfaces.MenuItemsList("Version And Actions");
            Interfaces.MenuItemsList actionsMenuItemInterface = new Interfaces.MenuItemsList("Actions");
            Interfaces.ManipulateMenuItem showTimeItemInterface = new Interfaces.ManipulateMenuItem("Show Time", new ShowTime());
            Interfaces.ManipulateMenuItem showDateItemInterface = new Interfaces.ManipulateMenuItem("Show Date", new ShowDate());
            Interfaces.ManipulateMenuItem versionMenuItemInterface = new Interfaces.ManipulateMenuItem("Show Version", new ShowVersion());
            Interfaces.ManipulateMenuItem charsCounterItemInterface = new Interfaces.ManipulateMenuItem("Letters Counter", new CharsCount());
            Interfaces.ManipulateMenuItem countSpacesItemInterface = new Interfaces.ManipulateMenuItem("Count Spaces", new CountSpaces());
            timeDateMenuItemInterface.AddItemToMenuList(showTimeItemInterface);
            timeDateMenuItemInterface.AddItemToMenuList(showDateItemInterface);
            versionAndActionsMenuItemInterface.AddItemToMenuList(versionMenuItemInterface);
            actionsMenuItemInterface.AddItemToMenuList(charsCounterItemInterface);
            actionsMenuItemInterface.AddItemToMenuList(countSpacesItemInterface);
            versionAndActionsMenuItemInterface.AddItemToMenuList(actionsMenuItemInterface);
            mainMenuInterface.AddItemToMenuList(timeDateMenuItemInterface);
            mainMenuInterface.AddItemToMenuList(versionAndActionsMenuItemInterface);
            mainMenuInterface.Show();
        }

        private static void RunDelegateMenu()
        {
            Delegates.MainMenu mainMenu = new Delegates.MainMenu("Main Menu - Delegate");
            Delegates.MenuWithInnerMenusCollection dateTimeMenu = new Delegates.MenuWithInnerMenusCollection("Show Date/Time");
            Delegates.OperationMenu showDateMenu = new Delegates.OperationMenu("Show Date");
            Delegates.OperationMenu showTimeMenu = new Delegates.OperationMenu("Show Time");
            dateTimeMenu.AddToCollection(showDateMenu);
            dateTimeMenu.AddToCollection(showTimeMenu);
            showDateMenu.ExecuteMenuOperation += showDate;
            showTimeMenu.ExecuteMenuOperation += showTime;
            Delegates.MenuWithInnerMenusCollection versionAndActionsMenu = new Delegates.MenuWithInnerMenusCollection("Version And Actions");
            Delegates.OperationMenu versionMenu = new Delegates.OperationMenu("Show Version");
            Delegates.MenuWithInnerMenusCollection actionsMenu = new Delegates.MenuWithInnerMenusCollection("Actions");
            versionAndActionsMenu.AddToCollection(versionMenu);
            versionAndActionsMenu.AddToCollection(actionsMenu);
            versionMenu.ExecuteMenuOperation += showVersion;
            Delegates.OperationMenu charsCounterMenu = new Delegates.OperationMenu("Letters Counter");
            Delegates.OperationMenu countSpacesMenu = new Delegates.OperationMenu("Count Spaces");
            actionsMenu.AddToCollection(charsCounterMenu);
            actionsMenu.AddToCollection(countSpacesMenu);
            charsCounterMenu.ExecuteMenuOperation += charsCounter;
            countSpacesMenu.ExecuteMenuOperation += spacesCounter;
            mainMenu.AddToCollection(dateTimeMenu);
            mainMenu.AddToCollection(versionAndActionsMenu);
            mainMenu.Show();
        }

        private static void showDate()
        {
            Console.WriteLine(DateTime.Now.ToShortDateString());
        }

        private static void showTime()
        {
            Console.WriteLine(DateTime.Now.ToString("hh:mm:ss tt"));
        }

        private static void charsCounter()
        {
            int numberOfLettersInSentence = countNumOfLettersInSentence(userInput());
            Console.WriteLine("There are {0} letters in the sentence", numberOfLettersInSentence);
        }

        private static void spacesCounter()
        {
            int numberOfSpacesInSentence = countNumOfSpacesInSentence(userInput());
            Console.WriteLine("There are {0} Spaces in the sentence", numberOfSpacesInSentence);
        }

        private static void showVersion()
        {
            Console.WriteLine("Version: 17.1.4.0");
        }

        private static string userInput()
        {
            Console.WriteLine("Please enter a sentence:");
            return Console.ReadLine();
        }

        private static int countNumOfSpacesInSentence(string i_SentenceFromUser)
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

        private static int countNumOfLettersInSentence(string i_SentenceFromUser)
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

using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class MenuItemsList : MenuItem
    {
        private const string k_Back = "Back";
        private const int k_Zero = 0;
        private readonly List<MenuItem> r_MenuItems = new List<MenuItem>();
        protected string m_BackOrExitMsgToUser = k_Back;
     
        public MenuItemsList(string i_MenuHeaderName)
            : base(i_MenuHeaderName)
        {
        }

        /// <summary>
        /// Metho tod prints sub menu items while the user does not choose to go back (zero).
        /// </summary>
        internal override void ExecuteActionOrSubMenu()
        {
            StringBuilder menuToPrint = new StringBuilder();
            bool backOrExitFlag = false;
            int userChoice;

            if (this.r_MenuItems != null)
            {
                int lineindex = k_Zero;

                do
                {
                    lineindex = 1;
                    menuToPrint.AppendLine(string.Format("{0}{1}{2}", this.MenuName, Environment.NewLine, "====================="));

                    foreach (MenuItem item in this.r_MenuItems)
                    {
                        menuToPrint.Append(string.Format("{0}- {1}{2}", lineindex, item.MenuName, Environment.NewLine));
                        lineindex++;
                    }

                    menuToPrint.Append(string.Format("0. {0}{1}", this.m_BackOrExitMsgToUser, Environment.NewLine));
                    menuToPrint.Append(string.Format("Please enter input from menu (between 0 to {0}):", this.r_MenuItems.Count));
                    Console.Write(menuToPrint);
                    menuToPrint.Length = k_Zero;
                    menuToPrint.Capacity = k_Zero;
                    userChoice = this.checkUserInput();

                    if (userChoice == k_Zero)
                    {
                        backOrExitFlag = true;
                    }
                    else
                    {
                        Console.Clear();
                        this.r_MenuItems[userChoice - 1].ExecuteActionOrSubMenu();
                    }
                }
                while (!backOrExitFlag);

                Console.Clear();
            }
            else
            {
                Console.WriteLine("invalid operation");
            }
        }

        /// <summary>
        /// Method to check if user input is legal 
        /// </summary>
        private int checkUserInput()
        {
            bool isInputValid = true;
            bool loopFlag = true;
            int userInput = k_Zero;
            string userInputFromConsole = string.Empty;

            do
            {
                userInputFromConsole = Console.ReadLine();
                isInputValid = int.TryParse(userInputFromConsole, out userInput);

                if (!isInputValid)
                {
                    loopFlag = false;
                    Console.Write("Please enter valid input:");
                }
                else if (userInput >= k_Zero && userInput <= this.r_MenuItems.Count && userInputFromConsole.Length == 1)
                {
                    loopFlag = true;
                    break;
                }
                else
                {
                    loopFlag = false;
                    Console.Write("Please enter valid input:");
                }
            }
            while (!loopFlag);

            return userInput;
        }

        /// <summary>
        /// Method to add menu item to r_MenuItems List
        /// </summary>
        /// <param name="i_MenuItemToAdd"></param>
        public void AddItemToMenu(MenuItem i_MenuItemToAdd)
        {
            this.r_MenuItems.Add(i_MenuItemToAdd);
        }
    }
}
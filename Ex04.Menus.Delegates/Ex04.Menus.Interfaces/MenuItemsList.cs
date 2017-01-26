using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class MenuItemsList : MenuItem
    {
        private const string Back = "Back";
        private const int zero = 0;
        private readonly List<MenuItem> r_MenuItems = new List<MenuItem>();
        protected string m_backOrExitMsgToUser = Back;
     
        public MenuItemsList(string i_MenuHeaderName)
            : base(i_MenuHeaderName)
        {
        }

        /// <summary>
        /// Metho tod prints sub menu items while the user does not choose to go back (zero).
        /// </summary>
        internal override void ExecuteActionOrSubMenu()
        {
            StringBuilder MenuToPrint = new StringBuilder();
            bool backOrExitFlag = false;
            int userChoice;

            if (this.r_MenuItems != null)
            {
                int Lineindex = zero;

                do
                {
                    Lineindex = 1;
                    MenuToPrint.AppendLine(string.Format("{0}{1}{2}", this.MenuName, Environment.NewLine, "====================="));

                    foreach (MenuItem Item in this.r_MenuItems)
                    {
                        MenuToPrint.Append(string.Format("{0}- {1}{2}", Lineindex, Item.MenuName, Environment.NewLine));
                        Lineindex++;
                    }

                    MenuToPrint.Append(string.Format("0. {0}{1}", this.m_backOrExitMsgToUser, Environment.NewLine));
                    MenuToPrint.Append(string.Format("Please enter input from menu (between 0 to {0}):", this.r_MenuItems.Count));
                    Console.Write(MenuToPrint);
                    MenuToPrint.Length = zero;
                    MenuToPrint.Capacity = zero;
                    userChoice = this.CheckUserInput();

                    if (userChoice == zero)
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
        private int CheckUserInput()
        {
            bool isInputValid = true;
            bool loopFlag = true;
            int userInput = zero;
            do
            {
                isInputValid = int.TryParse(Console.ReadLine(), out userInput);

                if (!isInputValid)
                {
                    loopFlag = false;
                    Console.Write("Please enter valid input:");
                }
                else if (userInput >= zero && userInput <= this.r_MenuItems.Count)
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
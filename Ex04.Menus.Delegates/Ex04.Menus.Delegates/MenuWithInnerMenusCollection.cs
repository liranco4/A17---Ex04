using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public class MenuWithInnerMenusCollection : MenuItem
    {
        private readonly List<MenuItem> r_MenuCollection;
        private const string k_Back = "Back";
        private const int k_Zero = 0;

        public MenuWithInnerMenusCollection(string i_MenuName)
            : base(i_MenuName)
        {
            this.r_MenuCollection = new List<MenuItem>();
        }

        public void AddToCollection(MenuItem i_Menu)
        {
            this.r_MenuCollection.Add(i_Menu);
        }

        protected virtual string BackOrExitOperation
        {
            get { return k_Back; }
        }

        internal override void ExecuteOperationOrShowInnerMenu()
        {
            bool state = false;
            Console.Clear();
            if (r_MenuCollection.Count != k_Zero)
            {
                do
                {
                    int menuIndex = k_Zero;
                    StringBuilder menuBuilder = new StringBuilder();
                    menuBuilder.Append(string.Format("{0}{1}====================={1}", this.MenuName, Environment.NewLine));
                    menuBuilder.Append(string.Format("{0}. {1}{2}", menuIndex, BackOrExitOperation, Environment.NewLine));
                    foreach (MenuItem menu in r_MenuCollection)
                    {
                        menuBuilder.Append(string.Format("{0}. {1}{2}", ++menuIndex, menu.MenuName, Environment.NewLine));
                    }

                    Console.WriteLine("{0}", menuBuilder.ToString());
                    int userChoice = getAndcheckInputLegality();
                    if (userChoice != k_Zero)
                    {
                        Console.Clear();
                        r_MenuCollection[userChoice - 1].ExecuteOperationOrShowInnerMenu();
                    }
                    else
                    {
                        state = true;
                    }
                }
                while (!state);
                Console.Clear();
            }
        }

        private int getAndcheckInputLegality()
        {
            bool status = false;
            int result = -1;
            Console.WriteLine("Please input your numeric choice in the following range: {0} - {1}", k_Zero, r_MenuCollection.Count);
            string input = Console.ReadLine();
            do
            {
                if (input.Length == 1 && int.TryParse(input, out result) && result >= k_Zero && result <= r_MenuCollection.Count)
                {
                    status = true;
                }
                else
                {
                    status = false;
                    Console.WriteLine("Invalid input!!! please input in the following range: {0} - {1}", k_Zero, r_MenuCollection.Count);
                    input = Console.ReadLine();
                }
            }
            while (!status);
            return result;
        }
    }
}

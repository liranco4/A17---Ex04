using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public class MenuWithInnerMenusCollection : MenuItem
    {
        private const string k_Back = "Back";
        private const int k_Zero = 0;
        private const int k_One = 1;
        private readonly List<MenuItem> r_MenuCollection;


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
            StringBuilder menuBuilder = new StringBuilder();
            bool state = false;
            Console.Clear();
            if (this.r_MenuCollection.Count != k_Zero)
            {
                do
                {
                    int menuIndex = k_Zero;
                    menuBuilder.Append(string.Format("{0}{1}====================={1}", this.MenuName, Environment.NewLine));
                    menuBuilder.Append(string.Format("{0}. {1}{2}", menuIndex, this.BackOrExitOperation, Environment.NewLine));
                    foreach (MenuItem menu in this.r_MenuCollection)
                    {
                        menuBuilder.Append(string.Format("{0}. {1}{2}", ++menuIndex, menu.MenuName, Environment.NewLine));
                    }

                    Console.WriteLine("{0}", menuBuilder.ToString());
                    menuBuilder.Length = k_Zero;
                    menuBuilder.Capacity = k_Zero;
                    int userChoice = this.getAndcheckInputLegality();
                    if (userChoice != k_Zero)
                    {
                        Console.Clear();
                        this.r_MenuCollection[userChoice - k_One].ExecuteOperationOrShowInnerMenu();
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
            Console.WriteLine("Please input your numeric choice in the following range: {0} - {1}", k_Zero, this.r_MenuCollection.Count);
            string input = Console.ReadLine();
            do
            {
                if (input.Length == k_One && int.TryParse(input, out result) && result >= k_Zero && result <= this.r_MenuCollection.Count)
                {
                    status = true;
                }
                else
                {
                    status = false;
                    Console.WriteLine("Invalid input!!! please input in the following range: {0} - {1}", k_Zero, this.r_MenuCollection.Count);
                    input = Console.ReadLine();
                }
            }
            while (!status);
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public class MenuWithInnerMenusCollection : Menu
    {
        private readonly List<Menu> r_MenuCollection;
        MenuWithInnerMenusCollection(string i_MenuName)
            : base(i_MenuName)
        {
            r_MenuCollection = new List<Menu>();
        }

        public void AddToCollection(Menu i_Menu)
        {
            r_MenuCollection.Add(i_Menu);
        }


        internal override void ExecuteOperationOrShowInnerMenu()
        {

        }

        private int checkInputLegality(string i_Input)
        {
            bool status = true;
            int result = -1;
            do
            {
                if (int.TryParse(i_Input, out result))
                {
                    if (result < 0 && result > r_MenuCollection.Capacity)
                    {
                        status = false;
                        Console.WriteLine("Invalid input!!! please input in the following range: {0} - {1}", 0, r_MenuCollection.Capacity);
                    }
                }
            }
            while (!status);
            return result;
        }
    }
}

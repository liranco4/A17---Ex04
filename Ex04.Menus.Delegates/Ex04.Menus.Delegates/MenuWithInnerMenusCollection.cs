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
            if(r_MenuCollection.Capacity != 0)
            {
                int menuIndex = 0;
                StringBuilder menuBuilder = new StringBuilder();
                menuBuilder.Append(string.Format("{0}. Back", menuIndex));
                foreach(Menu menu in r_MenuCollection)
                {
                    menuBuilder.Append(string.Format("{0}. {1}", ++menuIndex, menu.MenuName));
                }
                
                
                
                int userChoice = getAndcheckInputLegality();

            }
        }

        private int getAndcheckInputLegality()
        {
            bool status = true;
            int result = -1;
            Console.WriteLine("Please input your numeric choice in the following range: {0} - {1}", 0, r_MenuCollection.Capacity);
            string input = Console.ReadLine();  
            do
            {
                if (int.TryParse(input, out result))
                {
                    if (result < 0 && result > r_MenuCollection.Capacity)
                    {
                        status = false;
                        Console.WriteLine("Invalid input!!! please input in the following range: {0} - {1}", 0, r_MenuCollection.Capacity);
                        input = Console.ReadLine();
                    }
                }
            }
            while (!status);
            return result;
        }
    }
}

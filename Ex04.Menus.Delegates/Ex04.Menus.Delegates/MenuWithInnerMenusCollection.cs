using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public class MenuWithInnerMenusCollection : Menu
    {
        private readonly List<Menu> r_MenuCollection;
		protected static Stack<Menu> s_MenusStack = new Stack<Menu>();
		public MenuWithInnerMenusCollection(string i_MenuName)
            : base(i_MenuName)
        {
            r_MenuCollection = new List<Menu>();
        }

        public void AddToCollection(Menu i_Menu)
        {
            r_MenuCollection.Add(i_Menu);
        }

		protected virtual string BackOrExitOperation()
		{
			return "Back";
		}

        internal override void ExecuteOperationOrShowInnerMenu()
        {
			bool state = false;
			if (r_MenuCollection.Capacity != 0)
			{
				do
				{
					Console.Clear();
					int menuIndex = 0;
					StringBuilder menuBuilder = new StringBuilder();
					menuBuilder.Append(string.Format("{0}{1}___________________________", MenuName, Environment.NewLine));
					menuBuilder.Append(string.Format("{0}. {1}", menuIndex , BackOrExitOperation()));
					foreach (Menu menu in r_MenuCollection)
					{
						menuBuilder.Append(string.Format("{0}. {1}{2}", ++menuIndex, menu.MenuName, Environment.NewLine));
					}
					Console.WriteLine("{0}", menuBuilder.ToString());

					int userChoice = getAndcheckInputLegality();
					if (userChoice != 0)
					{
						r_MenuCollection[userChoice - 1].ExecuteOperationOrShowInnerMenu();
					}
					else
					{
						state = true;
					}	
				}
					while (!state) ;
				Console.Clear();
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

using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public class MenuWithInnerMenusCollection : MenuItem
    {
        private readonly List<MenuItem> r_MenuCollection;
		protected static Stack<MenuItem> s_MenusStack = new Stack<MenuItem>();
		public MenuWithInnerMenusCollection(string i_MenuName)
            : base(i_MenuName)
        {
            r_MenuCollection = new List<MenuItem>();
        }

        public void AddToCollection(MenuItem i_Menu)
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
            Console.Clear();
			if (r_MenuCollection.Count != 0)
			{
				do
				{
					int menuIndex = 0;
					StringBuilder menuBuilder = new StringBuilder();
					menuBuilder.Append(string.Format("{0}{1}___________________________{1}", MenuName, Environment.NewLine));
					menuBuilder.Append(string.Format("{0}. {1}{2}", menuIndex , BackOrExitOperation(), Environment.NewLine));
					foreach (MenuItem menu in r_MenuCollection)
					{
						menuBuilder.Append(string.Format("{0}. {1}{2}", ++menuIndex, menu.MenuName, Environment.NewLine));
					}
					Console.WriteLine("{0}", menuBuilder.ToString());

					int userChoice = getAndcheckInputLegality();
					if (userChoice != 0)
					{
                        Console.Clear();
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
            bool status = false;
            int result = -1;
            Console.WriteLine("Please input your numeric choice in the following range: {0} - {1}", 0, r_MenuCollection.Count);
            string input = Console.ReadLine();  
            do
            {
                if (int.TryParse(input, out result) && result >= 0 && result <= r_MenuCollection.Count)
                    {
                        status = true;
                    }
                    else
                    {
                        status = false;
                        Console.WriteLine("Invalid input!!! please input in the following range: {0} - {1}", 0, r_MenuCollection.Count);
                        input = Console.ReadLine();
                    }
            }
            while (!status);
            return result;
        }
    }
}

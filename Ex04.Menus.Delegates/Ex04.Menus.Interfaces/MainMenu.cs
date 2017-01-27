
namespace Ex04.Menus.Interfaces
{
    public class MainMenu : MenuItemsList
    {
        private const string k_Exit = "Exit";

        public MainMenu(string i_MenuName)
           : base(i_MenuName)
        {
        }

        protected override string BackOrExitMsgToUser
        {
            get
            {
                return k_Exit;
            }
        }

        public void Show()
        {
            this.ExecuteActionOrShowSubMenu();
        }
    }
}

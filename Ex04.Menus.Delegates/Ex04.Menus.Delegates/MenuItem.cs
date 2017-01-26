namespace Ex04.Menus.Delegates
{
    public abstract class MenuItem
    {
        private string r_MenuName;

        protected MenuItem(string i_MenuName)
        {
            this.r_MenuName = i_MenuName;
        }

        public string MenuName
        {
            get
            {
                return this.r_MenuName;
            }
        }

        internal abstract void OnExecuteOperationOrShowInnerMenu();
    }
}

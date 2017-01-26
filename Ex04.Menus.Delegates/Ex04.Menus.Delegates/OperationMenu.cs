namespace Ex04.Menus.Delegates
{
    public delegate void Executer();

    public class OperationMenu : MenuItem
    {
        public OperationMenu(string i_MenuName)
            : base(i_MenuName)
        {
        }

        public event Executer ExecuteMenuOperation;

        internal override void OnExecuteOperationOrShowInnerMenu()
        {
            if (this.ExecuteMenuOperation != null)
            {
                this.ExecuteMenuOperation.Invoke();
            }
        }
    }
}

namespace Ex04.Menus.Interfaces
{
    public class ManipulateMenuItem : MenuItem
    {
        private IManipulateUserChoice m_UserChoice;

        public ManipulateMenuItem(string i_ItemName, IManipulateUserChoice i_UserChoiceMethod)
            : base(i_ItemName)
        {
            this.m_UserChoice = i_UserChoiceMethod;
        }

        internal override void ExecuteActionOrShowSubMenu()
        {
            this.m_UserChoice.ExecuteUserChoice();
        }
    }
}
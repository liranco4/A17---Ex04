using System;
using System.Collections.Generic;
using System.Text;

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

        internal override void ExecuteActionOrSubMenu()
        {
            this.m_UserChoice.ExecuteUserChoice();
        }
    }
}
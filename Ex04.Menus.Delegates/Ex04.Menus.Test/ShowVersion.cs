using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
   public class ShowVersion : IManipulateUserChoice
    {
        public void ExecuteUserChoice()
        {
            Console.WriteLine("Version: 17.1.4.0");
        }
    }
}

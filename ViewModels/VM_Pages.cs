using Films_kazumov.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Films_kazumov.ViewModels
{
    public class VM_Pages : Notification
    {
        public VM_Films vm_films = new VM_Films();
        public VM_Pages()
        {
            MainWindow.init.frame.Navigate(new View.Main(vm_films));
        }
        public RealyCommand OnClose
        {
            get
            {
                return new RealyCommand(obj =>
                {
                    MainWindow.init.Close();
                });
            }
        }
    }
}

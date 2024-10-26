﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Films_kazumov.Classes
{
    public class RealyCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;
        public RealyCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }
        public void Execute(object parameter) =>
            this.execute(parameter);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StopWatch.ViweModels.Commands
{
    public class ReloadCommand : ICommand
    {
        private VMstopwatch ViweModel { set; get; }
        public ReloadCommand(VMstopwatch viweModel)
        {
            this.ViweModel = viweModel;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (parameter != null)
                return !(bool)parameter;
            return false;
        }

        public void Execute(object parameter)
        {
            this.ViweModel.Restart();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Pocket_Trainer.Services
{
    public class ViewChangeMessage
    {
        public object ViewModel { get; private set; }

        public ViewChangeMessage(object viewModel)
        {
            ViewModel = viewModel;
        }
    }
  
}

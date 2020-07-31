using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfArduinoApp.ViewModels;

namespace WpfArduinoApp
{
    class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            // base.OnStartup(sender, e);
            DisplayRootViewFor<ShellViewModel>();
        }
    }
}

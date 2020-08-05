using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmChartApp.ViewModels
{
    public class MainViewModel :Conductor<object>
    {
        public void LoadLineChart()
        {
            ActivateItem(new LineChartViewModel());
        }

        public void LoadGaugeChart()
        {
            ActivateItem(new GaugeChartViewModel());
        }

        public void ExitProgram()
        {
            Environment.Exit(0);
        }
    }
}

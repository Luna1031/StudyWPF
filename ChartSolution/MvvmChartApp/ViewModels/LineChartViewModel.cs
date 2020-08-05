using Caliburn.Micro;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MvvmChartApp.ViewModels
{
    public class LineChartViewModel : Conductor<object>
    {
        public ChartValues<double> LineValues { get; set; }

        public LineChartViewModel()
        {
            InitializeChartData();
        }

        private void InitializeChartData()
        {
            LineValues = new ChartValues<double> { 3, 5, 6.7, 12.4, 0, 8, 9, 2.5 };
        }
    }
}

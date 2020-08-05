using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfArduinoApp.Models
{
    public class SensorData // : INotifyPropertyChanged
    {
        public DateTime Date { get; set; }
        public double Value { get; set; }

        public SensorData(DateTime date, double value)
        {
            Date = date;
            Value = value;
        }

        //public event PropertyChangedEventHandler PropertyChanged;
    }
}

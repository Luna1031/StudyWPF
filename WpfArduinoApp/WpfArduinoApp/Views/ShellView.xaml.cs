using Caliburn.Micro;
using LiveCharts;
using LiveCharts.Wpf;
using MahApps.Metro.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.IO.Ports;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using WpfArduinoApp.Models;

namespace WpfArduinoApp.Views
{
    /// <summary>
    /// ShellView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ShellView : MetroWindow, INotifyPropertyChanged
    {
        SerialPort serial;
        private short xCount = 200;
        private short maxPhotoVal = 1023;
        List<SensorData> photoDatas = new List<SensorData>();

        string strConnString = "Server=localhost;Port=3306;" +
            "Database=iot_sensordata;Uid=root;Pwd=mysql_p@ssw0rd";

        public bool IsSimulation { get; set; }

        SeriesCollection lineValues;
        public SeriesCollection LineValues {
            get => lineValues;
            set
            {
                lineValues = value;
                OnPropertyChanged("LineValues");
            }
        }

        Timer timer = new Timer();
        Random rand = new Random();
        CartesianChart ChtSensorValues = new CartesianChart();

        public ShellView()
        {
            InitializeComponent();
            InitControl();
            LineValues = new SeriesCollection();
            //this.DataContext = new SensorData();
            this.DataContext = this;
        }

        private void InitControl()
        {
            foreach (var item in SerialPort.GetPortNames())
            {
                CboSerialPort.Items.Add(item);
            }
            CboSerialPort.Text = "Select Port";

            PgbPhotoRegistor.Minimum = 0;
            PgbPhotoRegistor.Maximum = maxPhotoVal;

            BtnConnect.IsEnabled = BtnDisconnect.IsEnabled = false;
        }

        private void CboSerialPort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var portName = CboSerialPort.SelectedItem.ToString();
            serial = new SerialPort(portName);
            serial.DataReceived += Serial_DataReceived;

            BtnConnect.IsEnabled = true;
        }

        private void DisplayValue(string sVal)
        {
            try
            {
                double v = double.Parse(sVal);
                if (v < 0 || v > maxPhotoVal)
                    return;

                SensorData data = new SensorData(DateTime.Now, v);
                photoDatas.Add(data);
                InsertDataToDB(data);

                TxtSensorCount.Text = photoDatas.Count.ToString();
                PgbPhotoRegistor.Value = v;
                TxbPhotoRegistor.Text = v.ToString();

                LineValues.Add(new LineSeries
                {
                    Title = "Series1",
                    Values = new ChartValues<double> { v }
                });

                string item = $"{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}\t{v}";

                RtbLog.AppendText($"{item}\n");

                if (IsSimulation == false)
                    BtnPortValue.Content = $"{serial.PortName}\n{sVal}";
                else
                    BtnPortValue.Content = $"{sVal}";
            }
            catch (Exception ex)
            {
                RtbLog.AppendText($"Error : {ex.Message}\n");
            }
        }

        private void InsertDataToDB(SensorData data)
        {
            string strQuery = "INSERT INTO sensordatatbl " +
                " (Date, Value) " +
                " VALUES " +
                " (@Date, @Value) ";

            using (MySqlConnection conn = new MySqlConnection(strConnString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(strQuery, conn);
                MySqlParameter paramDate = new MySqlParameter("@Date", MySqlDbType.DateTime)
                {
                    Value = data.Date
                };
                cmd.Parameters.Add(paramDate);
                MySqlParameter paramValue = new MySqlParameter("@Value", MySqlDbType.Int32)
                {
                    Value = data.Value
                };
                cmd.Parameters.Add(paramValue);
                cmd.ExecuteNonQuery();
            }
        }

        private void Serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string sVal = serial.ReadLine();
            this.BeginInvoke(new System.Action(delegate { DisplayValue(sVal); }));
        }

        private void BtnConnect_Click(object sender, RoutedEventArgs e)
        {
            if (IsSimulation == true)
            {
                serial.Open();
            }
   
            LblConnectionTime.Content = $"연결시간 : {DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}";
            BtnConnect.IsEnabled = false;
            BtnDisconnect.IsEnabled = true;
        }

        private void BtnDisconnect_Click(object sender, RoutedEventArgs e)
        {
            if (IsSimulation == false) 
            {
                serial.Close();
            }

            LineValues.Clear();
            BtnConnect.IsEnabled = true;
            BtnDisconnect.IsEnabled = false;
        }

        private void MenuSubItemExit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void MenuSubItemStart_Click(object sender, RoutedEventArgs e)
        {
            IsSimulation = true;
            timer.Interval = 5000;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

            // serial통신 끊기
            BtnDisconnect_Click(sender, e);
        }

        private void Timer_Elapsed(object sender, EventArgs e)
        {
            ushort value = (ushort)rand.Next(1, 1024);
            
            this.Dispatcher.BeginInvoke(DispatcherPriority.Background, new System.Action(() =>
            {
                // To Do;
                DisplayValue(value.ToString());
            }));
        }

        private void MenuSubItemStop_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            IsSimulation = false;

            // serial 통신 재시작
            BtnConnect_Click(sender, e);
        }

        IWindowManager manager = new WindowManager();
        HelpView helpView = new HelpView();
        private void MenuSubItemInfo_Click(object sender, RoutedEventArgs e)
        {
            helpView.Show();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

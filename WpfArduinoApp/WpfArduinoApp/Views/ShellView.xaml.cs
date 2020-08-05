using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Wpf;
using System.IO.Ports;
using WpfArduinoApp.Models;
using System.Timers;
using LiveCharts.Defaults;
using Caliburn.Micro;
using System.Dynamic;
using System.Windows.Threading;
using System.ComponentModel;
using System.Windows.Shapes;

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
                // InsertDataToDB(data);

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

                // ChtPhoto.Update();
                // DataContext = this;
            }
            catch (Exception ex)
            {
                RtbLog.AppendText($"Error : {ex.Message}\n");
            }
        }

        private void Serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

        }

        private void BtnConnect_Click(object sender, RoutedEventArgs e)
        {
            serial.Open();
            LblConnectionTime.Content = $"연결시간 : {DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}";
            BtnConnect.IsEnabled = false;
            BtnDisconnect.IsEnabled = true;
        }

        private void BtnDisconnect_Click(object sender, RoutedEventArgs e)
        {
            serial.Close();
            LineValues.Clear();
            BtnConnect.IsEnabled = true;
            BtnDisconnect.IsEnabled = false;
        }

        private void BtnViewAll_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnZoom_Click(object sender, RoutedEventArgs e)
        {
        
        }
        private void MenuSubItemExit_Click(object sender, RoutedEventArgs e)
        {
            // Application.Exit();
            Environment.Exit(0);
        }

        private void MenuSubItemStart_Click(object sender, RoutedEventArgs e)
        {
            IsSimulation = true;
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
            // serial통신 끊기
            // DISCONNECT_Click(sender, e);
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

        private void MenuSubItemInfo_Click(object sender, RoutedEventArgs e)
        {
            dynamic settings = new ExpandoObject();
            //새창 크기조절
            settings.Height = 300;
            settings.Width = 580;
            settings.SizeToContent = SizeToContent.Manual;

            manager.ShowWindow(new HelpView(), null, settings);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

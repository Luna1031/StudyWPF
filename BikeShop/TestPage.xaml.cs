using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Animation;
using BusinessLogic;

namespace BikeShop
{
    /// <summary>
    /// TestPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TestPage : Page
    {
        public TestPage()
        {
            InitializeComponent();
            InitListBox();
        }
        private void InitListBox()
        {
            Random rand =new Random();

            List<Car> lists = new List<Car>();
            for (int i = 0; i < 10; i++)
            {
                byte red = (byte)(i % 3 == 0 ? 255 : (i * 50) % 255);
                byte green = 0;
                byte blue = (byte)(i % 3 == 0 ? (i * 50) % 255 : 255);

                lists.Add(new Car()
                {
                    Speed = i * 30,
                    Color = Color.FromRgb(red, green, blue),
                }) ;
            }
            // LstCar.DataContext = lists; //연동할 데이터
        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Car car = new Car();
            car.Speed = 100;
            car.Color = Colors.Blue;
            car.Driver = new Human { Name = "Ted", HasDrivingLicense = true };

            this.DataContext = car;
            //car1.Color = Colors.AliceBlue;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello World");
        }
    }
}

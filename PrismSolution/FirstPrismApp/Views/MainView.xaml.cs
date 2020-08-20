using Prism.Ioc;
using Prism.Regions;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FirstPrismApp.Views
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainView : Window
    {
        IContainerExtension _container;
        IRegionManager _regionManager;

        public MainView(IContainerExtension container, IRegionManager regionManager)
        {
            InitializeComponent();

            // regionManager.RegisterViewWithRegion("ContentRegion", typeof(SubView));
            _container = container;
            _regionManager = regionManager;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var view = _container.Resolve<SubView>();
            var region = _regionManager.Regions["ContentRegion"];
            region.Add(view);
        }
    }
}

using MetroMobiliteUI.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace MetroMobiliteUI.Views
{
    /// <summary>
    /// Logique d'interaction pour UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl, INotifyPropertyChanged, IUserControl1
    {
        private string _dist;
        private string _lon;
        private string _lat;

        public string Dist
        {
            get { return _dist; }
            set {
                _dist = value;
                RaisePropertyChanged("Dist");
            }
        }
        public string Lon
        {
            get { return _lon; }
            set
            {
                _lon = value;
                RaisePropertyChanged("Lon");
            }
        }
        public string Lat
        {
            get { return _lat; }
            set
            {
                _lat = value;
                RaisePropertyChanged("Lat");
            }
        }
        public UserControl1()
        {
            Dist = "700";
            Lat = "5.7253605";
            Lon = "45.1910605";
            DataContext = this;
            InitializeComponent();
        }

        public void DisplayData(object sender, RoutedEventArgs e)
        {
            Dist = dist.Text;
            Lat = lat.Text;
            Lon = lon.Text;
            StopViewModel StopViewModelObject = new StopViewModel();
            StopViewModelObject.LoadStops(Convert.ToString(Lon), Convert.ToString(Lat), Convert.ToInt32(Dist));
            this.DataContext = StopViewModelObject;
            Title.Visibility = Visibility.Visible;

            Dist = dist.Text = Dist;
            lat.Text = Lat;
            lon.Text = Lon;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}

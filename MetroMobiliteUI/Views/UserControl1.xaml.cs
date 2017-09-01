using MetroMobiliteUI.Command;
using MetroMobiliteUI.Model;
using MetroMobiliteUI.ViewModel;
using Microsoft.Maps.MapControl.WPF;
using Microsoft.Maps.MapControl.WPF.Design;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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
    public partial class UserControl1 : UserControl
    {
        Pushpin pin = new Pushpin();

        private Location _coord; 

        public Location Coord
        {
            get
            {
                return _coord;
            }

            set
            {
                if (_coord != value)
                {
                    _coord = value;
                    RaisePropertyChanged("Coord");
                }
            }
        }

        public UserControl1()
        {
            InitializeComponent();
            myMap.Focus();
            pin.Location = new Location(45.1910605,5.7253605);
            myMap.Children.Add(pin);

        }

        private void MapWithPushpins_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            Point mousePosition = e.GetPosition(myMap);
            Location pinLocation = myMap.ViewportPointToLocation(mousePosition);
            pin.Location = pinLocation;
                        lon.Text = pin.Location.Latitude.ToString(CultureInfo.InvariantCulture);
            lat.Text = pin.Location.Longitude.ToString(CultureInfo.InvariantCulture);
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

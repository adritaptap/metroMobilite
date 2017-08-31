using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroMobiliteUI.Model
{
    public class CoordinateModel : INotifyPropertyChanged
    {
        private string _dist;
        private string _lon;
        private string _lat;

        public string Dist
        {
            get { return _dist; }
            set
            {
                if (_dist != value && System.Text.RegularExpressions.Regex.IsMatch(value, "^[0-9]"))
                {
                    _dist = value;
                    RaisePropertyChanged("Dist");
                }
            }
        }

        public string Lon
        {
            get { return _lon; }
            set
            {
                if (_lon != value && System.Text.RegularExpressions.Regex.IsMatch(value, "^[0-9]"))
                {
                    _lon = value;
                    RaisePropertyChanged("Lon");
                }
            }
        }

        public string Lat
        {
            get { return _lat; }
            set
            {
                if (_lat != value && System.Text.RegularExpressions.Regex.IsMatch(value, "^[0-9]"))
                {
                    _lat = value;
                    RaisePropertyChanged("Lat");
                }
            }
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroMobiliteUI.Model
{

    public class StopModel : INotifyPropertyChanged
    {
        private string _name;
        private double _lon;
        private double _lat;
        private List<LineModel> _lines;

        public StopModel(string name, string lat, string lon)
        {
            this.Name = name;
            this.Lat = Convert.ToDouble(lat);
            this.Lon = Convert.ToDouble(lon);
            this.Lines = new List<LineModel>();

        }

        public string Name {
            get
            {
                return _name;
            }

            set
            {
                if (_name != value)
                {
                    _name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }

        public double Lat
        {
            get
            {
                return _lat;
            }

            set
            {
                if (_lat != value)
                {
                    _lat = value;
                    RaisePropertyChanged("Lat");
                    RaisePropertyChanged("Loc");
                }
            }
        }

        public double Lon
        {
            get
            {
                return _lon;
            }

            set
            {
                if (_lon != value)
                {
                    _lon = value;
                    RaisePropertyChanged("Lon");
                    RaisePropertyChanged("Loc");
                }
            }
        }

        public List<LineModel> Lines
        {
            get
            {
                return _lines;
            }

            set
            {
                if (_lines != value)
                {
                    _lines = value;
                    RaisePropertyChanged("Lines");
                }
            }
        }

        public string Loc
        {
            get
            {
                return _lat.ToString(CultureInfo.InvariantCulture) + "," + _lon.ToString(CultureInfo.InvariantCulture); ;
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

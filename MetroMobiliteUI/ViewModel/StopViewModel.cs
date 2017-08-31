using MetroMobiliteUI.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroMobiliteLibrary;
using System.Windows;
using System.ComponentModel;
using System.Windows.Input;
using MetroMobiliteUI.Command;

namespace MetroMobiliteUI.ViewModel
{
    public class StopViewModel : INotifyPropertyChanged
    {
        private string _dist;
        private string _lon;
        private string _lat;
        private string _lastPosition;
        private ObservableCollection<StopModel> _stops;

        public ObservableCollection<StopModel> Stops
        {
            get
            {
                return _stops;
            }

            set
            {
                if (_stops != value)
                {
                    _stops = value;
                    RaisePropertyChanged("Stops");
                }
            }
        }

        public ICommand DisplayCommand { get; private set; }

        public string LastPosition
        {
            get
            {
                return _lastPosition;
            }
            set
            {
                if (_lastPosition != value)
                {
                    _lastPosition = value;
                    RaisePropertyChanged("LastPosition");
                }
            }
        }

        public string Dist
        {
            get { return _dist; }
            set
            {
                if (_dist != value)
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
                if (_lon != value )
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
                if (_lat != value )
                {
                    _lat = value;
                    RaisePropertyChanged("Lat");
                }
            }
        }

        public StopViewModel()
        {
            DisplayCommand = new MyCommand(LoadStopsChanged);
        }

        private void LoadStopsChanged()
        {
            try
            {
                ObservableCollection<StopModel> stops = new ObservableCollection<StopModel>();
                MetroMobiliteService metroMobiliteService = new MetroMobiliteService();

                Dictionary<string, Stop> dico = metroMobiliteService.GetStops(Lon, Lat, Int32.Parse(Dist));

                foreach (var item in dico.Values)
                {
                    StopModel model = new StopModel(item.name, item.lat.ToString(), item.lon.ToString());
                    List<Line> lineDetails = metroMobiliteService.GetLines(item.lines);
                    foreach (var line in lineDetails)
                    {
                        model.Lines.Add(new LineModel { ShortName = line.shortName, LongName = line.longName, Color = line.color, TextColor = line.textColor, Mode = line.mode, Type = line.type });
                    }
                    stops.Add(model);
                }
                Stops = stops;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }

        public void LoadStops()
        {
            Dist = "500";
            Lat = "5.7253605";
            Lon = "45.1910605";

            ObservableCollection<StopModel> stops = new ObservableCollection<StopModel>();
            MetroMobiliteService metroMobiliteService = new MetroMobiliteService();
            Dictionary<string, Stop> dico = metroMobiliteService.GetStops(Lon, Lat, Int32.Parse(Dist));
            foreach (var item in dico.Values)
            {
                StopModel model = new StopModel(item.name, item.lat.ToString(), item.lon.ToString());
                List<Line> lineDetails = metroMobiliteService.GetLines(item.lines);

                foreach (var line in lineDetails)
                {
                    model.Lines.Add(new LineModel { ShortName = line.shortName, LongName = line.longName, Color = line.color, TextColor = line.textColor, Mode = line.mode, Type = line.type });
                }
                stops.Add(model);
            }
            Stops = stops;
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

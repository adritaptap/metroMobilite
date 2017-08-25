using MetroMobiliteUI.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroMobiliteLibrary;
using System.Windows;

namespace MetroMobiliteUI.ViewModel
{
    public class StopViewModel
    {
        public ObservableCollection<StopModel> Stops { get; set; }

        public void LoadStops(string lon, string lat, int dist )
        {
            ObservableCollection<StopModel> stops = new ObservableCollection<StopModel>();
          
            MetroMobiliteService metroMobiliteService = new MetroMobiliteService();

            Dictionary<string, Stop> dico = metroMobiliteService.GetStops(lon, lat, dist);

            foreach (var item in dico.Values)
            {
                StopModel model = new StopModel(item.name);
                List<Line> lineDetails = metroMobiliteService.GetLines(item.lines);

                foreach (var line in lineDetails)
                {
                    model.Lines.Add(new LineModel { ShortName = line.shortName, LongName = line.longName, Color = line.color, TextColor = line.textColor, Mode = line.mode, Type = line.type });
                }

                stops.Add(model);
            }
           
            Stops = stops;
        }
    }
}

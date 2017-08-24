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
    class StopViewModel
    {
        public ObservableCollection<StopModel> Stops { get; set; }

        public void LoadStops()
        {
            ObservableCollection<StopModel> stops = new ObservableCollection<StopModel>();
          
            MetroMobiliteService metroMobiliteService = new MetroMobiliteService();

            Dictionary<string, MetroMobiliteLibrary.Stop> dico = metroMobiliteService.GetStops(45.1857086, 5.7248162, 700);

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

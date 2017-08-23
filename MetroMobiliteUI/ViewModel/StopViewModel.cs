using MetroMobiliteUI.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroMobiliteLibrary;

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
            System.Diagnostics.Debug.WriteLine("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",dico);
            foreach (var item in dico.Values)
            {
                stops.Add(new StopModel { Name = item.name, Lines = item.lines });

            }

            Stops = stops;
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MetroMobilite
{
    class Program
    {
        static void Main(string[] args)
        {
            

            MetroMobiliteLibrary.MetroMobiliteService metroMobiliteService = new MetroMobiliteLibrary.MetroMobiliteService();
            

            Dictionary<string, MetroMobiliteLibrary.Stop> stops = metroMobiliteService.GetStops(45.1857086, 5.7248162, 700);
           
            foreach (var stop in stops.Values)
            {
                Console.WriteLine("////////////////////////////////////");
                Console.WriteLine("");
                Console.WriteLine(stop.id);
                Console.WriteLine(stop.name);
                Console.WriteLine(stop.lat);
                Console.WriteLine(stop.lon);
                Console.WriteLine("lines :");

                List<MetroMobiliteLibrary.Line> lineDetails = metroMobiliteService.GetLines(stop.lines);

                foreach (var line in lineDetails)
                {
                    Console.WriteLine("+" + line.id);
                    Console.WriteLine("+++" + line.shortName);
                    Console.WriteLine("+++" + line.longName);
                    Console.WriteLine("+++" + line.mode);
                    Console.WriteLine("+++" + line.type);
                    Console.WriteLine("");
                }         
            }

            Console.ReadLine();
        }
    }
}

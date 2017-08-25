using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MetroMobiliteLibrary
{
    public class MetroMobiliteService
    {
        public MetroMobiliteService()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
        }

        public Dictionary<string, Stop> GetStops(string lat, string lon, int dist)
        {
            string url = "https://data.metromobilite.fr/api/linesNear/json?x=" + lon.ToString() + "&y=" + lat.ToString() + "&dist=" + dist + "&details=true";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream receiveStream = response.GetResponseStream();
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
            string data = readStream.ReadToEnd();

            List<Stop> stops = JsonConvert.DeserializeObject<List<Stop>>(data);

            response.Close();

            readStream.Close();

            Dictionary<string, Stop> dico = new Dictionary<string, Stop>();

            foreach (var stop in stops)
            {
                if (!dico.ContainsKey(stop.name))
                {
                    dico.Add(stop.name, stop);
                }
                else
                {
                    Stop stopDico = dico.Values.Single(toto => toto.name == stop.name);
                    stopDico.lines = new List<string>(stopDico.lines.Union(stop.lines));

                }
            }
            return dico;
        }

        public List<Line> GetLines(List<string> names)
        {
            string url = "https://data.metromobilite.fr/api/routers/default/index/routes?codes=";

            foreach (var name in names)
            {
                url = url + "," + name;
            }
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream receiveStream = response.GetResponseStream();
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
            string data = readStream.ReadToEnd();

            List<Line> lineDetails = JsonConvert.DeserializeObject<List<Line>>(data);

            response.Close();
            readStream.Close();

            return lineDetails;
        }
    }
}

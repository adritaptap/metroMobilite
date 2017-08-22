using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MetroMobiliteLibrary
{
    public class MetroMobiliteService
    {

        public Dictionary<string, Stop> GetStops()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://data.metromobilite.fr/api/linesNear/json?x=5.7248162&y=45.1857086&dist=700&details=true");
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

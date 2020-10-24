using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml.Serialization;

namespace Covid19
{
    public class Importer
    {
        public List<Mortality> getMortality()
        {
            List<Mortality> jsonList;
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString("https://epistat.sciensano.be/data/COVID19BE_MORT.json");
                jsonList = JsonConvert.DeserializeObject<List<Mortality>>(json);
            }
            return jsonList;
        }

        public List<Mortality> ReadMortalityFromXmlFile(string fileName)
        {
            List<Mortality> mortalityList = null;
            XmlSerializer serializer = new XmlSerializer(typeof(List<Mortality>));
            using (StreamReader reader = new StreamReader(fileName))
            { 
                mortalityList = (List<Mortality>)serializer.Deserialize(reader);
            }
            return mortalityList;
        }

        public List<Mortality> ReadMortalityFromJsonFile(string fileName)
        {
            List<Mortality> mortalityList;
            using (StreamReader file = File.OpenText(fileName))
            {
                JsonSerializer serializer = new JsonSerializer();
                mortalityList = (List<Mortality>)serializer.Deserialize(file, typeof(List<Mortality>));
            }
            return mortalityList;
        }

        public List<Case> GetCases()
        {
                List<Case> jsonList;
                using (WebClient wc = new WebClient())
                {
                    var json = wc.DownloadString("https://epistat.sciensano.be/Data/COVID19BE_CASES_MUNI.json");
                    jsonList = JsonConvert.DeserializeObject<List<Case>>(json);
                }
                return jsonList;   
        }

        public List<Case> ReadCasesFromXmlFile(string fileName)
        {
            List<Case> casesList = null;
            XmlSerializer serializer = new XmlSerializer(typeof(List<Case>));
            using (StreamReader reader = new StreamReader(fileName))
            {
                casesList = (List<Case>)serializer.Deserialize(reader);
            }
            return casesList;
        }

        public List<Case> ReadCasesFromJsonFile(string fileName)
        {
            List<Case> casesList;
            using (StreamReader file = File.OpenText(fileName))
            {
                JsonSerializer serializer = new JsonSerializer();
                casesList = (List<Case>)serializer.Deserialize(file, typeof(List<Case>));
            }
            return casesList;
        }
    }
}

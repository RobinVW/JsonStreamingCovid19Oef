using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace Covid19
{
    public class Case
    {
        [JsonProperty("NIS5")]
        public int Nis5 { get; set; }
        [JsonProperty("DATE")]
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime Date { get; set; }
        [JsonProperty("TX_DESCR_NL")]
        public string City_NL { get; set; }
        [JsonProperty("TX_DESCR_FR")]
        public string City_FR { get; set; }
        [JsonProperty("TX_ADM_DSTR_DESCR_NL")]
        public string AdminDistric_NL { get; set; }
        [JsonProperty("TX_ADM_DSTR_DESCR_FR")]
        public string AdminDistric_FR { get; set; }
        [JsonProperty("PROVINCE")]
        public string Province { get; set; }
        [JsonProperty("REGION")]
        public string Region { get; set; }
        [JsonProperty("CASES")]
        public string CaseCount { get; set; }
    }
}
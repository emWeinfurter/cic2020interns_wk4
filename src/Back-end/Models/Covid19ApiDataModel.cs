using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ibm.Br.Cic.Internship.Covid.Be.Models
{
    public class Covid19ApiDataModel
    {
        public Global Global { get; set; }
        public List<Country> Countries { get; set; }
    }

    public class Global
    {
        [JsonProperty(PropertyName = "newConfirmed")]
        public int NewConfirmed { get; set; }

        [JsonProperty(PropertyName = "totalConfirmed")]
        public int TotalConfirmed { get; set; }

        [JsonProperty(PropertyName = "newDeaths")]
        public int NewDeaths { get; set; }

        [JsonProperty(PropertyName = "totalDeaths")]
        public int TotalDeaths { get; set; }

        [JsonProperty(PropertyName = "newRecovered")]
        public int NewRecovered { get; set; }

        [JsonProperty(PropertyName = "totalRecovered")]
        public int TotalRecovered { get; set; }
    }

    public class Country
    {
        [JsonProperty(PropertyName = "country")]
        public string CountryName { get; set; }

        [JsonProperty(PropertyName = "countryCode")]
        public string CountryCode { get; set; }

        [JsonProperty(PropertyName = "slug")]
        public string Slug { get; set; }

        [JsonProperty(PropertyName = "newConfirmed")]
        public int NewConfirmed { get; set; }

        [JsonProperty(PropertyName = "totalConfirmed")]
        public int TotalConfirmed { get; set; }

        [JsonProperty(PropertyName = "newDeaths")]
        public int NewDeaths { get; set; }

        [JsonProperty(PropertyName = "totalDeaths")]
        public int TotalDeaths { get; set; }

        [JsonProperty(PropertyName = "newRecovered")]
        public int NewRecovered { get; set; }

        [JsonProperty(PropertyName = "totalRecovered")]
        public int TotalRecovered { get; set; }

        [JsonProperty(PropertyName = "date")]
        public string Date { get; set; }

        [JsonProperty(PropertyName = "location")]
        public LocationDataModel? Location { get; set; }
    }
}

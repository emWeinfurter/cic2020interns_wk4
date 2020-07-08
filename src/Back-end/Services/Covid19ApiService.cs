using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Ibm.Br.Cic.Internship.Covid.Be.Models;
using Microsoft.Extensions.Configuration;
using Ibm.Br.Cic.Internship.Covid.Be.Configuration;
using Newtonsoft.Json;


namespace Ibm.Br.Cic.Internship.Covid.Be.Services
{
    public class Covid19ApiService : ICovid19Api
    {
        //Task: Implement Service
        //Add method (Task<IEnumerable<Covid19ApiDataModel>> GetData()) to ICovid19ApiService
        private readonly IConfiguration _configuration;
        private readonly ILocator _locator;
        public Covid19ApiService(IConfiguration configuration, ILocator locator)
        {
            _configuration = configuration;
            _locator = locator;
        }

        public async Task<IEnumerable<Country>> GetData()
        {
            var covid19Config = new Covid19ApiConfig();
            _configuration.GetSection("Covid19ApiConfig").Bind(covid19Config);
            // Use list of "countries" because DataModel contains a list of countries
            List<Country> countries = new List<Country>();
            using (HttpClient httpClient = new HttpClient())
            {
                var responseString = await httpClient.GetStringAsync($"{covid19Config.BaseUrl}{covid19Config.RequestUrl}");
                // Deserialize the Data Model
                countries = JsonConvert.DeserializeObject<Covid19ApiDataModel>(responseString).Countries;
            }

            countries.ForEach(async (country) =>
            {
                var location = _locator.GetLocation(country.CountryName);
                country.Location = location == null ? new LocationDataModel() { Latitude = 0, Longitude = 0 } : location;
            });

            return countries;
        }
    }
}

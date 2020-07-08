using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Ibm.Br.Cic.Internship.Covid.Be.Configuration;
using Ibm.Br.Cic.Internship.Covid.Be.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Ibm.Br.Cic.Internship.Covid.Be.Services
{
    public class ApifyService : IApify
    {
        private readonly IConfiguration _configuration;
        private readonly ILocator _locator;
        public ApifyService(IConfiguration configuration, ILocator locator)
        {
            _configuration = configuration;
            _locator = locator;
        }

        public async Task<IEnumerable<ApifyDataModel>> GetDataAsync()
        {
            var apifyConfig = new ApifyConfig();
            _configuration.GetSection("ApifyConfig").Bind(apifyConfig);

            List<ApifyDataModel> apifyDataModels = new List<ApifyDataModel>();
            using (HttpClient httpClient = new HttpClient())
            {
                var responseString = await httpClient.GetStringAsync($"{apifyConfig.BaseUrl}{apifyConfig.RequestUrl}");
                apifyDataModels = JsonConvert.DeserializeObject<List<ApifyDataModel>>(responseString);
            }

            apifyDataModels.ForEach(async (apifyDataModel) =>
            {
                var location = _locator.GetLocationName(apifyDataModel.Country);
                apifyDataModel.Location = location == null ? new LocationDataModel() { Latitude = 0, Longitude = 0 } : location;
            });

            return apifyDataModels;
        }
    }
}

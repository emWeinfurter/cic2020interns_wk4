using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Ibm.Br.Cic.Internship.Covid.Be.Configuration;
using Ibm.Br.Cic.Internship.Covid.Be.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Ibm.Br.Cic.Internship.Covid.Be.Services
{
    public class LocatorService : ILocator
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public LocatorService(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            _configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
        }

        //returns by country code
        public LocationDataModel GetLocation(string countryName)
        {
            var locatorConfig = new LocatorConfig();
            _configuration.GetSection("LocatorConfig").Bind(locatorConfig);

            string contentRootPath = _webHostEnvironment.ContentRootPath;
            var json = File.ReadAllText($"{contentRootPath}/Data/{locatorConfig.Path}");
            var list = JsonConvert.DeserializeObject<List<LocationDataModel>>(json);

            LocationDataModel locationModel = list.Find(location => location.Country.Equals(countryName, StringComparison.OrdinalIgnoreCase));

            return locationModel;
        }

        //Compare by Name
        public LocationDataModel GetLocationName(string countryName)
        {
            var locatorConfig = new LocatorConfig();
            _configuration.GetSection("LocatorConfig").Bind(locatorConfig);

            string contentRootPath = _webHostEnvironment.ContentRootPath;
            var json = File.ReadAllText($"{contentRootPath}/Data/{locatorConfig.Path}");
            var list = JsonConvert.DeserializeObject<List<LocationDataModel>>(json);

            LocationDataModel locationModel = list.Find(location => location.Name.Equals(countryName, StringComparison.OrdinalIgnoreCase));

            return locationModel;
        }
    }
}

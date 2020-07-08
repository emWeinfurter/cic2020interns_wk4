using Ibm.Br.Cic.Internship.Covid.Be.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ibm.Br.Cic.Internship.Covid.Be.Services
{
    public interface ILocator
    {
        LocationDataModel GetLocation(string country);
        LocationDataModel GetLocationName(string country);
    }
}

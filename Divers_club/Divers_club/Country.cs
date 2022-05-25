using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divers_club
{
    internal class Country
    {
        public string countryName;
        private string countryDivingRegulations;

        public Country(string countryName, string countryDivingRegulations)
        {
            this.countryName = countryName;
            this.countryDivingRegulations = countryDivingRegulations;
        }

        public string GetName()
        {
            return this.countryName;
        }

        public string GetDivingRegulations()
        {
            return this.countryDivingRegulations;
        }

        public void SetDivingRegulations(string countryDivingRegulations)
        {
            this.countryDivingRegulations = countryDivingRegulations;
        }
    }
}

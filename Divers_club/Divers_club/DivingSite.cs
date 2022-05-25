using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divers_club
{
    internal class DivingSite
    {
        private string siteName;
        private Country siteCountry;
        private string siteAddress;
        private string aboutSite;
        private string typeOfWater;
        private double AmountOfMeters;
        private double SiteLength;
        private DivingClub diveClub;


        public DivingSite(string siteName, Country siteCountry, string siteAddress, string aboutSite, string typeOfWater, double AmountOfMeters, double SiteLength, DivingClub diveClub)
        {
            this.siteName = siteName;
            this.siteCountry = siteCountry;
            this.siteAddress = siteAddress;
            this.aboutSite = aboutSite;
            this.typeOfWater = typeOfWater;
            this.AmountOfMeters = AmountOfMeters;
            this.SiteLength = SiteLength;
            this.diveClub = diveClub;
        }

        public string GetSitesName()
        {
            return this.siteName;
        }

        public DivingClub GetSiteClub()
        {
            return this.diveClub;
        }
    }
}

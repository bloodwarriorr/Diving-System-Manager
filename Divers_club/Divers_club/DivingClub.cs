using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divers_club
{
    internal class DivingClub : IComparable<DivingClub>
    {
        private int clubLicense;
        private string clubName;
        private string contactPersonName;
        private string clubAddress;
        Country clubCountry;
        private int clubPhoneNumber;
        private string clubWebsite;

        public DivingClub(int clubLicense, string clubName, string contactPersonName, string clubAddress, Country clubCountry, int clubPhoneNumber, string clubWebsite)
        {
            this.clubLicense = clubLicense;
            this.clubName = clubName;
            this.contactPersonName = contactPersonName;
            this.clubAddress = clubAddress;
            this.clubCountry = clubCountry;
            this.clubPhoneNumber = clubPhoneNumber;
            this.clubWebsite = clubWebsite;
        }
        public void SetLicense(int licenseNum)
        {
            this.clubLicense = licenseNum;
        }
        public int GetLicense()
        {
            return this.clubLicense;
        }

        public void SetClubAddress(string clubAddress)
        {
            this.clubAddress = clubAddress;
        }
        public string GetClubAddress()
        {
            return this.clubAddress;
        }

        public void SetClubPhoneNumber(int clubPhoneNumber)
        {
            this.clubPhoneNumber = clubPhoneNumber;
        }
        public int GetClubPhoneNumber()
        {
            return this.clubPhoneNumber;
        }

        public void SetClubWebsite(string clubWebsite)
        {
            this.clubWebsite = clubWebsite;
        }
        public string GetClubWebsite()
        {
            return this.clubWebsite;
        }



        public void SetContactPersonName(string contactPersonName)
        {
            this.contactPersonName = contactPersonName;
        }
        public string GetContactPersonName()
        {
            return this.contactPersonName;
        }


        public string GetClubName()
        {
            return this.clubName;
        }
        public void SetClubName(string name)
        {
            this.clubName = name;
        }

        public Country GetCountry()
        {
            return this.clubCountry;
        }


        public int CompareTo(DivingClub diveClub)
        {
            if (this.clubLicense.Equals(diveClub.clubLicense))
                return 0;
            else
                return 1;
        }
    }
}

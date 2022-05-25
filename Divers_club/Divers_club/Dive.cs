using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divers_club
{
    internal class Dive:ICloneable
    {
        private DivingClub diveClub;
        private DateTime divingDate;
        private DateTime startTime;
        private DateTime endTime;
        private double tempOfWater;
        private string tide;
        private DivingSite diveSite;
        private Instractor instractor;
        private List<Equipment> equipment_list = new List<Equipment>();

        public Dive(DivingClub diveClub, DateTime divingDate, DateTime startTime, DateTime endTime, double tempOfWater,
            string tide, DivingSite diveSite, Instractor instractor)
        {
            this.diveClub = diveClub;
            this.divingDate = divingDate;
            this.startTime = startTime;
            this.endTime = endTime;
            this.tempOfWater = tempOfWater;
            this.tide = tide;
            this.diveSite = diveSite;
            this.instractor = instractor;
        }

        public Dive()
        {

        }

        public void SetSites(DivingSite diveSite)
        {
            this.diveSite = diveSite;
        }

        public void SetClub(DivingClub diveClub)
        {
            this.diveClub = diveClub;
        }

        public void SetTide(string dive_tide)
        {
            this.tide = dive_tide;
        }

        public void SetWaterTemp(double tempOfWater)
        {
            this.tempOfWater = tempOfWater;
        }

        public void SetDiveDate(DateTime divingDate)
        {
            this.divingDate = divingDate;
        }

        public void SetDiveStartTime(DateTime startTime)
        {
            this.startTime = startTime;
        }

        public void SetDiveEndTime(DateTime endTime)
        {
            this.endTime = endTime;
        }

        public void SetGuide(Instractor instractor)
        {
            this.instractor = instractor;
        }
        public DateTime GetDiveDate()
        {
            return this.divingDate;
        }

        public DateTime GetDiveStartTime()
        {
            return this.startTime;
        }


        public DateTime GetDiveEndTime()
        {
            return this.endTime;
        }

        public Instractor GetGuide()
        {
            return this.instractor;
        }

        public DivingClub GetClub()
        {
            return this.diveClub;
        }

        public DivingSite GetSite()
        {
            return this.diveSite;
        }

        public List<Equipment> GetGearList()
        {
            return this.equipment_list;
        }
        public void AddGear(Equipment equipment)
        {
            this.equipment_list.Add(equipment);
        }

        public virtual object Clone()
        {
            return new Dive( diveClub,  divingDate,  startTime,  endTime,  tempOfWater,
             tide,  diveSite,  instractor);
        }
    }
}

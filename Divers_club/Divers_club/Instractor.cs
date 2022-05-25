using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divers_club
{
    internal class Instractor:Diver
    {
        private DateTime instractorStartDate;
        private DateTime instractorEndDate;
        private DivingClub diveClub;

        public Instractor(int diverId, string diverFirstName, string diverLastName, DateTime dob, string password, string email,
            DateTime start_date, DateTime end_date, DivingClub diveClub)
            : base( diverId,diverFirstName,diverLastName,dob,password,email)
        {
            this.instractorStartDate = start_date;
            this.instractorEndDate = end_date;
            this.diveClub = diveClub;
        }


        public DivingClub GetClub()
        {
            return this.diveClub;
        }

        public DateTime GetStartDate()
        {
            return this.instractorStartDate;
        }

        public DateTime GetEndDate()
        {
            return this.instractorEndDate;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divers_club
{
    internal class Diver
    {
        StarRank rank { get; set; }
        protected int diverId;
        protected string diverFirstName;
        protected string diverLastName;
        protected DateTime dob;
        protected string password;
        protected string email;
        protected List<Dive> divingList = new List<Dive>();

        public Diver(int diverId, string diverFirstName, string diverLastName, DateTime dob, string password, string email)
        {
            this.diverId = diverId;
            this.diverFirstName = diverFirstName;
            this.diverLastName = diverLastName;
            this.dob = dob;
            this.password = password;
            this.email = email;
            rank = new StarRank();

        }

        public int GetId()
        {
            return this.diverId;
        }

        public string GetFirstName()
        {
            return this.diverFirstName;
        }

        public string GetLastName()
        {
            return this.diverLastName;
        }

        public DateTime GetDateOfBirth()
        {
            return this.dob;
        }

        public string GetPassword()
        {
            return this.password;
        }

        public string GetEmail()
        {
            return this.email;
        }

        public List<Dive> GetDiveList()
        {
            return this.divingList;
        }

        public int SetId()
        {
            return this.diverId;
        }

        public void SetFirstName(string diverFirstName)
        {
            this.diverFirstName = diverFirstName;
        }

        public void SetLastName(string diverLastName)
        {
            this.diverLastName = diverLastName;
        }

        public void SetDateOfBirth(DateTime dob)
        {
            this.dob = dob;
        }

        public void SetPassword(string password)
        {
            this.password = password;
        }

        public void SetEmail(string email)
        {
            this.email = email;
        }


        public void AddDive(Dive dive)
        {
            this.divingList.Add(dive);
            rank.SetRank(divingList.Count);
        }

        public string GetDiverRank()
        {
            return rank.defniton + " " + rank.decscription;
        }


    }
}

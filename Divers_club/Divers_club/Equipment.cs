using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divers_club
{
    internal class Equipment
    {
        private string EquipmentType;
        private int amount;
        private string ps;

        public Equipment(string EquipmentType, int amount, string ps)
        {
            this.EquipmentType = EquipmentType;
            this.amount = amount;
            this.ps = ps;
        }

        public string GetEquipmentType()
        {
            return this.EquipmentType;
        }

        public int GetAmount()
        {
            return this.amount;
        }
        //postscript linked to letters writing
        public string GetPs()
        {
            return this.ps;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divers_club
{
    internal class StarRank
    {
        string[] ranksType = { "none","one star","two star","assistant instractor","instractor" };
        string[] ranksDescription = { "0 dives","5 dives and below","10 dives and below","15 dives and below","20 dives and below"};
        public string defniton { get; private set; }
        public string decscription { get; private set; }

        public StarRank(string defniton, string decscription)
        {
            this.defniton = defniton;
            this.decscription = decscription;
        }
        public StarRank(int dives=0)
        {
            SetRank(dives);
        }

        public void SetRank(int rankCode)
        {
         if (rankCode == 0)
            {
                defniton = ranksType[0];
                decscription = ranksDescription[0];
            }
         else if (rankCode <= 5)
            {
                defniton = ranksType[1];
                decscription = ranksDescription[1];
            }
            else if (rankCode <= 10)
            {
                defniton = ranksType[2];
                decscription = ranksDescription[2];
            }
            else if (rankCode <= 15)
            {
                defniton = ranksType[3];
                decscription = ranksDescription[3];
            }
            else
            {
                defniton = ranksType[4];
                decscription = ranksDescription[4];
            }
        }
    }
}

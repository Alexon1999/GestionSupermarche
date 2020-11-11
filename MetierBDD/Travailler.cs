using System;
using System.Collections.Generic;
using System.Text;

namespace MetierBDD
{
    public class Travailler
    {
        private int idRayon;
        private int idSecteur;
        private DateTime date;
        private int tempTraville;

        public Travailler(int unIdRayon , int inIdSecteur , DateTime uneDate , int unTempsTravaille)
        {
            IdRayon = unIdRayon;
            IdSecteur = unIdRayon;
            Date = uneDate;
            TempTraville = unTempsTravaille;
        }

        public int IdRayon { get => idRayon; set => idRayon = value; }
        public int IdSecteur { get => idSecteur; set => idSecteur = value; }
        public DateTime Date { get => date; set => date = value; }
        public int TempTraville { get => tempTraville; set => tempTraville = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace MetierBDD
{
    public class Travailler
    {
        //private int idRayon;
        private int employeId;
        private Rayon leRayon;
        private DateTime date;
        private int tempTraville;

        public Travailler(int unEmployeId, Rayon unRayon , DateTime uneDate , int unTempsTravaille)
        {
            EmployeId = unEmployeId;
            LeRayon = unRayon;
            Date = uneDate;
            TempTraville = unTempsTravaille;
        }

        public DateTime Date { get => date; set => date = value; }
        public int TempTraville { get => tempTraville; set => tempTraville = value; }
        public Rayon LeRayon { get => leRayon; set => leRayon = value; }
        public int EmployeId { get => employeId; set => employeId = value; }
    }
}

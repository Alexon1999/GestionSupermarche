using System;
using System.Collections.Generic;
using System.Text;

namespace MetierBDD
{
    public class Employe
    {
        private int numEmploye;
        private string prenomEmploye;

        public Employe(int unNum , string unPrenom)
        {
            NumEmploye = unNum;
            PrenomEmploye = unPrenom;
        }

        public int NumEmploye { get => numEmploye; set => numEmploye = value; }
        public string PrenomEmploye { get => prenomEmploye; set => prenomEmploye = value; }
    }
}

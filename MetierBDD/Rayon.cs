using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetierBDD
{
    public class Rayon
    {
        private int numRayon;
        private string nomRayon;
        private int idSecteur;

        public Rayon(int unNumRayon , string unNomRayon , int unIdSecteur)
        {
            NumRayon = unNumRayon;
            NomRayon = unNomRayon;
            IdSecteur = unIdSecteur;
        }

        public int NumRayon { get => numRayon; set => numRayon = value; }
        public string NomRayon { get => nomRayon; set => nomRayon = value; }
        public int IdSecteur { get => idSecteur; set => idSecteur = value; }
    }
}

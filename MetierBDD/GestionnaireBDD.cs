using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Mail;
using MySql.Data.MySqlClient;

namespace MetierBDD
{
    public class GestionnaireBDD
    {
        //         les trois objets pour mysql
        // cnx sert à se connecter à la bdd
        private MySqlConnection cnx;
        // cmd sert à écrire nos rqêtes sql
        private MySqlCommand cmd;
        // dr : data readeer,  avec nos requêtes sql (sql) , il va nous permettre de récupérer le jeu d'enregistrement
        private MySqlDataReader dr;

        public GestionnaireBDD()
        {
            string chaine = "Server=localhost;port=3309;Database=supermarche;Uid=root;Pwd=";
            cnx = new MySqlConnection(chaine);
            cnx.Open();
        }

        public List<Secteur> GetAllSecteurs()
        {
            List<Secteur> lesSecteurs = new List<Secteur>();

            cmd = new MySqlCommand("SELECT secteur.numS , secteur.nomS from secteur;", cnx);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Secteur unSecteur = new Secteur(Convert.ToInt16(dr[0]), dr[1].ToString());
                lesSecteurs.Add(unSecteur);
            }

            dr.Close();

            return lesSecteurs;
        }

        public List<String> GetAllNomsSecteurs()
        {
            List<String> lesNomsSecteurs = new List<String>();

            cmd = new MySqlCommand("SELECT secteur.numS , secteur.nomS from secteur;", cnx);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string nomSecteur = dr[1].ToString();
                lesNomsSecteurs.Add(nomSecteur);
            }

            dr.Close();

            return lesNomsSecteurs;
        }

        public Secteur GetSecteurByNom(string unNomSecteur)
        {
            cmd = new MySqlCommand("SELECT secteur.numS , secteur.nomS from secteur WHERE secteur.nomS = " + "'" + unNomSecteur + "';"); // il faut mettre en guillemets ou code
            dr = cmd.ExecuteReader();
            dr.Read();

            Secteur unSecteur = new Secteur(Convert.ToInt16(dr[0]), dr[1].ToString());

            dr.Close();

            return unSecteur;
        }

        public List<Rayon> GetAllRayons()
        {
            List<Rayon> lesRayons = new List<Rayon>();

            cmd = new MySqlCommand("SELECT numR , nomR , numSecteur from rayon;", cnx);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Rayon r = new Rayon(Convert.ToInt16(dr[0]), dr[1].ToString(), Convert.ToInt16(dr[2]));
                lesRayons.Add(r);
            }

            dr.Close();

            return lesRayons;
        }

        public List<Rayon> GetAllRayonsBySecteur(string unNomSecteur)
        {
            List<Rayon> lesRayons = new List<Rayon>();

            cmd = new MySqlCommand("SELECT numR , nomR , numSecteur from rayon r INNER JOIN secteur ON r.numSecteur = secteur.numS  WHERE secteur.nomS = " + "'" + unNomSecteur + "';" , cnx);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Rayon r = new Rayon(Convert.ToInt16(dr[0]), dr[1].ToString(), Convert.ToInt16(dr[2]));
                lesRayons.Add(r);
            }

            dr.Close();

            return lesRayons;
        }

        public List<Employe> GetAllEmployes()
        {
            List<Employe> lesEmployes = new List<Employe>();

            cmd = new MySqlCommand("SELECT employe.numE , employe.prenomE from employe;" , cnx);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Employe e = new Employe(Convert.ToInt16(dr[0]), dr[1].ToString());
                lesEmployes.Add(e);
            }

            dr.Close();

            return lesEmployes;
        }

        public List<String> GetAllPrenomsEmployes()
        {
            List<String> lesEmployes = new List<String>();

            cmd = new MySqlCommand("SELECT employe.prenomE from employe;", cnx);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                lesEmployes.Add(dr[0].ToString());
            }

            dr.Close();

            return lesEmployes;
        }

        public List<Travailler> GetAllDetailsTravailDEmploye(int unNumEmploye)
        {
            List<Travailler> lesTravails = new List<Travailler>();

            cmd = new MySqlCommand("SELECT t.codeE,r.numR,r.nomR,r.numSecteur,t.date,t.temps from travailler t INNER JOIN rayon r on t.codeR = r.numR where codeE = " + unNumEmploye, cnx);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                
                Rayon r = new Rayon(Convert.ToInt16(dr[1]), dr[2].ToString(), Convert.ToInt16(dr[3]));

                //    DateTime  : object
                //Convert.ToDateTime()
                // DateTime Object DateTime d =qqc    , d.ToShortDateString()

                Travailler t = new Travailler(Convert.ToInt16(dr[0]), r, Convert.ToDateTime(dr[4].ToString()), Convert.ToInt16(dr[5]));

                lesTravails.Add(t);
            }

            dr.Close();

            return lesTravails;
        }

        public int GetLastNumEmployes()
        {
            int lastNum;
            cmd = new MySqlCommand("select MAX(numE) from Employe;", cnx);
            dr = cmd.ExecuteReader();
            dr.Read();

            lastNum = Convert.ToInt16(dr[0]) + 1;

            dr.Close();

            return lastNum;
            //return Convert.ToInt16(dr[0]) + 1;
        }

        public void AjouterEmploye(int unNum , string unNomEmploye)
        {
            cmd = new MySqlCommand("insert into employe values(" + unNum + "," + "'" + unNomEmploye + "'" + ");" , cnx);
            cmd.ExecuteNonQuery();
        }

        public void ajouterTravailler(Employe unEmploye , Rayon unRayon , string uneDate , int tempsDeTravails)
        {
            bool aTravailler = aDejaTravaillerPourUneDateParRayon(uneDate, unEmploye.NumEmploye , unRayon.NumRayon);

            if (!aTravailler)
            {
                cmd = new MySqlCommand( "insert into travailler values(" + unEmploye.NumEmploye + "," + unRayon.NumRayon + "," + "'" + uneDate + "'" + "," + tempsDeTravails +  ");" , cnx);
                cmd.ExecuteNonQuery();
            }
        }

        public bool aDejaTravaillerPourUneDateParRayon(string uneDate , int numEmploye , int numRayon)
        {
            cmd = new MySqlCommand("SELECT * from travailler WHERE travailler.date = " + "'" + uneDate + "'"  + " AND " + "travailler.codeE = " + numEmploye + " AND " + "travailler.codeR = " + numRayon +  ";", cnx);
            dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                dr.Close();
                return true;
            }
            dr.Close();
            return false;
        }

    }

   
}

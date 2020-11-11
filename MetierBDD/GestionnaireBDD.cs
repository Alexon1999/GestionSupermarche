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

        public void AjouterEmploye(int unNum , string unNomEmploye)
        {
            cmd = new MySqlCommand("insert into employe values( " + unNum + "," + "'" + unNomEmploye + "'" + ");" , cnx);
            cmd.ExecuteNonQuery();
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

    }

   
}

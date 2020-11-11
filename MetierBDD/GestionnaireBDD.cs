using System;
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



    }
}

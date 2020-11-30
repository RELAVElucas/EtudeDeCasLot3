using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication1.Models;

namespace Etudedecas
{
    class Bdd
    {
        private MySqlConnection connection;


        public Bdd()
        {
            this.InitConnexion();
        }


        private void InitConnexion()
        {

            string connectionString = "SERVER=127.0.0.1; DATABASE=etudedecas; UID=lucas; PASSWORD=123456789";
            this.connection = new MySqlConnection(connectionString);

        }

        public List<string> getClients()
        {
            List<string> clients = new List<string>();
            this.connection.Open();

            MySqlCommand cmd = this.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "SELECT * From client";

            // Exécution de la commande SQL
            cmd.ExecuteNonQuery();

            MySql.Data.MySqlClient.MySqlDataReader reader = cmd.ExecuteReader();


            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    clients.Add(reader.GetString(0));
                }
                reader.Close();
            }

            // Fermeture de la connexion
            this.connection.Close();

            return clients;

        }


        public void AddContact(Client client)
        {
            try
            {


                this.connection.Open();


                MySqlCommand cmd = this.connection.CreateCommand();

                // Requête SQL
                cmd.CommandText = "INSERT INTO client (idClient,nameClient,firstnameClient,addressClient) VALUES (@idClient, @nameClient, @firstnameClient, @addressClient)";

                // utilisation de l'objet client passé en paramètre
                cmd.Parameters.AddWithValue("@idClient", client.Id);
                cmd.Parameters.AddWithValue("@nameClient", client.Name);
                cmd.Parameters.AddWithValue("@firstnameClient", client.FirstName);
                cmd.Parameters.AddWithValue("@addressClient", client.Address);

                // Exécution de la commande SQL
                cmd.ExecuteNonQuery();

                // Fermeture de la connexion
                this.connection.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                Console.WriteLine("Champs avec l'id :" + client.Id + " déja renseigner en base ");
            }
        }

    }
}

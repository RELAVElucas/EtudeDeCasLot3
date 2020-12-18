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

        public List<Client> getClients()
        {
            List<Client> clients = new List<Client>();
            this.connection.Open();

            MySqlCommand cmd = this.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "SELECT idClient,nameClient,firstnameClient,addressClient From client";

            // Exécution de la commande SQL
            cmd.ExecuteNonQuery();

            MySql.Data.MySqlClient.MySqlDataReader reader = cmd.ExecuteReader();


            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Client client = new Client();
                    client.Id = reader.GetString(0);
                    client.Name = reader.GetString(1);
                    client.FirstName = reader.GetString(2);
                    client.Address = reader.GetString(3);
                    clients.Add(client);
                }
                reader.Close();
            }

            // Fermeture de la connexion
            this.connection.Close();

            return clients;

        }

        public Boolean authentification(string email, string password)
        {
            this.connection.Open();
            MySqlCommand cmd = this.connection.CreateCommand();
            // Requête SQL
            cmd.CommandText = "Select * FROM user where email = @email and password = @password";
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@password", password);

            // Exécution de la commande SQL
            MySql.Data.MySqlClient.MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                return true;
            }
            else {
                return false;
            }

            this.connection.Close();

        }

        public void DeleteClient(Client client) {
            this.connection.Open();

            MySqlCommand cmd = this.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "delete FROM etudedecas.client where idClient = @idClient;";
            cmd.Parameters.AddWithValue("@idClient", client.Id);
            cmd.ExecuteNonQuery();

            // Fermeture de la connexion
            this.connection.Close();
        }

        public void UpdateClient(Client client)
        {
            this.connection.Open();

            MySqlCommand cmd = this.connection.CreateCommand();

            // Requête SQL
            cmd.CommandText = "UPDATE client SET idClient = '"+client.Id+"', nameClient = '"+client.Name+"', firstnameClient = '"+client.FirstName+"', addressClient = '"+client.Address+ "' WHERE idClient = '" + client.Id + "'";

            cmd.ExecuteNonQuery();

            // Fermeture de la connexion
            this.connection.Close();
        }

        public string AddContact(Client client)
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
                return "success";

            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                return "Champs avec l'id :" + client.Id + " déja renseigner en base ";
            }
        }

    }
}

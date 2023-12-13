using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Onela
{
    public class DBConnector
    {
        public List<Contact> ExecuteQuerySelect()
        {
            List<Contact> queryResults = new List<Contact>();

            string connString = "server=localhost;user=root;database=onela;port=3306;password=Pa$$w0rd;";

            MySqlConnection connection = new MySqlConnection(connString);
            connection.Open();

            string query = "SELECT * FROM contact";

            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
           
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
                {

                Contact contact = new Contact(
                    Firstname: reader.GetString(1),
                    Lastname: reader.GetString(2),
                    numberPhone: reader.GetString(3)
                    );

                queryResults.Add(contact);
            }
            return queryResults;
        }
        public bool ExecuteQueryInsert(Contact contact)
        {
            string connString = "server=localhost;user=root;database=onela;port=3306;password=Pa$$w0rd;";

            MySqlConnection connection = new MySqlConnection(connString);
            connection.Open();

            string query = "INSERT INTO contact (firstname, lastname, phone_number) VALUES ('" + contact.Firstname + "', '" + contact.Lastname + "', '" + contact.Numberphone + "');";

            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            return true;
        }
    }
}
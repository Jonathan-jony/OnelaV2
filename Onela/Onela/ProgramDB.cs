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
                    numberPhone: reader.GetString(3),
                    active: reader.GetString(4),
                    image: reader.GetString(5)
                    );

                queryResults.Add(contact);
            }
            return queryResults;
        }
        public Contact ExecuteQuerySelectOneContact(string numberPhone)
        {
            Contact contact = null;

            string connString = "server=localhost;user=root;database=onela;port=3306;password=Pa$$w0rd;";

            MySqlConnection connection = new MySqlConnection(connString);
            connection.Open();

            string query = "SELECT * FROM contact where phone_number ='" + numberPhone + "';";

            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                 contact = new Contact(
                    Firstname: reader.GetString(1),
                    Lastname: reader.GetString(2),
                    numberPhone: reader.GetString(3),
                    active: reader.GetString(4),
                    image: reader.GetString(5)
                    );
            }
            return contact;
        }
        public List<Contact> ExecuteQuerySelectFilter(string search)
        {
            List<Contact> queryResults = new List<Contact>();

            string connString = "server=localhost;user=root;database=onela;port=3306;password=Pa$$w0rd;";

            MySqlConnection connection = new MySqlConnection(connString);
            connection.Open();

            string query = "SELECT * FROM contact WHERE firstname LIKE '%" +  search + "%' OR lastname LIKE '%" +  search + "%';";

            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                Contact contact = new Contact(
                    Firstname: reader.GetString(1),
                    Lastname: reader.GetString(2),
                    numberPhone: reader.GetString(3),
                    active: reader.GetString(4),
                    image: reader.GetString(5)
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

            string query = "INSERT INTO contact (firstname, lastname, phone_number, active, image) VALUES ('" + contact.Firstname + "', '" + contact.Lastname + "', '" + contact.Numberphone + "', '1', '" + contact.Image +"');";

            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            return true;
        }
        public bool ExecuteQueryUpdate(Contact contact, string oldnumber, bool blocked)
        {
            string connString = "server=localhost;user=root;database=onela;port=3306;password=Pa$$w0rd;";

            MySqlConnection connection = new MySqlConnection(connString);
            connection.Open();
            string query;

            if (blocked)
            {
                query = "UPDATE contact SET firstname = '" + contact.Firstname + "', lastname ='" + contact.Lastname + "', phone_number ='" + contact.Numberphone + "', active = 0 WHERE phone_number ='" + oldnumber + "';";
            }
            else
            {
                query = "UPDATE contact SET firstname = '" + contact.Firstname + "', lastname ='" + contact.Lastname + "', phone_number ='" + contact.Numberphone + "', active = 1 WHERE phone_number ='" + oldnumber + "';";
            }
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            return true;
        }
    }
}
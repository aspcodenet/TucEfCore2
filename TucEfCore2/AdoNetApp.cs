using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace TucEfCore2
{
    public class AdoNetApp
    {
        private string connectionString;
        public AdoNetApp()
        {
            connectionString = "Server=localhost;Database=StefanSuperShop;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true";
        }
        public void Run()
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();
            var command = new SqlCommand("select id, name, baseprice, imageurl from Products", connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"{reader.GetInt32(0)}  {reader.GetString(1)} {reader.GetInt32(2)}, {reader.GetString(3)}  ");
            }
            connection.Close();


        }
    }
}

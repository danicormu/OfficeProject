using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace OfficeProject.Models
{
    public class DBConnection
    {
        private static DBConnection dbInstance;
        private static string path = ConfigurationManager.ConnectionStrings["pruebaDBEntities"].ConnectionString;
        private SqlConnection conn = new SqlConnection(path);

        private DBConnection()
        {

        }

        public static DBConnection getDbInstance()
        {
            if(dbInstance == null)
            {
                dbInstance = new DBConnection();
            }
            return dbInstance;
        }

        public SqlConnection getDBConnection()
        {
            try
            {
                conn.Open();
                Console.WriteLine("Connected!");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Not Connected: " + e.Message);
                Console.ReadLine();
            }
            finally
            {
                Console.WriteLine("End!");
                Console.WriteLine("Not Connected: " + e.Message);
                Console.ReadLine();
            }
            Console.ReadLine();
            return conn;
        }
    }
}
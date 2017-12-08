using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HP_MSA.backend
{
    public class StorageList<String>
    {
        public StorageList()
        {
        }

        private static List<string> GetStorageList() {
            List<string> sList = new List<string>();
            try
            {
                MySqlConnection sqlconn;
                string connsqlstring = "Server=msa.cz0sfiru3pto.us-east-1.rds.amazonaws.com;Port=3306;database=HP-MSA;User Id=gordon;Password=password;charset=utf8";
                sqlconn = new MySqlConnection(connsqlstring);
                sqlconn.Open();
                string queryString = "select count(0) from ACCOUNT";
                MySqlCommand sqlcmd = new MySqlCommand(queryString, sqlconn);
                string result = sqlcmd.ExecuteScalar().ToString();
                Console.WriteLine(result);
                sqlconn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return sList;
        } 

    }
}

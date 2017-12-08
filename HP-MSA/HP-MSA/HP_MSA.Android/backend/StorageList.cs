using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using MySql.Data.dll;

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
                new I18N.West.CP1250();
                MySqlConnection sqlconn;
                string connsqlstring = "Server=your.ip.address;Port=3306;database=msa.cz0sfiru3pto.us-east-1.rds.amazonaws.com;User Id=gordon;Password=password;charset=utf8";
                sqlconn = new MySqlConnection(connsqlstring);
                sqlconn.Open();
                string queryString = "select count(0) from ACCOUNT";
                MySqlCommand sqlcmd = new MySqlCommand(queryString, sqlconn);
                String result = sqlcmd.ExecuteScalar().ToString();
                LblMsg.Text = result + " accounts in DB";
                sqlconn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return sList
        } 

    }
}

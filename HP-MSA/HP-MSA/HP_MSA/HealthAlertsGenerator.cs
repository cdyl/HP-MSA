// +JMJ+
// Paul A Maurais

using System;
using System.Text; 
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace HP_MSA
{
    public class HealthAlertsGenerator
    {


        private static String getData(String companyName)
        {
            HttpWebRequest request=(HttpWebRequest)HttpWebRequest.Create (new Uri ("http://54.173.140.216:8080"));
            
            var postData = "query=SELECT `capacity.total.freePct`, systemName FROM data WHERE companyName='"+companyName+"'";
            var data = Encoding.ASCII.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            return responseString.Substring(1,responseString.Length-1);

        }


        public static List<List<String>> alert(String companyName)
        {
            String rawData = getData(companyName);
            List<List<String>> data = new List<List<String>>();
            
            Regex rgx = new Regex(@"\[.*?\]");
            foreach (Match match in rgx.Matches(rawData))
            {
                String tmp = match.Value.Substring(1, match.Value.Length - 2);
                List<String> vals = tmp.Split(',').ToList<String>();

                if (Convert.ToDouble(vals[0]) < 10)
                {
                    data.Add(vals);
                }
            }
            
            

            return data;
        }
               
        
        
    }
}


//+JMJ+
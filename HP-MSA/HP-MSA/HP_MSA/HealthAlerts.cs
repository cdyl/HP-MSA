// +JMJ+
// Paul A Maurais

using System;
using System.Text; 
using System.IO;
using System.Net;

namespace HP_MSA
{
    public class HealthAlerts
    {


        private static String checkStatus()
        {
            HttpWebRequest request=(HttpWebRequest)HttpWebRequest.Create (new Uri ("http://54.173.140.216:8080"));
            
            var postData = "query=SELECT * FROM users";
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

            return responseString;

        }


        public static String alert()
        {
            return checkStatus();
        }
               
        
        
    }
}


//+JMJ+
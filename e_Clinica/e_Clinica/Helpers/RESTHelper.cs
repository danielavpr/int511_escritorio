using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e_Clinica.Helpers
{
    class RESTHelper
    {
        private static string Url = "http://192.168.1.200:4000";
        public static string Execute(string Param, string Datos, string Metodo)
        {
            string json = "[]";
            try
            {
                byte[] data = UTF8Encoding.UTF8.GetBytes(Datos);

            HttpWebRequest request;
            request = WebRequest.Create(Url+Param) as HttpWebRequest;
            request.Timeout = 10 * 1000;
            request.Method = Metodo;
            request.ContentType = "application/json; charset=utf-8";
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);

            // request.ContentLength = data.Length;

            // Stream postStream = request.GetRequestStream();
            // postStream.Write(data, 0, data.Length);


            //StreamReader reader = new StreamReader(response.GetResponseStream());

            json = reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error en el servidor");               
            }

            return json;
        }
        public static  string PostJSON(string Param, string json)
        {
            HttpWebRequest request;
            var result="";
            request = WebRequest.Create(Url + Param) as HttpWebRequest;
            request.Timeout = 10 * 1000;
            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";
            try {
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    //string json = "{\"user\":\"test\"," +
                    //              "\"password\":\"bla\"}";

                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error en el servidor");
            }
            return result; 
        }
    }
}

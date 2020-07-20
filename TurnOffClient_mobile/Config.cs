using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.IO;


namespace TurnOffClient_mobile
{
    class Config {
        string path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "Config.txt");
        public void saveData(String ip,String port) {
            using (StreamWriter file = new StreamWriter(path, true)) {
                file.WriteLine("ip "+ip);
                file.WriteLine("port "+port);
            }
            
        }

        public void checkExistence() {
            if (!System.IO.File.Exists(path)) {
                System.IO.File.Create(path);
            }
        }
        public string loadIp() {
            StreamReader reader = new StreamReader(path);
            String ip=null;
            String line ;

            while ((line = reader.ReadLine()) != null) {
                if (line.Contains("ip")) { 
                    ip = line; 
                }
            }
            reader.Close();
             
            return formatString(ip, "ip ");
        }

        public string loadPort() {
            StreamReader reader = new StreamReader(path);
            String port = null;
            String line;

            while ((line = reader.ReadLine()) != null) {
                if (line.Contains("port")) {
                    port = line;
                }
            }
            reader.Close();
            
            return formatString(port,"port ");
        }

        private string formatString(String data,String keyword) {
             data = data.Trim(keyword.ToCharArray()) ;
            return data;
        }



    }

}
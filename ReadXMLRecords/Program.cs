using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;
using System.IO;
using System.Net.Mail;
using System.Net;

namespace ReadXMLRecords
{
    class Program
    {
        static void Main(string[] args)
        {

         
             string WorkingDirectory = @"C:\temp\xml";
         
             int intTotalCounts;

            string[] FileNamesWithPath = Directory.GetFiles(WorkingDirectory);


            foreach (string FileName in FileNamesWithPath)
            {
                string XMLFileName = Path.GetFileName(FileName);            
                string soucexml = FileName;

                XmlDocument doc = new XmlDocument();
                try
                {
                    doc.Load(soucexml);
                }
                catch (Exception ex)
                {
                    //File.Move(FileName, POPath1 + POFileName);
                    ErrorLogging(ex);
                    // ReadError();
                    System.Environment.Exit(1);
                }

                int OrderCount = 0;

                foreach (XmlNode node in doc.DocumentElement)
                {
                    //First Child node is "Buyer"
                    if (node.Name == "OrderInfo")
                    {
                        OrderCount = OrderCount + 1;
                    }
                }


                intTotalCounts = OrderCount;
                Console.WriteLine(intTotalCounts);
                Console.Read();
               
            }
            







        }

        public static void ErrorLogging(Exception ex)
        {
            string strPath = @"C:\temp\Logfiles\Errors\" + System.DateTime.Now.ToString("yyyyMMdd") + ".txt";
            if (!File.Exists(strPath))
            {
                File.Create(strPath).Dispose();
            }
            using (StreamWriter sw = File.AppendText(strPath))
            {
                sw.WriteLine("=============Error Logging ===========");
                sw.WriteLine("===========Start============= " + DateTime.Now);
                sw.WriteLine("Error Message: " + ex.Message);
                sw.WriteLine("Stack Trace: " + ex.StackTrace);
                sw.WriteLine("===========End============= " + DateTime.Now);
                sw.WriteLine("");
                sw.WriteLine("");

            }
        }
    }
}

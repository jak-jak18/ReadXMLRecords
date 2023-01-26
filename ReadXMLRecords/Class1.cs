using System;
using System.IO;
using System.Xml;

namespace ReadXMLRecords
{
    class Class1
    {
        static void Main(string[] args)
        {
            foreach (string FileName in Directory.GetFiles(@"C:\temp"))
            {
                string XMLFileName = Path.GetFileName(FileName);

                XmlDocument doc = new XmlDocument();
                try { doc.Load(FileName); }               
                catch (Exception ex)
                {
                    //File.Move(FileName, POPath1 + POFileName);
                    ErrorLogging(ex);
                    // ReadError();
                    System.Environment.Exit(1);
                }

                XmlNodeList nodes = doc.DocumentElement.SelectNodes("OrderInfo");
                int OrderCount = 0;
                foreach (XmlNode node in nodes) {OrderCount++;}                

                Console.WriteLine(OrderCount);
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



using LiteDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeFiles
{
    class Program
    {
        static string[] protectPath = { @"C:\WINDOWS", @"C:\Users", @"C:\Program Files", @"C:\Program Files (x86)" };


        static void Main(string[] args)
        {

            bool successrun = false;

            bool haveLastTime = false;
            DateTime lastCreateDate;
            string oldgendatetimefile = "";
            string newgendatetimefile = "_" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";

            using (var db = new LiteDatabase(AppDomain.CurrentDomain.BaseDirectory + @"DateTimeFiles.db"))
            {
                var col1 = db.GetCollection<TimeLog>("timelog");


                foreach (var _log in col1.FindAll())
                {
                    haveLastTime = true;
                    lastCreateDate = _log.CreateDate;
                    oldgendatetimefile = "_" + lastCreateDate.ToString("yyyy-MM-dd") + ".txt";
                }

                var col = db.GetCollection<PathSetting>("path");
                foreach (var _path in col.FindAll())
                {
                    if (_path.path != "")
                    {


                        if (!Directory.Exists(_path.path))
                        {
                            Console.WriteLine("Directory " + _path.path + " not exist, Skipping!");
                        }
                        else
                        {

                            // delete old file first
                            if (haveLastTime)
                            {
                                if (File.Exists(_path.path + "\\" + oldgendatetimefile))
                                {
                                    Console.WriteLine("Delete old file " + _path.path + "\\" + oldgendatetimefile);
                                    File.Delete(_path.path + "\\" + oldgendatetimefile);
                                }

                            }

                            using (StreamWriter writer = new StreamWriter(_path.path + "\\" + newgendatetimefile))
                            {
                                Console.WriteLine("Generate file " + _path.path + "\\" + newgendatetimefile);

                                writer.WriteLine(DateTime.Now.ToString("yyyy-MM-dd") + " " + DateTime.Now.ToString("HH:mm:ss"));
                                successrun = true;
                            }
                        }
                    }

                }

                if (successrun)
                {
                    col1.DeleteAll();

                    
                    TimeLog l = new TimeLog
                    {
                        _id = RandomString(16),
                        CreateDate = DateTime.Now
                    };
                    col1.Insert(l);

                   

                }

            }

            Console.WriteLine("End");
        }

        static private string RandomString(int length)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[length];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
        }
    }
}

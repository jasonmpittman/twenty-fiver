using System;
using System.IO;
using System.Text;

namespace TwentyFive.Metro
{
    class TwentyFiveLogger
    {
        //filename: twentyfive.date
        //entry: [date],[time],[task],[state:start|stop]

        private string dateFormatted = string.Format("{0:ddMMyyyy}", DateTime.Now);
        private string timeFormatted = string.Format("{0:HH:mm:ss}", DateTime.Now);

        private string fileName = "twentyfive." + DateTime.Today.Day.ToString() + DateTime.Today.Month.ToString() + DateTime.Today.Year.ToString();
        private string folder = AppDomain.CurrentDomain.BaseDirectory + "twentyfives\\";
        private string twentyfiver;

        public TwentyFiveLogger(string task, string state)
        {
            twentyfiver = dateFormatted + "," + timeFormatted + "," + task + "," + state;
        }

        public void LogTwentyFiver()
        {
            
            if (twentyfiver.Length > 0)
            {
                using (StreamWriter sw = File.AppendText(folder +  fileName))
                {
                    sw.WriteLine(twentyfiver);
                    sw.Flush();
                }
            }
        }

    }
}

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kpo4317_DJR.Lib
{
    public static class LogUtility
    {
        public static void ErrorLog(string message)
        {
            message = "\n" + DateTime.Now + ": " + message;
            File.AppendAllText("error.log", message);
        }

        public static void ErrorLog(Exception exception)
        {
            string message = "\n" + DateTime.Now + ": " + exception.Message;
            File.AppendAllText("error.log", message);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModSDK.Api
{
    public class NKLogger
    {
        public static void LogToFile(string message) => new NKLogMessage(message).LogToFile();

        public static void LogToFile(NKLogMessage message) => message.LogToFile();
        public static void LogToFile(NKLogMessage message, string filePath) => message.LogToFile(filePath);

        public static void LogToFile(string message, string sender) => new NKLogMessage(message, sender).LogToFile();
        public static void LogToFile(string message, string sender, string filePath) => new NKLogMessage(message, sender).LogToFile(filePath);
    }
}

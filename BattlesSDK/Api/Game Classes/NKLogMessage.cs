using ModSDK.Api.Hooks;
using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace ModSDK.Api
{
    public class NKLogMessage
    {
        public static long LogInstance { get; set; } = -1;
        public static long DefaultSender { get; set; } = -1;

        public string Message { get; set; }
        public string Sender { get; set; } = "";
        public DateTime TimeSent { get; set; } = default(DateTime);

        public NKLogMessage(string message)
        {
            Message = message;
        }

        public NKLogMessage(string message, string sender)
        {
            Message = message;
            Sender = sender;
        }

        internal void LogToFile(string filePath)
        {
            FileStream fileStream = new FileStream(filePath, FileMode.Append);
            StreamWriter writer = new StreamWriter(fileStream);
            LogToFile();
            
        }

        internal void SetSenderFromAddress(long senderAddress)
        {
            Sender = "";
        }

        internal unsafe void LogToFile()
        {
            TimeSent = DateTime.Now;
            string logTime = TimeSent.ToString("dd/MM/yy HH:mm:ss");
            
            Sender = "Hello World Mother Fuckers!";
            bool hasSender = !string.IsNullOrEmpty(Sender);
            //var messageToLog = logTime + (hasSender ? " >> " : " > ") + "  " + Message + "\n";
            var messageToLog = Message + "\n";

            int messageLength = messageToLog.Length + Sender.Length;

            var defaultSender = ((NKLogMsgInfoStruct*)DefaultSender);
            NKLogMsgInfoStruct infoStruct = new NKLogMsgInfoStruct();
            infoStruct.senderName = Sender.GetAddress();
            infoStruct.messageLength = messageLength;
            infoStruct.numCharactersWritten = defaultSender->numCharactersWritten;
            infoStruct.value3 = defaultSender->value3;
            infoStruct.value0 = defaultSender->value0;

            var p = &infoStruct;
            NKLogger_LogToFile.Function.GetWrapper()(LogInstance, p, messageToLog, messageLength, 1);
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString();
        }


        /// <summary>
        /// Create an NKLogMessage from one c
        /// </summary>
        /// <param name="entireMessage"></param>
        /// <returns></returns>
        public static NKLogMessage FromLoggedMessage(string entireMessage)
        {
            string[] split = entireMessage.Replace("\n","").Trim().Split(' ');

            string timeSentStr = split[0] + " " + split[1];
            bool validTimeSent = DateTime.TryParse(timeSentStr, out var timeSent);
            entireMessage = entireMessage.Replace(timeSentStr, "");

            string message = "";
            string sender = "";
            NKLogMessage logMessage = new NKLogMessage(message)
            {
                TimeSent = validTimeSent ? timeSent : default(DateTime),
            };


            return logMessage;
        }
    }
}

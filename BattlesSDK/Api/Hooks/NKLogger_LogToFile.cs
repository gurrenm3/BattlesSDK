using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.X64;
using System;

namespace ModSDK.Api.Hooks
{
    /// <summary>
    /// The hook for Ninja Kiwi's logger, which logs important messages to file.
    /// </summary>
    public static unsafe class NKLogger_LogToFile
    {
        /// <summary>
        /// The Reloaded Hook interface for this in game function.
        /// </summary>
        public static IHook<HookDelegate> Hook;

        /// <summary>
        /// The Reloaded Function interface for this in game function.
        /// </summary>
        public static IFunction<HookDelegate> Function { get; set; }

        /// <summary>
        /// The Delegate that represents this game function. Used to perform the hook.
        /// </summary>
        /// <param name="loggerInstance"></param>
        /// <param name="senderInfo">Struct that contains info about the sender</param>
        /// <param name="messageToLog">Actual message to log to file</param>
        /// <param name="messageLength">The length of the message to log.</param>
        /// <param name="a5"></param>
        /// <returns></returns>
        [Function(CallingConventions.Microsoft)]
        public delegate long HookDelegate(long loggerInstance, NKLogMsgInfoStruct* senderInfo, string messageToLog, int messageLength, int a5);

        private static int numStringsWithLogName = 0;
        internal static string logFilePath = "";

        /// <summary>
        /// Initialize method. Scans for the game function's signature and hooks it.
        /// </summary>
        /// <param name="hooks"></param>
        public static void Init(IReloadedHooks hooks)
        {
            Signature logMessageSig = new Signature("48 8B C4 55 53 56 57 41 56 41 57 48 8D 68 C8 48 81 EC ? ? ? ? 0F 29 70 B8 0F 29 78 A8 48 8B 05 ? ? ? ? 48 33 C4 48 89 45 D0 4D 8B F1 49 8B F0 48 8B DA 48 8B F9 48 89 54 24 ? C7 44 24");
            Function = hooks.CreateFunction<HookDelegate>(logMessageSig.Scan());
            Hook = Function.Hook(CodeToExecute).Activate();
            GetLogFilePath();
        }


        static long CodeToExecute(long loggerInstance, NKLogMsgInfoStruct* senderInfo, string messageToLog, int messageLength, int a5)
        {
            if (NKLogMessage.LogInstance == -1)
                NKLogMessage.LogInstance = loggerInstance;

            if (NKLogMessage.DefaultSender == -1)
                NKLogMessage.DefaultSender = *(long*)(senderInfo);

            //ModLogger.APIWriteLine($"a1: {loggerInstance}, a2: {senderAddress}, messageToLog: {messageToLog}, a4: {messageLength}, a5: {a5}");

            var logMessage = new NKLogMessage(messageToLog);
            logMessage.TimeSent = DateTime.Now;
            


            /*ModLogger.APIWriteLine("-----");

            var senderStruct = senderInfo;
            var valueToLog = senderStruct->senderName;

            var stringResult = StringUtil.TryToString((long)valueToLog);
            if (!string.IsNullOrEmpty(stringResult))
            {
                ModLogger.APIWriteLine("Sender: " + stringResult);
                ModLogger.APIWriteLine("Sender.Length: " + stringResult.Length);
                ModLogger.APIWriteLine("senderStruct->value0: " + senderStruct->value0);
                ModLogger.APIWriteLine("senderStruct->messageLength: " + senderStruct->messageLength);
                ModLogger.APIWriteLine("senderStruct->numCharactersWritten: " + senderStruct->numCharactersWritten);
                ModLogger.APIWriteLine("senderStruct->value3: " + senderStruct->value3->ToString());

                ModLogger.APIWriteLine("messageToLog.Length: " + messageToLog.Length);
                ModLogger.APIWriteLine("messageLength: " + messageLength + "\n");
                //ModLogger.APIWriteLine(StringUtil.TryToString(senderStruct->messageLength)); // idk what this value is
            }*/


            
            var result = Hook.OriginalFunction(loggerInstance, senderInfo, messageToLog, messageLength, a5);

            
            /*senderStruct = senderInfo;
            valueToLog = senderStruct->senderName;

            ModLogger.APIWriteLine("senderStruct->value0: " + senderStruct->value0);
            ModLogger.APIWriteLine("senderStruct->messageLength: " + senderStruct->messageLength);
            ModLogger.APIWriteLine("senderStruct->numCharactersWritten: " + senderStruct->numCharactersWritten);
            ModLogger.APIWriteLine("senderStruct->value3: " + senderStruct->value3->ToString());

            NKLogger.LoggedMessages.Add(logMessage);
            NKLogger.OnMessageLogged.Invoke(logMessage);*/

            return result;
        }


        private static void GetLogFilePath()
        {
            const int filePathIndex = 2;
            StdString.OnStringCreated.AddListener((str) =>
            {
                if (!str.Contains("NKLOG") || numStringsWithLogName > filePathIndex) return;

                numStringsWithLogName++;
                if (numStringsWithLogName != filePathIndex) return;
                logFilePath = str;
                NKLogger.LogFilePath = logFilePath;
            });
        }
    }
}

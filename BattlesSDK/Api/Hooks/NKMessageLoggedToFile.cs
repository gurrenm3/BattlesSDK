using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.X64;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ModSDK.Api.Hooks
{
    public static unsafe class NKMessageLoggedToFile
    {
        /// <summary>
        /// All of the messages that have been logged to the game's log file so far.
        /// </summary>
        public static List<NKLogMessage> NKLogMessages { get; private set; } = new List<NKLogMessage>();

        private static IntPtr logAddress;
        private static IntPtr senderAddress;

        public static IHook<HookDelegate> Hook;
        public static IFunction<HookDelegate> Function { get; set; }

        [Function(CallingConventions.Microsoft)]
        public delegate long HookDelegate(long a1, NKLogMsgInfoStruct* a2, string messageToLog, int a4, int a5);        

        public static void Init(IReloadedHooks hooks)
        {
            Signature logMessageSig = new Signature("48 8B C4 55 53 56 57 41 56 41 57 48 8D 68 C8 48 81 EC ? ? ? ? 0F 29 70 B8 0F 29 78 A8 48 8B 05 ? ? ? ? 48 33 C4 48 89 45 D0 4D 8B F1 49 8B F0 48 8B DA 48 8B F9 48 89 54 24 ? C7 44 24");
            Function = hooks.CreateFunction<HookDelegate>(logMessageSig.Scan());
            Hook = Function.Hook(OnLogToFile).Activate();
        }

        static long OnLogToFile(long loggerInstance, NKLogMsgInfoStruct* senderInfo, string messageToLog, int messageLength, int a5)
        {
            if (NKLogMessage.LogInstance == -1)
                NKLogMessage.LogInstance = loggerInstance;

            if (NKLogMessage.DefaultSender == -1)
                NKLogMessage.DefaultSender = *(long*)(senderInfo);

            //ModLogger.APIWriteLine($"a1: {loggerInstance}, a2: {senderAddress}, messageToLog: {messageToLog}, a4: {messageLength}, a5: {a5}");

            /*var logMessage = new NKLogMessage(messageToLog);
            logMessage.TimeSent = DateTime.Now;
            logMessage.SetSenderFromAddress(senderInfo);
            NKLogMessages.Add(logMessage);*/


            var senderStruct = senderInfo;
            var valueToLog = senderStruct->senderName;

            var stringResult = StringUtil.TryToString((long)valueToLog);
            if (!string.IsNullOrEmpty(stringResult))
            {
                ModLogger.APIWriteLine(stringResult);
                ModLogger.APIWriteLine(stringResult.Length.ToString());
                ModLogger.APIWriteLine(senderStruct->value0.ToString());
                ModLogger.APIWriteLine(senderStruct->messageLength.ToString());
                //ModLogger.APIWriteLine(StringUtil.TryToString(senderStruct->messageLength)); // idk what this value is

            }


            //var result = Hook.OriginalFunction(loggerInstance, (long)senderInfo, messageToLog, messageLength, a5);
            var result = Hook.OriginalFunction(loggerInstance, senderInfo, messageToLog, messageLength, a5);

           
            ModLogger.APIWriteLine("-----");

            return result;
        }
    }
}

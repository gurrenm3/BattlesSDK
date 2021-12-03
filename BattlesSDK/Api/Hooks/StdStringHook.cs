using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.X64;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace ModSDK.Api.Hooks
{
    public static unsafe class StdStringHook
    {
        /// <summary>
        /// The last string that was created during this hook.
        /// </summary>
        public static string LastString { get; private set; }
        static FileStream fs = new FileStream(Environment.CurrentDirectory + "\\std_string param1 and param2 PREFIX and POSTFIX - with bad jet.txt", FileMode.Append);
        static StreamWriter writer = new StreamWriter(fs);

        public static IHook<HookDelegate> Hook;
        public static IFunction<HookDelegate> Function { get; set; }

        [Function(CallingConventions.Microsoft)]
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public delegate void** HookDelegate(void* a1, char* stringPtr, long a2);

        public static void Init(IReloadedHooks hooks)
        {
            Signature stdString = new Signature("40 53 55 57 41 56 41 57 48 83 EC 20 48 8B 69 18 4D");
            Function = hooks.CreateFunction<HookDelegate>(stdString.Scan());
            Hook = Function.Hook(OnStdString).Activate();
        }

        static void** OnStdString(void* a1, char* stringPtr, long a2)
        {
            if (stringPtr != null)
            {
                LastString = StringUtil.TryToString(stringPtr);
            }
            var result = Hook.OriginalFunction(a1, stringPtr, a2);
            return result;
        }
    }
}

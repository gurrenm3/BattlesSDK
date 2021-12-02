using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.X64;
using System;
using System.IO;

namespace ModSDK.Api.Hooks
{
    public static class StdStringHook
    {
        static string lastString = "";
        static FileStream fs = new FileStream(Environment.CurrentDirectory + "\\loaded game strings - with bad jet.txt", FileMode.Append);
        static StreamWriter writer = new StreamWriter(fs);


        public static IHook<HookDelegate> Hook;
        public static IFunction<HookDelegate> Function { get; set; }

        [Function(CallingConventions.Microsoft)]
        public delegate bool HookDelegate(long a1, string stringText, long a2);        

        public static void Init(IReloadedHooks hooks)
        {
            Signature stdString = new Signature("40 53 55 57 41 56 41 57 48 83 EC 20 48 8B 69 18 4D");
            Function = hooks.CreateFunction<HookDelegate>(stdString.Scan());
            Hook = Function.Hook(OnStdString).Activate();
        }

        static bool OnStdString(long a1, string stringText, long a2)
        {
            lastString = stringText;
            var result = Hook.OriginalFunction(a1, stringText, a2);
            return result;
        }
    }
}

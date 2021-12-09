using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.X64;
using System;
using System.Runtime.InteropServices;

namespace ModSDK.Api.Hooks
{
    /// <summary>
    /// The hook for a string function that's used all the time, seemingly to create/assert strings. Useful for tracking
    /// what's happening in the game and dumping values for analysis.
    /// </summary>
    public static unsafe class StdStringAssign
    {
        /// <summary>
        /// The last string that was created during this hook.
        /// </summary>
        public static string LastString { get; private set; }

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
        /// <param name="self"></param>
        /// <param name="charArray"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [Function(CallingConventions.Microsoft)]
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public delegate StdString* HookDelegate(StdString* self, char* charArray, long count);

        /// <summary>
        /// Initialize method. Scans for the game function's signature and hooks it.
        /// </summary>
        /// <param name="hooks"></param>
        public static void Init(IReloadedHooks hooks)
        {
            // IDA Function Signagure: std::string *__fastcall std::string::assign(std::string *this, const char *const _Ptr, const unsigned __int64 _Count)
            Signature stdString = new Signature("40 53 55 57 41 56 41 57 48 83 EC 20 48 8B 69 18 4D");
            Function = hooks.CreateFunction<HookDelegate>(stdString.Scan());
            Hook = Function.Hook(CodeToExecute).Activate();
        }

        static StdString* CodeToExecute(StdString* self, char* charArray, long count)
        {
            if (charArray != null)
            {
                LastString = StringUtil.TryToString(charArray);
                if (!string.IsNullOrEmpty(LastString))
                {
                    StdString.OnStringCreated.Invoke(LastString);

                    /*if (LastString.Contains(strToChange))
                        stringPtr = (char*)LastString.Replace(strToChange, replacementString).GetAddress();*/  // try this later


                    // another way we might be able to replace the jet
                    /*if (LastString.Contains(@"./game_data/game_project/asset_bundles/tower_dart_lrg_med_sml_7d7ffb318f040d16e5896de3eec8f0aa.jet"))
                    {
                        string newPath = @"F:\Users\Mrclone2\Documents\Battles 2 Modding\tower_dart_lrg_med_sml_ef3be3b4b9a699a6a61244e4858e5119\Game version 1.0.2\tower_dart_lrg_med_sml_7d7ffb318f040d16e5896de3eec8f0aa.jet".Replace(@"\", "/");
                        charArray = (char*)newPath.GetAddress();

                        ModLogger.APIWriteLine("Found");
                    }*/
                }
            }
            var result = Hook.OriginalFunction(self, charArray, count);       
            

            return result;
        }
    }
}

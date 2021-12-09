using ModSDK.Api;
using ModSDK.Api.Hooks;
using Reloaded.Hooks.Definitions;
using System;

namespace ModSDK
{
    public class HookLoader
    {
        private static bool initialized = false;

        public static void Init(IReloadedHooks hooks)
        {
            if (initialized)
                return;

            StdStringAssign.Init(hooks);
            NKLogger_LogToFile.Init(hooks);
            Game_Initialize.Init(hooks);

            initialized = true;
        }
    }
}

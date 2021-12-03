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

            StdStringHook.Init(hooks);
            NKMessageLoggedToFile.Init(hooks);

            initialized = true;
        }
    }
}

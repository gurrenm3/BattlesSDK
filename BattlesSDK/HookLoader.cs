using ModSDK.Api;
using ModSDK.Api.Hooks;
using Reloaded.Hooks.Definitions;

namespace ModSDK
{
    internal class HookLoader
    {
        public static void Init(IReloadedHooks hooks)
        {
           StdStringHook.Init(hooks);
        }
    }
}

using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.X64;
using System.Runtime.InteropServices;

namespace ModSDK.Api.Hooks
{
    /// <summary>
    /// Hook for Game initialization. This is called in Battles 2 when the game first initializes,
    /// almost as soon as the Ninja Kiwi splash screen is shown.
    /// </summary>
    public static unsafe class Game_Initialize
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
        /// <param name="a1"></param>
        [Function(CallingConventions.Microsoft)]
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public delegate long HookDelegate(long a1);

        /// <summary>
        /// Initialize method. Scans for the game function's signature and hooks it.
        /// </summary>
        /// <param name="hooks"></param>
        public static void Init(IReloadedHooks hooks)
        {
            Signature stdString = new Signature("48 8B C4 48 89 58 10 48 89 70 18 48 89 78 20 55 41 54 41 55 41 56 41 57 48 8D A8 ? ? ? ? 48 81 EC ? ? ? ? 0F 29 70 C8 0F 29 78 B8 48 8B 05 ? ? ? ? 48 33 C4 48 89 85 ? ? ? ? 48 8B F1 45 33 F6 44 89 B5");
            Function = hooks.CreateFunction<HookDelegate>(stdString.Scan());
            Hook = Function.Hook(CodeToExecute).Activate();
        }

        
        static long CodeToExecute(long a1)
        {
            var result = Hook.OriginalFunction(a1);
            Game.OnGameStarted.Invoke(*(GameStruct*)a1);
            return result;
        }
    }
}

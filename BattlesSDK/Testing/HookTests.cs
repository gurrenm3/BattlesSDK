using ModSDK.Api;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.X64;
using Reloaded.Memory.Sources;
using System;
using System.IO;
using System.Linq.Expressions;
using System.Text;

namespace ModSDK
{
    public unsafe class HookTests
    {
        public static void Init(IReloadedHooks hooks)
        {
            /*Pattern removeHealth = new Pattern("40 53 55 56 57 48 81 EC ? ? ? ? 0F 29 B4");
            RemovePlayerHealth = hooks.CreateFunction<RemovePlayerHealthDel>(removeHealth.Scan());
            RemovePlayerHealtHook = RemovePlayerHealth.Hook(OnRemovePlayerHealth).Activate();*/

            /*Pattern somePattern = new Pattern("48 83 EC 48 48 8B 05 ? ? ? ? 48 33 C4 48 89 44 24 ? 4C 89");
            SomePattern = hooks.CreateFunction<SomPatternDel>(somePattern.Scan());
            SomePatternHook = SomePattern.Hook(OnSomePattern).Activate();*/

            /*Pattern someImportantFunc = new Pattern("48 8B C4 48 89 58 18 55 56 57 41 54 41 55 41 56 41 57 48 8D A8 ? ? ? ? 48 81 EC ? ? ? ? 0F 29 70 B8 0F 29 78 A8 44 0F 29 40 ? 44 0F 29 48 ? 44 0F 29 90 ? ? ? ? 44 0F 29 98 ? ? ? ? 48 8B 05 ? ? ? ? 48 33 C4 48 89 85 ? ? ? ? 4C 8B EA 48 89 54 24 ? 48 8B F9 45 33 FF 44 89 7C 24 ? E8 ? ? ? ? 4C 8B 87 ? ? ? ? 41 0F B6 80 ? ? ? ? 48 69 C8 ? ? ? ? 4D 8D A0 ? ? ? ? 4C 03 E1 4C 89 A5 ? ? ? ? 83 BF ? ? ? ? ? 75 07 44 89 BF ? ? ? ? 0F B6 87 ? ? ? ? F3 0F 10 35 ? ? ? ?");
            SomeImportantFunc = hooks.CreateFunction<SomeImportantFuncDel>(someImportantFunc.Scan());
            SomeImportantFuncHook = SomeImportantFunc.Hook(OnSomeImportantFunc).Activate();*/

            /*Pattern possibleAntiCheat1 = new Pattern("40 57 48 83 EC 40 48 8B 05 ? ? ? ? 48 33 C4 48 89 44 24 ? 48 8D");
            PosAntiCheatFunc = hooks.CreateFunction<PosAntiCheat1Del>(possibleAntiCheat1.Scan());
            PosAntiCheatHook = PosAntiCheatFunc.Hook(OnPosAntiCheat).Activate();*/

            

            /*Pattern possibleAntiCheat2 = new Pattern("40 55 53 56 48 8B EC 48 83 EC 50 48 8B D9 49 8B C9 E8 ? ? ? ?");
            PosAntiCheat2Func = hooks.CreateFunction<PosAntiCheat2Del>(possibleAntiCheat2.Scan());
            PosAntiCheat2Hook = PosAntiCheat2Func.Hook(OnPosAntiCheat2).Activate();*/

            /*Signature blueprintLoader = new Signature("40 55 53 56 57 41 54 41 55 41 56 41 57 48 8D AC 24 ? ? ? ? 48 81 EC ? ? ? ? 48 8B 05 ? ? ? ? 48 33 C4 48 89 85 ? ? ? ? 4D 8B F9 4C 89 4C 24 ? 4C 89 44 24 ? 4C 8B EA 48 89 4C 24 ?");
            BlueprintLoadFunc = hooks.CreateFunction<BlueprintLoadDel>(blueprintLoader.Scan());
            BlueprintLoadhHook = BlueprintLoadFunc.Hook(OnBlueprintLoad).Activate();*/


            /*Signature possibleThrowJetError = new Signature("48 8B C4 55 53 56 57 41 56 41 57 48 8D 68 C8 48 81 EC ? ? ? ? 0F 29 70 B8 0F 29 78 A8 48 8B 05 ? ? ? ? 48 33 C4 48 89 45 D0 4D 8B F1 49 8B F0 48 8B DA 48 8B F9 48 89 54 24 ? C7 44 24");
            PossibleThrowJetErrorFunc = hooks.CreateFunction<PossibleThrowJetErrorDel>(possibleThrowJetError.Scan());
            PossibleThrowJetErrorHook = PossibleThrowJetErrorFunc.Hook(PossibleThrowJetErrorLoad).Activate(); */

            /*Signature possibleLoadFile2 = new Signature("40 55 53 56 57 41 54 41 55 41 56 41 57 48 8D 6C 24 ? 48 81 EC ? ? ? ? 48 8B 05 ? ? ? ? 48 33 C4 48 89 45 0F 4D 8B F9 49 8B D8 48 8B");
            PossibleLoadFile2Func = hooks.CreateFunction<PossibleLoadFile2Del>(possibleLoadFile2.Scan());
            PossibleLoadFile2Hook = PossibleLoadFile2Func.Hook(PossibleLoadFile2Load).Activate();*/
        }



        #region Possible Throw Jet Error


        /*[Function(CallingConventions.Microsoft)]
        delegate long PossibleThrowJetErrorDel(long a1, long a2, void* a3, byte a4, int a5);
        static IHook<PossibleThrowJetErrorDel> PossibleThrowJetErrorHook;
        static IFunction<PossibleThrowJetErrorDel> PossibleThrowJetErrorFunc { get; set; }
        static long PossibleThrowJetErrorLoad(long a1, long a2, void* a3, byte a4, int a5)
        {
            //ModLogger.APIWriteLine("PossibleThrowJetErrorLoad called");
            ModLogger.APIWriteLine(lastPopupTitle);
            var result = PossibleThrowJetErrorHook.OriginalFunction(a1, a2, a3, a4, a5);
            ModLogger.APIWriteLine(a4.ToString());
            ModLogger.APIWriteLine("============================");
            return result;
        }*/

        #endregion


        #region Possible Load File 2


        [Function(CallingConventions.Microsoft)]
        delegate long PossibleLoadFile2Del(long a1, long a2, void* a3, byte a4);
        static IHook<PossibleLoadFile2Del> PossibleLoadFile2Hook;
        static IFunction<PossibleLoadFile2Del> PossibleLoadFile2Func { get; set; }
        static long PossibleLoadFile2Load(long a1, long a2, void* a3, byte a4)
        {
            //ModLogger.APIWriteLine("PossibleThrowJetErrorLoad called");
            var result = PossibleLoadFile2Hook.OriginalFunction(a1, a2, a3, a4);
            //ModLogger.APIWriteLine(lastPopupTitle);
            //ModLogger.APIWriteLine(a4.ToString());
            ModLogger.APIWriteLine("============================");
            return result;
        }

        #endregion


        #region RemoveHealth

        /*[Function(CallingConventions.Microsoft)]
        delegate long RemovePlayerHealthDel(long someAddr, long someAddr2, float value, byte someInt, byte someInt2);
        static IHook<RemovePlayerHealthDel> RemovePlayerHealtHook;
        static IFunction<RemovePlayerHealthDel> RemovePlayerHealth { get; set; }
        static long OnRemovePlayerHealth(long someAddr, long someAddr2, float value, byte someInt, byte someInt2)
        {
            //ModLogger.APIWriteLine($"SomeAddr: {someAddr}   |   SomeAddr2: {someAddr2}   |   Value: {value}   |   SomeInt: {someInt}   |   SomeInt2: {someInt2}");

            var currentValue = (float*)(someAddr2 + 52);
            var previousValue = (float*)(someAddr2 + 44);
            ModLogger.APIWriteLine((*currentValue).ToString());
            ModLogger.APIWriteLine((*previousValue).ToString());
            ModLogger.APIWriteLine("===========================================");

            var originalFunc = RemovePlayerHealtHook.OriginalFunction(someAddr, someAddr2, value, someInt, someInt2);

            var address = (long*)(someAddr2 + 52);
            var test = *((long*)(someAddr2 + 52));

            //*((float*)(someAddr2 + 52)) = 150;
            //Memory.Instance.SafeWriteRaw((IntPtr)(someAddr2 + 52), )
            return originalFunc;
        }*/

        #endregion

        #region SomePattern

        /*[Function(CallingConventions.Microsoft)]
        delegate Int64 SomPatternDel(long a1, string a2, int someAddr, long a4);
        static IHook<SomPatternDel> SomePatternHook;
        static IFunction<SomPatternDel> SomePattern { get; set; }
        static Int64 OnSomePattern(long a1, string a2, int someAddr, long a4)
        {
            //ModLogger.APIWriteLine($"a1: {a1}   |   a2: {a2}   |   someAddr: {someAddr}   |   a4: {a4}");
            if (a2 == "health" || a2 == "temp_health")
                someAddr = 150;
            return SomePatternHook.OriginalFunction(a1, a2, someAddr, a4);
        }*/

        #endregion

        #region SomeImportantFunc

        /*[Function(CallingConventions.Microsoft)]
        delegate ulong SomeImportantFuncDel(long a1, ulong a2);
        static IHook<SomeImportantFuncDel> SomeImportantFuncHook;
        static IFunction<SomeImportantFuncDel> SomeImportantFunc { get; set; }
        static ulong OnSomeImportantFunc(long a1, ulong a2)
        {
            ModLogger.APIWriteLine("");
            return SomeImportantFuncHook.OriginalFunction(a1, a2);
        }*/

        #endregion


        #region Possible AntiCheat 1

        /*[Function(CallingConventions.Microsoft)]
        delegate bool PosAntiCheat1Del(long a1, void** a2);
        static IHook<PosAntiCheat1Del> PosAntiCheatHook;
        static IFunction<PosAntiCheat1Del> PosAntiCheatFunc { get; set; }
        static bool OnPosAntiCheat(long a1, void** a2)
        {
            var result = PosAntiCheatHook.OriginalFunction(a1, a2);

            //ModLogger.APIWriteLine(result.ToString());
            
            return result;
        }*/

        #endregion

        #region Possible AntiCheat 2

        /*static bool splashScreenButtonClick = false;

        [Function(CallingConventions.Microsoft)]
        delegate void PosAntiCheat2Del(long a1, long a2, long a3, long a4);
        static IHook<PosAntiCheat2Del> PosAntiCheat2Hook;
        static IFunction<PosAntiCheat2Del> PosAntiCheat2Func { get; set; }
        static void OnPosAntiCheat2(long a1, long a2, long a3, long a4)
        {
            splashScreenButtonClick = true;
            PosAntiCheat2Hook.OriginalFunction(a1, a2, a3, a4);

            ModLogger.APIWriteLine("On Possible AntiCheat 2");
            return;
        }*/

        #endregion

        #region Bin 2.0 Check


        /*[Function(CallingConventions.Microsoft)]
        delegate long BlueprintLoadDel(long a1, UInt64* a2, long a3, long a4, uint a5, long a6, UInt64 a7, int a8, char a9, long a10, char a11);
        static IHook<BlueprintLoadDel> BlueprintLoadhHook;
        static IFunction<BlueprintLoadDel> BlueprintLoadFunc { get; set; }
        static long OnBlueprintLoad(long a1, UInt64* a2, long a3, long a4, uint a5, long a6, UInt64 a7, int a8, char a9, long a10, char a11)
        {
            ModLogger.APIWriteLine($"OnBlueprintLoad- Pre:   {a1}, ... , {a3}, {a4}, {a5}, {a6}, {a7}, {a8}, {a9}, {a10}, {a11}");
            var result = BlueprintLoadhHook.OriginalFunction(a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11);

            ModLogger.APIWriteLine($"OnBlueprintLoad- Post:   {a1}, ... , {a3}, {a4}, {a5}, {a6}, {a7}, {a8}, {a9}, {a10}, {a11}");
            ModLogger.APIWriteLine($"==================================");
            return result;
        }*/

        #endregion
    }
}

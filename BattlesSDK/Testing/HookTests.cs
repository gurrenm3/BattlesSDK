using GameOverlay.Windows;
using ModSDK.Api;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.X64;
using Reloaded.Memory.Sources;
using System;
using System.IO;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using static Reloaded.Hooks.Definitions.X64.FunctionAttribute;

namespace ModSDK
{
    public unsafe class HookTests
    {

        public static bool JetTesting;

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
            PossibleThrowJetErrorHook = PossibleThrowJetErrorFunc.Hook(PossibleThrowJetErrorLoad).Activate();*/

            /*Signature possibleGetLogFilePath = new Signature("");
            GetLogFilePathFunc = hooks.CreateFunction<PossibleGetLogFilePathDel>(possibleGetLogFilePath.Scan());
            PossibleGetLogFilePathHook = GetLogFilePathFunc.Hook(GetLogFilePathLoad).Activate();*/




            // testing jet loading

            StdString.OnStringCreated.AddListener((str) =>
            {
                if (HookTests.JetTesting)
                {
                    ModLogger.APIWriteLine("Std::String::Assign: " + str);
                }
            });

            /*Signature possibleGameInit = new Signature("48 8B C4 48 89 58 10 48 89 70 18 48 89 78 20 55 41 54 41 55 41 56 41 57 48 8D A8 ? ? ? ? 48 81 EC ? ? ? ? 0F 29 70 C8 0F 29 78 B8 48 8B 05 ? ? ? ? 48 33 C4 48 89 85 ? ? ? ? 48 8B F1 45 33 F6 44 89 B5");
            PossibleGameInitFunc = hooks.CreateFunction<PossibleGameInitDel>(possibleGameInit.Scan());
            PossibleGameInitHook = PossibleGameInitFunc.Hook(PossibleGameInitLoad).Activate();*/


            // this is good
            /*Signature possibleFileLoad1 = new Signature("48 89 5C 24 ? 55 56 57 41 54 41 55 41 56 41 57 48 83 EC 60 4D 8B F8");
            PossibleFileLoad1Func = hooks.CreateFunction<PossibleFileLoad1Del>(possibleFileLoad1.Scan());
            PossibleFileLoad1Hook = PossibleFileLoad1Func.Hook(PossibleFileLoad1Load).Activate();*/


            /*Signature possibleJetCompare1 = new Signature("40 53 55 56 57 41 54 41 55 41 56 41 57 48 83 EC 58 49");
            PossibleJetCompare1Func = hooks.CreateFunction<PossibleJetCompare1Del>(possibleJetCompare1.Scan());
            PossibleJetCompare1Hook = PossibleJetCompare1Func.Hook(PossibleJetCompare1Load).Activate();*/

            /*Signature possibleJetCompareBool = new Signature("40 53 48 83 EC 50 48 8B 05 ? ? ? ? 48 33 C4 48 89 44 24 ? 48 C7 44");
            PossibleJetCompareBoolFunc = hooks.CreateFunction<PossibleJetCompareBoolDel>(possibleJetCompareBool.Scan());
            PossibleJetCompareBoolHook = PossibleJetCompareBoolFunc.Hook(PossibleJetCompareBoolLoad).Activate();*/

            /*Signature possibleJetCompare4 = new Signature("48 89 5C 24 ? 48 89 6C 24 ? 48 89 74 24 ? 57 41 54 41 55 41 56 41 57 48 81 EC ? ? ? ? 48 8B 05 ? ? ? ? 48 33 C4 48 89 84 24 ? ? ? ? 48 8B D9 48 8D 79 48 48 89 7C 24 ? ");
            PossibleJetCompare4Func = hooks.CreateFunction<PossibleJetCompare4Del>(possibleJetCompare4.Scan());
            PossibleJetCompare4Hook = PossibleJetCompare4Func.Hook(PossibleJetCompare4Load).Activate();*/


            /*Signature possibleJetCompare5 = new Signature("40 53 55 56 57 41 56 48 83 EC 60 48 8B 05 ? ? ? ? 48 33 C4 48 89 44 24 ? 49 8B F9 49 8B F0 48 8B D9");
            PossibleJetCompare5Func = hooks.CreateFunction<PossibleJetCompare5Del>(possibleJetCompare5.Scan());
            PossibleJetCompare5Hook = PossibleJetCompare5Func.Hook(PossibleJetCompare5Load).Activate();*/


            /*Signature possibleGetCurrentFileIndex = new Signature("48 89 5C 24 ? 55 56 57 41 54 41 55 41 56 41 57 48 8D 6C 24 ? 48 81 EC ? ? ? ? 48 8B 05 ? ? ? ? 48 33 C4 48 89 45 17 49 8B D8 4C 8B E2 4C 8B F9 0F 57 C0 0F 11 45 D7 0F 11 45 E7 0F 11 45 F7 ");
            PossibleGetCurrentFileIndexFunc = hooks.CreateFunction<PossibleGetCurrentFileIndexDel>(possibleGetCurrentFileIndex.Scan());
            PossibleGetCurrentFileIndexHook = PossibleGetCurrentFileIndexFunc.Hook(PossibleGetCurrentFileIndexLoad).Activate();*/



            //this looks promising
            /*Signature possibleJetCompare6 = new Signature("48 89 5C 24 ? 48 89 6C 24 ? 48 89 74 24 ? 57 41 56 41 57 48 83 EC 40 49 8B D8");
            PossibleJetCompare6Func = hooks.CreateFunction<PossibleJetCompare6Del>(possibleJetCompare6.Scan());
            PossibleJetCompare6Hook = PossibleJetCompare6Func.Hook(PossibleJetCompare6Load).Activate();*/



            // temporarily log all strings while trying to get jet modding working




            /*Signature possibleJetCompare7 = new Signature("40 53 48 83 EC 20 48 8B D9 48 8B 09 48 85 C9 74 4D 48 8B 53 08 4C 8B C3 E8 03 EA ? ? 48 8B 0B 48 8B 53 10 48 2B D1 48 83 E2 E0 48 81 FA ? ? ? ? ");
            PossibleJetCompare7Func = hooks.CreateFunction<PossibleJetCompare7Del>(possibleJetCompare7.Scan());
            PossibleJetCompare7Hook = PossibleJetCompare7Func.Hook(PossibleJetCompare7Load).Activate();*/


            /*Signature possibleJetCompare8 = new Signature("48 83 EC 28 48 B8 ? ? ? ? ? ? ? ? 48 3B D0 77 53 48 C1 E2 05 48 81 FA ? ? ? ? 72 2E 48 8D 4A 27 48 3B CA 76 3D E8 F2 6C ? ? 48 8B C8 48 85 C0 74 11 48 83 C0 27 48 83 E0 E0 ");
            PossibleJetCompare8Func = hooks.CreateFunction<PossibleJetCompare8Del>(possibleJetCompare8.Scan());
            PossibleJetCompare8Hook = PossibleJetCompare8Func.Hook(PossibleJetCompare8Load).Activate();*/

            /*Signature possibleJetCompare9 = new Signature("40 53 55 56 57 41 54 41 56 41 57 48 83 EC 40 4D 8B E0");
            PossibleJetCompare9Func = hooks.CreateFunction<PossibleJetCompare9Del>(possibleJetCompare9.Scan());
            PossibleJetCompare9Hook = PossibleJetCompare9Func.Hook(PossibleJetCompare9Load).Activate();*/


            Signature possibleJetCompare10 = new Signature("40 55 53 56 57 41 56 48 8D 6C 24 ? 48 81 EC ? ? ? ? 48 8B 05 ? ? ? ? 48 33 C4 48 89 45 2F 49 8B D9 48 8B FA");
            PossibleJetCompare10Func = hooks.CreateFunction<PossibleJetCompare10Del>(possibleJetCompare10.Scan());
            PossibleJetCompare10Hook = PossibleJetCompare10Func.Hook(PossibleJetCompare10Load).Activate();

        }

        #region Possible Jet compare 10


        [Function(CallingConventions.Microsoft)]
        delegate ulong* PossibleJetCompare10Del(long a1, ulong* a2, uint a3, long a4);
        static IHook<PossibleJetCompare10Del> PossibleJetCompare10Hook;
        static IFunction<PossibleJetCompare10Del> PossibleJetCompare10Func { get; set; }
        static ulong* PossibleJetCompare10Load(long a1, ulong* a2, uint a3, long a4)
        {

            /*ModLogger.APIWriteLine(a3.ToString());
            //ModLogger.APIWriteLine(valueToTest.ToString());
            var valueToTest = a2;
            if (valueToTest != null)
            {
                string output = StringUtil.TryToString((IntPtr)valueToTest);
                if (!string.IsNullOrEmpty(output))
                    ModLogger.APIWriteLine(output.ToString());
            }*/

            return a2;
            //a3 = 1000;

            /*JetTesting = true;
            var result = PossibleJetCompare10Hook.OriginalFunction(a1, a2, a3, a4);
            JetTesting = false;

            ModLogger.APIWriteLine("=========================================");
            return result;*/
        }

        #endregion


        #region Possible Jet compare 9


        /*[Function(CallingConventions.Microsoft)]
        delegate void PossibleJetCompare9Del(long a1, StdString* str1, StdString* str2);
        static IHook<PossibleJetCompare9Del> PossibleJetCompare9Hook;
        static IFunction<PossibleJetCompare9Del> PossibleJetCompare9Func { get; set; }
        static void PossibleJetCompare9Load(long a1, StdString* str1, StdString* str2)
        {
            var valueToTest = (char*)str1;

            //ModLogger.APIWriteLine(valueToTest.ToString());

            if (valueToTest != null)
            {
                string output = StringUtil.TryToString((IntPtr)valueToTest);
                if (!string.IsNullOrEmpty(output))
                    ModLogger.APIWriteLine(output.ToString());
            }

            JetTesting = true;
            PossibleJetCompare9Hook.OriginalFunction(a1, str1, str2);
            JetTesting = false;

            ModLogger.APIWriteLine("=========================================");
            
        }*/

        #endregion


        #region Possible Jet compare 8

        /*[Function(CallingConventions.Microsoft)]
        delegate ulong* PossibleJetCompare8Del(long a1, long a2);
        static IHook<PossibleJetCompare8Del> PossibleJetCompare8Hook;
        static IFunction<PossibleJetCompare8Del> PossibleJetCompare8Func { get; set; }
        static ulong* PossibleJetCompare8Load(long a1, long a2)
        {
            //ModLogger.APIWriteLine("Running PossibleJetTest8");
            JetTesting = true;
            var result = PossibleJetCompare8Hook.OriginalFunction(a1, a2);
            JetTesting = false;
            //ModLogger.APIWriteLine("Finished running PossibleJetTest8");


            *//*var vector = (char*)(StdString*)result[5];
            var valueToTest = vector;

            //ModLogger.APIWriteLine(valueToTest.ToString());

            if (valueToTest != null)
            {
                string output = StringUtil.TryToString((IntPtr)valueToTest);
                if (!string.IsNullOrEmpty(output))
                    ModLogger.APIWriteLine(output.ToString());
            }*//*



            return result;
        }*/

        #endregion


        #region Possible Jet compare 7

        /*[Function(CallingConventions.Microsoft)]
        delegate long PossibleJetCompare7Del(StdStringStruct* a1);
        static IHook<PossibleJetCompare7Del> PossibleJetCompare7Hook;
        static IFunction<PossibleJetCompare7Del> PossibleJetCompare7Func { get; set; }
        static long PossibleJetCompare7Load(StdStringStruct* a1)
        {
            var valueToTest = a1->value1;
            
            //ModLogger.APIWriteLine(valueToTest.ToString());

            if (valueToTest != null)
            {
                string output = StringUtil.TryToString((IntPtr)valueToTest);
                if (!string.IsNullOrEmpty(output))
                    ModLogger.APIWriteLine(output.ToString());
            }

            var result = PossibleJetCompare7Hook.OriginalFunction(a1);

            return result;
    }*/

        #endregion


        // looks very promising
        #region Possible Jet compare 6

        [Function(CallingConventions.Microsoft)]
        delegate StdString** PossibleJetCompare6Del(StdString** a1, void** a2, void** a3);
        static IHook<PossibleJetCompare6Del> PossibleJetCompare6Hook;
        static IFunction<PossibleJetCompare6Del> PossibleJetCompare6Func { get; set; }
        static StdString** PossibleJetCompare6Load(StdString** a1, void** a2, void** a3)
        {
            var v6 = a3 - a2;

            //ModLogger.APIWriteLine(v6.ToString());

            //JetTesting = true;
            var result = PossibleJetCompare6Hook.OriginalFunction(a1, a2, a3);
            //JetTesting = false;
            
            //var valueToTest = result[2][0];
            /*if (valueToTest != null)
            {
                string output = StringUtil.TryToString((IntPtr)valueToTest);
                if (output != null)
                    ModLogger.APIWriteLine(output.ToString());
            }*/



            return result;
        }

        #endregion

        #region Possible Get current file 1

        /*[Function(CallingConventions.Microsoft)]
        delegate long PossibleGetCurrentFileIndexDel(posGetCurFileStruct1* a1, void* a2, long a3);
        static IHook<PossibleGetCurrentFileIndexDel> PossibleGetCurrentFileIndexHook;
        static IFunction<PossibleGetCurrentFileIndexDel> PossibleGetCurrentFileIndexFunc { get; set; }
        static long PossibleGetCurrentFileIndexLoad(posGetCurFileStruct1* a1, void* a2, long a3)
        {
            var result = PossibleGetCurrentFileIndexHook.OriginalFunction(a1, a2, a3);

            var v8 = a1->value6;
            var v9 = v8[1];
            var v20 = *&v9;
            var v10 = v8;

            var valueToTest = a1->indexOfCurrentFile;

            ModLogger.APIWriteLine(valueToTest.ToString());

            if (valueToTest != null)
            {
                string output = StringUtil.TryToString((IntPtr)valueToTest);
                if (output != null)
                    ModLogger.APIWriteLine(output.ToString());
            }

            return result;
        }*/

        #endregion


        /*#region Possible Jet compare 5

        [Function(CallingConventions.Microsoft)]
        delegate long PossibleJetCompare5Del(long a1, uint a2, ulong* a3, long a4);
        static IHook<PossibleJetCompare5Del> PossibleJetCompare5Hook;
        static IFunction<PossibleJetCompare5Del> PossibleJetCompare5Func { get; set; }
        static long PossibleJetCompare5Load(long a1, uint a2, ulong* a3, long a4)
        {
            var valueToTest = a1;
            ModLogger.APIWriteLine(valueToTest);

            if (valueToTest != null)
            {
                string output = StringUtil.TryToString((IntPtr)valueToTest);
                if (output != null)
                    ModLogger.APIWriteLine(output.ToString());
            }

            var result = PossibleJetCompare5Hook.OriginalFunction(a1, a2, a3, a4);

            return result;
        }

        #endregion*/


        #region Possible Jet compare 4

        /*[Function(CallingConventions.Microsoft)]
        delegate int PossibleJetCompare4Del(PosJetComp4Struct* a1);
        static IHook<PossibleJetCompare4Del> PossibleJetCompare4Hook;
        static IFunction<PossibleJetCompare4Del> PossibleJetCompare4Func { get; set; }
        static int PossibleJetCompare4Load(PosJetComp4Struct* a1)
        {
            var result = PossibleJetCompare4Hook.OriginalFunction(a1);
            ModLogger.APIWriteLine("---------------------------------------------------------------------------------");
            //var result = PossibleJetCompare4Hook.OriginalFunction(a1);
            var valueToTest = *(a1->value3) + 25;
            //ModLogger.APIWriteLine(valueToTest.ToString());

            if (valueToTest != null)
            {
                string output = StringUtil.TryToString((IntPtr)valueToTest);
                if (output != null)
                    ModLogger.APIWriteLine(output.ToString());
            }




            return result;
        }*/

        #endregion

        #region Possible Jet compare Bool

        /* [Function(CallingConventions.Microsoft)]
         delegate bool PossibleJetCompareBoolDel(long a1, long a2, bool a3);
         static IHook<PossibleJetCompareBoolDel> PossibleJetCompareBoolHook;
         static IFunction<PossibleJetCompareBoolDel> PossibleJetCompareBoolFunc { get; set; }
         static bool PossibleJetCompareBoolLoad(long a1, long a2, bool a3)
         {

             var valueToTest = a3;
             ModLogger.APIWriteLine(valueToTest.ToString());
             a3 = true;
             *//*if (valueToTest != null)
             {
                 string output = StringUtil.TryToString((IntPtr)valueToTest);
                 if (output != null)
                     ModLogger.APIWriteLine(output.ToString());
             }*//*

             var result = PossibleJetCompareBoolHook.OriginalFunction(a1, a2, a3);


             return result;
         }*/

        #endregion

        #region Possible Jet compare 1

        /*[Function(CallingConventions.Microsoft)]
        delegate JetCompareStruct1* PossibleJetCompare1Del(long a1, JetCompareStruct1* a2, void* a3, long a4);
        static IHook<PossibleJetCompare1Del> PossibleJetCompare1Hook;
        static IFunction<PossibleJetCompare1Del> PossibleJetCompare1Func { get; set; }
        static JetCompareStruct1* PossibleJetCompare1Load(long a1, JetCompareStruct1* a2, void* a3, long a4)
        {
            var result = PossibleJetCompare1Hook.OriginalFunction(a1, a2, a3, a4);
            var valueToTest = result->value1;
            ModLogger.APIWriteLine(valueToTest.ToString());

            *//*if (valueToTest != null)
            {
                string output = StringUtil.TryToString((IntPtr)valueToTest);
                if (output != null)
                    ModLogger.APIWriteLine(output.ToString());
            }*//*

            return result;
        }*/

        #endregion


        #region GetAssetPath (Looks like it gets file paths)

        /*static int count = 0;

        [Function(CallingConventions.Microsoft)]
        delegate ulong* PossibleFileLoad1Del(ulong* a1, ulong* a2, void** a3);
        static IHook<PossibleFileLoad1Del> PossibleFileLoad1Hook;
        static IFunction<PossibleFileLoad1Del> PossibleFileLoad1Func { get; set; }
        static ulong* PossibleFileLoad1Load(ulong* a1, ulong* a2, void** a3)
        {
            const string strToChange = "com.ninjakiwi.link/a7365dca90635a8ec87bd70d8c3668fc/tower_dart_lrg_med_sml_7d7ffb318f040d16e5896de3eec8f0aa.jet";
            const string replacementString = "com.ninjakiwi.link/a7365dca90635a8ec87bd70d8c3668fc/tower_dart_lrg_med_sml_9795E438CCFE155B8062B51995C7D6DA.jet";

            ModLogger.APIWriteLine(count);

            var valueToTest = a2[3];

            //var valueToTest = a1[0];
            if (valueToTest != null)
            {
                string output = StringUtil.TryToString((IntPtr)valueToTest);
                if (output != null)
                {
                    //ModLogger.APIWriteLine(output.ToString());
                    *//*if (strToChange.Trim().ToLower() == output.Trim().ToLower())
                    {
                        ModLogger.APIWriteLine(output.ToString());
                        a1[0] = (ulong)Marshal.StringToHGlobalAnsi(replacementString);
                    }*//*
                }

                if (count == 742)
                {

                }

            }

            var result = PossibleFileLoad1Hook.OriginalFunction(a1, a2, a3);
            count++;
            return result;
        }*/

        #endregion


        #region Possible Game Initializer

        [Function(CallingConventions.Microsoft)]
        delegate long PossibleGameInitDel(long a1);
        static IHook<PossibleGameInitDel> PossibleGameInitHook;
        static IFunction<PossibleGameInitDel> PossibleGameInitFunc { get; set; }
        static long PossibleGameInitLoad(long a1)
        {
            var result = PossibleGameInitHook.OriginalFunction(a1);

            ModLogger.APIWriteLine("    [ Game Initializing ]   ");
            return result;
        }

        #endregion














        #region Possible String Format

        /*[Function(CallingConventions.Microsoft)]
        delegate StringFormatStruct* StringFormatDel(StringFormatStruct* a1, char* a2, void* a3, void* a4, void* a5, void* a6);
        static IHook<StringFormatDel> StringFormatHook;
        static IFunction<StringFormatDel> StringFormatFunc { get; set; }
        static StringFormatStruct* StringFormatLoad(StringFormatStruct* a1, char* a2, void* a3, void* a4, void* a5, void* a6)
        {
           
            var valueToTest = a1->value0;
            if (valueToTest != null)
            {
                string output = StringUtil.TryToString(valueToTest);
                if (output != null)
                    ModLogger.APIWriteLine(output.ToString());
            }

            var result = StringFormatHook.OriginalFunction(a1, a2, a3, a4, a5, a6);

            ModLogger.APIWriteLine("============================");
            return result;
        }*/

        #endregion


        #region Possible Get Log File Path


        /*[Function(CallingConventions.Microsoft)]
        delegate long PossibleGetLogFilePathDel(long a1, long a2, void* a3, int a4);
        static IHook<PossibleGetLogFilePathDel> PossibleGetLogFilePathHook;
        static IFunction<PossibleGetLogFilePathDel> GetLogFilePathFunc { get; set; }
        static long GetLogFilePathLoad(long a1, long a2, void* a3, int a4)
        {
            var result = PossibleGetLogFilePathHook.OriginalFunction(a1, a2, a3, a4);
            //ModLogger.APIWriteLine(lastPopupTitle);
            //ModLogger.APIWriteLine(a4.ToString());
            //ModLogger.APIWriteLine("============================");
            return result;
        }*/

        #endregion


        #region Possible Throw Jet Error


        [Function(CallingConventions.Microsoft)]
        delegate long PossibleThrowJetErrorDel(long a1, long a2, string a3, int a4, int a5);
        static IHook<PossibleThrowJetErrorDel> PossibleThrowJetErrorHook;
        static IFunction<PossibleThrowJetErrorDel> PossibleThrowJetErrorFunc { get; set; }
        static long PossibleThrowJetErrorLoad(long a1, long a2, string a3, int a4, int a5)
        {
            //ModLogger.APIWriteLine("PossibleThrowJetErrorLoad called");
            
            var result = PossibleThrowJetErrorHook.OriginalFunction(a1, a2, a3, a4, a5);

            //var test = *(char*)a3;
            /*ModLogger.APIWriteLine(a3);
            ModLogger.APIWriteLine("============================");*/
            return result;
        }

        #endregion


        #region Possible Load File 2


        /*[Function(CallingConventions.Microsoft)]
        delegate long PossibleLoadFile2Del(long a1, long a2, void* a3, int a4);
        static IHook<PossibleLoadFile2Del> PossibleLoadFile2Hook;
        static IFunction<PossibleLoadFile2Del> PossibleLoadFile2Func { get; set; }
        static long PossibleLoadFile2Load(long a1, long a2, void* a3, int a4)
        {
            var result = PossibleLoadFile2Hook.OriginalFunction(a1, a2, a3, a4);
            //ModLogger.APIWriteLine(lastPopupTitle);
            //ModLogger.APIWriteLine(a4.ToString());
            //ModLogger.APIWriteLine("============================");
            return result;
        }*/

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

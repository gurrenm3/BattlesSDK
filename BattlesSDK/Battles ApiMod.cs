using ModSDK.Api;
using SharpDX.Text;
using System;
using System.Diagnostics;
using System.IO;

namespace ModSDK
{
    internal class Battles_ApiMod : ModBase
    {
        Input inputManager = new Input();

        public override void Start()
        {
            Logger.WriteLine("API is Initializing...");

            Input.OnKeyDown.AddListener(OnKeyDown);

            Logger.WriteLine("API finished Initializing!");
        }

        double deltaTimePassed = 0;
        Stopwatch stopwatch;
        public override void Update()
        {
            inputManager.Update();
        }

        Popup testPopup;
        private void OnKeyDown(KeyCode key)
        {
            if (key == KeyCode.Right)
            {
                //Logger.WriteLine("Test1111");
                

                //File.WriteAllText(Environment.CurrentDirectory + "\\jet messages 2.txt", HookTest.stringBuilder.ToString());
                //var bytes = Encoding.UTF8.GetBytes(HookTest.stringBuilder.ToString());
                //File.WriteAllBytes(Environment.CurrentDirectory + "\\jet messages 2.txt", bytes);
                //Logger.WriteLine(Time.DeltaTime);
            }

            if (key == KeyCode.LControl)
            {
                
            }
        }

        public override void OnGameExit()
        {
            Logger.WriteLine("===========================================", Interfaces.LogType.Error);
        }
    }
}

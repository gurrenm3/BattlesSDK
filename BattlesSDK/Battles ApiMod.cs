using ModSDK.Api;
using System.Diagnostics;

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

            if (stopwatch == null)
                stopwatch = Stopwatch.StartNew();

            if (stopwatch.ElapsedMilliseconds <= 1000)
            {
                deltaTimePassed += Time.DeltaTime;
            }
            else
            {
                Logger.WriteLine(deltaTimePassed);
            }
        }

        Popup testPopup;
        private void OnKeyDown(KeyCode key)
        {
            if (key == KeyCode.Right)
            {
                Logger.WriteLine(Time.DeltaTime);
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

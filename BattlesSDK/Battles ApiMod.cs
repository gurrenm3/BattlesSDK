using ModSDK.Api;
using ModSDK.Api.Hooks;

namespace ModSDK
{
    internal class Battles_ApiMod : ModBase
    {
        Input inputManager = new Input();

        public override void Awake()
        {
            base.Awake();
        }

        public override void Start()
        {
            base.Start();
            
            Input.OnKeyDown.AddListener(OnKeyDown);
        }

        public override void Update()
        {
            inputManager.Update();
        }

        Popup testPopup;
        private void OnKeyDown(KeyCode key)
        {
            if (key == KeyCode.Up)
            {
                NKLogger.LogToFile("Hello! I'm the message that's getting logged!", "I'm the sender of the message!");
            }

            if (key == KeyCode.Right)
            {
                foreach (var msg in NKMessageLoggedToFile.NKLogMessages)
                {
                    Logger.WriteLine("Log: " + msg);
                }
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

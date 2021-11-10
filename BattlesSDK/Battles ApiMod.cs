using BattlesSDK.Api;
using DearImguiSharp;

namespace BattlesSDK
{
    internal class Battles_ApiMod : BattlesMod
    {
        Input inputManager = new Input();

        public override void Start()
        {
            Logger.WriteLine("API is Initializing...");

            Input.OnKeyDown.AddListener(OnKeyDown);

            Logger.WriteLine("API finished Initializing!");
        }

        public override void Update()
        {
            inputManager.Update();
        }

        Popup testPopup = null;

        private void OnKeyDown(KeyCode key)
        {
            if (key == KeyCode.LControl)
            {
                Logger.WriteLine("gaz");
                if (testPopup == null)
                {
                    testPopup = new Popup();
                    testPopup.Show("");
                }
                else
                    testPopup.ShowPopup = false;
            }
        }

        public override void OnGameExit()
        {
            Logger.WriteLine("===========================================", Interfaces.LogType.Error);
        }
    }
}

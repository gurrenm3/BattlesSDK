using BattlesSDK.Api;
using LiteNetLib;
using Reloaded.Messaging;
using Reloaded.Messaging.Messages;
using Reloaded.Messaging.Structs;
using System.Net;

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

        Popup testPopup;
        private void OnKeyDown(KeyCode key)
        {
            if (key == KeyCode.Right)
            {
                
            }

            if (key == KeyCode.LControl)
            {
                Logger.WriteLine("gaz");
                if (testPopup == null)
                {
                    testPopup = new Popup();
                    testPopup.Show("");
                }
                else
                {
                    testPopup.Window.IsVisible = !testPopup.Window.IsVisible; 
                }


                var player = Game.Instance.CurrentMatch.ActualPlayer;
                player.HealthChanged.












            }
        }

        public override void OnGameExit()
        {
            Logger.WriteLine("===========================================", Interfaces.LogType.Error);
        }
    }
}

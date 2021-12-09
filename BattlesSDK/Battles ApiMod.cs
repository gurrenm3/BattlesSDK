using ModSDK.Api;
using ModSDK.Api.Hooks;
using System;
using System.Collections.Generic;
using System.IO;

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

            Game.OnGameStarted.AddListener((game) =>
            {
                Logger.WriteLine("Game was just initialized!");

                string path = @"F:\Users\Mrclone2\Documents\Battles 2 Modding\tower_dart_lrg_med_sml_ef3be3b4b9a699a6a61244e4858e5119\Game version 1.0.2\manifest.txt";
                string text = File.ReadAllText(path);

                /*Logger.WriteLine(BinEncryption.header.Length);
                var key = BinEncryption.GetKey(1234);
                List<byte> keyBytes = new List<byte>();
                key.ForEach(k => keyBytes.AddRange(BitConverter.GetBytes(k)));

                string output = "";
                for (int i = 0; i < keyBytes.Count; i++)
                {
                    output += keyBytes[i].ToString("x2");
                }

                Logger.WriteLine(output);*/


                /*var decrypt = BinEncryption.DecryptText(text);
                Logger.WriteLine(decrypt);*/
            });

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
                foreach (var msg in NKLogger.LoggedMessages)
                {
                    Logger.WriteLine("Log: " + msg);
                }
            }

            if (key == KeyCode.Left)
            {

                
                
                //Logger.WriteLine(NKLogger.LogFilePath);
            }
        }

        public override void OnGameExit()
        {
            Logger.WriteLine("===========================================", Interfaces.LogType.Error);
        }
    }
}

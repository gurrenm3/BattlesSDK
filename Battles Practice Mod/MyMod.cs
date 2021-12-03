using ModSDK;
using ModSDK.Api;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.X64;
using System;

namespace TestMod
{
    public unsafe class MyMod : ModBase
    {
        public override void Start()
        {
            Input.OnKeyHeld.AddListener(KeyHeld);
        }

        private void KeyHeld(KeyCode key)
        {
            if (key == KeyCode.Left)
            {
                Logger.WriteLine("AAAAA");
                Logger.WriteLine(ModSDK.Api.Hooks.StdStringHook.LastString);
            }
        }

        public override void Update()
        {
            
        }
    }
}
using BattlesSDK.Api;

namespace BattlesSDK
{
    internal class Battles_ApiMod : BattlesMod
    {
        Input inputManager = new Input();

        public override void Start()
        {
            Logger.WriteLine("API is Initializing...");

            Logger.WriteLine("API finished Initializing!");
        }

        public override void Update()
        {
            inputManager.Update();
        }
    }
}

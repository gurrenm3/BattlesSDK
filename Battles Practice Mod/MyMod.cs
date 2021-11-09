using BattlesSDK.Api;

namespace Battles_Practice_Mod
{
    public class MyMod : BattlesMod
    {
        public override void Start()
        {
            Logger.WriteLine($"{ModInfo.ModName} has just Started!");
        }

        public override void Update()
        {
            
        }
    }
}
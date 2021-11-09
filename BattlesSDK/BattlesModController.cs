using System.Collections.Generic;
using BattlesSDK.Api;
using BattlesSDK.Interfaces;
using Reloaded.Mod.Interfaces;
using Reloaded.Mod.Interfaces.Internal;

namespace BattlesSDK
{
    class BattlesModController : IBattlesController
    {
        public List<IBattlesMod> BattlesMods { get; set; } = new List<IBattlesMod>();

        private IModLoader modLoader;
        private ILogger logger;

        public BattlesModController(IModLoader modLoader, ILogger logger)
        {
            this.modLoader = modLoader;
            this.logger = logger;
        }

        public void RegisterBattlesMod(IBattlesMod battlesMod, IModConfigV1 modInfo)
        {
            battlesMod.ModLoader = modLoader;
            battlesMod.ModInfo = modInfo;
            battlesMod.Logger = new BattlesLogger(logger, modInfo);
            BattlesMods.Add(battlesMod);
            battlesMod.Start();
        }
    }
}

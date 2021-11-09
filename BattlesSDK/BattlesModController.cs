using System;
using System.Collections.Generic;
using System.Diagnostics;
using BattlesSDK.Api;
using BattlesSDK.Interfaces;
using Reloaded.Mod.Interfaces;
using Reloaded.Mod.Interfaces.Internal;

namespace BattlesSDK
{
    class BattlesModController : IBattlesController
    {
        public static BattlesModController instance;
        public List<IBattlesMod> BattlesMods { get; set; } = new List<IBattlesMod>();
        public Process BattlesProcess { get; set; }
        public IModLoader ModLoader { get; set; }
        public ILogger Logger { get; set; }


        public BattlesModController(IModLoader modLoader, ILogger logger)
        {
            this.ModLoader = modLoader;
            this.Logger = logger;
            instance = this;
        }

        public void RegisterBattlesMod(IBattlesMod battlesMod, IModConfigV1 modInfo)
        {
            battlesMod.ModLoader = ModLoader;
            battlesMod.ModInfo = modInfo;
            battlesMod.Logger = new BattlesLogger(Logger, modInfo);
            battlesMod.BattlesProcess = BattlesProcess;
            BattlesMods.Add(battlesMod);
            battlesMod.Start();
        }

        public void UnregisterBattlesMod(IBattlesMod battlesMod)
        {
            BattlesMods.Remove(battlesMod);
            battlesMod.OnModUnregistered();
        }

        public void RunBattlesEvent(Action<IBattlesMod> patch)
        {
            BattlesMods.ForEach(mod => patch.Invoke(mod));
        }
    }
}
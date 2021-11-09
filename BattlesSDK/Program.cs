using BattlesSDK.Api;
using BattlesSDK.Interfaces;
using Reloaded.Hooks.ReloadedII.Interfaces;
using Reloaded.Mod.Interfaces;
using Reloaded.Mod.Interfaces.Internal;
using System;

namespace BattlesSDK
{
    internal class Program : IMod, IExports
    {
        /// <summary>
        /// Your mod if from ModConfig.json, used during initialization.
        /// </summary>
        private const string ModID = "BattlesSDK";

        /// <summary>
        /// Used for writing text to the console window.
        /// </summary>
        private ILogger _logger;

        /// <summary>
        /// Provides access to the mod loader API.
        /// </summary>
        private IModLoader _modLoader;

        /// <summary>
        /// An interface to Reloaded's the function hooks/detours library.
        /// See: https://github.com/Reloaded-Project/Reloaded.Hooks
        ///      for documentation and samples. 
        /// </summary>
        private IReloadedHooks _hooks;

        /// <summary>
        /// Instance of the NMSModController
        /// </summary>
        BattlesModController _battlesModController;

        /// <summary>
        /// Instance of the API's BattlesMod
        /// </summary>
        Battles_ApiMod _apiMod;

        /// <summary>
        /// Mod Info about the API
        /// </summary>
        IModConfigV1 _apiConfig;

        /// <summary>
        /// Entry point for your mod.
        /// </summary>
        public void StartEx(IModLoaderV1 loader, IModConfigV1 config)
        {
            _modLoader = (IModLoader)loader;
            _logger = (ILogger)_modLoader.GetLogger();
            _modLoader.GetController<IReloadedHooks>().TryGetTarget(out _hooks);

            /* Your mod code starts here. */
            _apiConfig = config;
            InitAPI();
        }

        private void InitAPI()
        {
            // Set API Logger
            BattlesLogger.SetAPILogger(new BattlesLogger(_logger, _apiConfig));

            // Init ModController
            _battlesModController = new BattlesModController(_modLoader, _logger);
            RegisterAPI();
            _modLoader.AddOrReplaceController<IBattlesController>(this, _battlesModController);

            // Mod Updater
            //   TODO

            // Update Loop
            BattlesLogger.APIWriteLine("Starting Update Loop...");
            UpdateLoop update = new UpdateLoop(_battlesModController.BattlesMods);
            update.StartUpdateLoopAsync();
            BattlesLogger.APIWriteLine("Update Loop started!");
        }

        private void RegisterAPI()
        {
            _apiMod = new Battles_ApiMod();
            _battlesModController.RegisterBattlesMod(_apiMod, _apiConfig);
            _apiMod.Logger = BattlesLogger.apiLogger;
        }

        #region Reloaded2 Methods

        public void Suspend() {  }
        public void Resume() {  }
        public void Unload() {  }
        public bool CanUnload() => false;
        public bool CanSuspend() => false;
        public Action Disposing { get; }
        public Type[] GetTypes() => new Type[] { typeof(IBattlesController) };
        public static void Main() { }

        #endregion
    }
}

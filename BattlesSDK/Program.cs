using BattlesSDK.Api;
using BattlesSDK.Interfaces;
using Reloaded.Hooks.ReloadedII.Interfaces;
using Reloaded.Mod.Interfaces;
using Reloaded.Mod.Interfaces.Internal;
using System;
using System.Diagnostics;

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
        /// Instance of the BattlesModController
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
        /// The running Process for Battles
        /// </summary>
        Process _battlesProcess;

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

            // Setup IMGUI
            InitImgui();

            // Battles Process
            _battlesProcess = GetBattlesProcess();

            // Init ModController
            _battlesModController = new BattlesModController(_modLoader, _logger)
            {
                BattlesProcess = _battlesProcess
            };
            
            RegisterAPI();
            _modLoader.AddOrReplaceController<IBattlesController>(this, _battlesModController);

            // Mod Updater
            //   TODO

            
            // Update Loop
            BattlesLogger.APIWriteLine("Starting Update Loop...");
            UpdateLoop update = new UpdateLoop(_battlesModController.BattlesMods);
            update.StartUpdateLoopAsync();
            BattlesLogger.APIWriteLine("Update Loop started!");

            // OnGameExit
            RegisterOnGameExit();
        }

        private void InitImgui()
        {
            
        }

       
        private void RegisterAPI()
        {
            _apiMod = new Battles_ApiMod();
            _battlesModController.RegisterBattlesMod(_apiMod, _apiConfig);
            _apiMod.Logger = BattlesLogger.apiLogger;
        }

        private void RegisterOnGameExit()
        {
            if (_battlesProcess == null)
            {
                BattlesLogger.APIWriteLine($"Unable to register OnGameExit for mods because {nameof(_battlesProcess)} is null", LogType.Error);
                return;
            }

            _battlesProcess.Exited += BattlesProcess_Exited;
        }

        private Process GetBattlesProcess()
        {
            Process gameProc = Process.GetCurrentProcess();
            if (gameProc == null)
            {
                BattlesLogger.APIWriteLine("Failed to get the process for Battles 2. Some of the API features won't work.", LogType.Error);
                return null;
            }

            return gameProc;
        }

        private void BattlesProcess_Exited(object sender, EventArgs e)
        {
            _battlesModController.RunBattlesEvent(mod => mod.OnGameExit());
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

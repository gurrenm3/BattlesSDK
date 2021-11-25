using ModSDK.Interfaces;
using Reloaded.Hooks.ReloadedII.Interfaces;
using Reloaded.Mod.Interfaces;
using Reloaded.Mod.Interfaces.Internal;
using System;
using System.Diagnostics;

namespace ModSDK
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
        ModController _battlesModController;

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
            ModLogger.SetAPILogger(new ModLogger(_logger, _apiConfig));

            // Battles Process
            _battlesProcess = GetBattlesProcess();

            // Init ModController
            _battlesModController = new ModController(_modLoader, _logger)
            {
                GameProcess = _battlesProcess
            };
            
            RegisterAPI();
            _modLoader.AddOrReplaceController<IModController>(this, _battlesModController);

            // Mod Updater
            //   TODO


            // Update Loop
            ModLogger.APIWriteLine("Starting Update Loop...");
            UpdateLoop update = new UpdateLoop(_battlesModController.LoadedMods);
            update.StartUpdateLoopAsync();
            ModLogger.APIWriteLine("Update Loop started!");

            // OnGameExit
            RegisterOnGameExit();
        }

       
        private void RegisterAPI()
        {
            _apiMod = new Battles_ApiMod();
            _battlesModController.RegisterMod(_apiMod, _apiConfig);
            _apiMod.Logger = ModLogger.apiLogger;
        }

        private void RegisterOnGameExit()
        {
            if (_battlesProcess == null)
            {
                ModLogger.APIWriteLine($"Unable to register OnGameExit for mods because {nameof(_battlesProcess)} is null", LogType.Error);
                return;
            }

            _battlesProcess.Exited += BattlesProcess_Exited;
        }

        private Process GetBattlesProcess()
        {
            Process gameProc = Process.GetCurrentProcess();
            if (gameProc == null)
            {
                ModLogger.APIWriteLine("Failed to get the process for Battles 2. Some of the API features won't work.", LogType.Error);
                return null;
            }

            

            return gameProc;
        }

        private void BattlesProcess_Exited(object sender, EventArgs e)
        {
            _battlesModController.RunModEvent(mod => mod.OnGameExit());
        }

        #region Reloaded2 Methods

        public void Suspend() {  }
        public void Resume() {  }
        public void Unload() {  }
        public bool CanUnload() => false;
        public bool CanSuspend() => false;
        public Action Disposing { get; }
        public Type[] GetTypes() => new Type[] { typeof(IModController) };
        public static void Main() { }

        #endregion
    }
}

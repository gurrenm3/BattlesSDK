using Reloaded.Mod.Interfaces;
using Reloaded.Mod.Interfaces.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BattlesSDK.Interfaces
{
	/// <summary>
	/// Battles Mod Controller. Used to communicate between mod's and the API.
	/// </summary>
	public interface IBattlesController
	{
		/// <summary>
		/// All loaded BattlesMods.
		/// </summary>
		List<IBattlesMod> BattlesMods { get; set; }

		/// <summary>
		/// The running Process of Battles.
		/// </summary>
		Process BattlesProcess { get; set; }

		/// <summary>
		/// Instance of Reloaded ModLoader.
		/// </summary>
        IModLoader ModLoader { get; set; }

		/// <summary>
		/// Instance of Reloaded Logger.
		/// </summary>
        ILogger Logger { get; set; }

		/// <summary>
		/// Register a BattlesMod to the API. Allows access to the [Battles Events] like Start, Update, etc.
		/// </summary>
		/// <param name="battlesMod">Mod to register to the API.</param>
		/// <param name="modInfo">Info about this specific mod.</param>
		public void RegisterBattlesMod(IBattlesMod battlesMod, IModConfigV1 modInfo);

		/// <summary>
		/// Unregister a BattlesMod from the API.
		/// <br/>Doing so will also call <see cref="IBattlesMod.OnModUnregistered"/> for this mod.
		/// </summary>
		/// <param name="battlesMod">Mod to unregister from the API.</param>
		public void UnregisterBattlesMod(IBattlesMod battlesMod);

		/// <summary>
		/// Run one of the [Battles Events].
		/// <br/>Battles Events are any of the overridable methods found in <see cref="IBattlesMod"/>.
		/// </summary>
		/// <param name="patch">Battles Event to run.</param>
		public void RunBattlesEvent(Action<IBattlesMod> patch);
	}
}
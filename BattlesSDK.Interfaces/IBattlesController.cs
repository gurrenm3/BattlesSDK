using Reloaded.Mod.Interfaces.Internal;

namespace BattlesSDK.Interfaces
{
	/// <summary>
	/// Battles Mod Controller. Used to communicate between mod's and the API
	/// </summary>
	public interface IBattlesController
	{
		/// <summary>
		/// Register a Battles to the API. Allows access to methods like Start and Update
		/// </summary>
		/// <param name="battlesMod">Mod to register</param>
		/// <param name="modInfo">Info about this specific mod</param>
		public void RegisterBattlesMod(IBattlesMod battlesMod, IModConfigV1 modInfo);
	}
}
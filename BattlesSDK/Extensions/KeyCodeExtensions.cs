namespace BattlesSDK.Api
{
	/// <summary>
	/// KeyCode Extensions
	/// </summary>
	public static class KeyCodeExtensions
	{
		/// <summary>
		/// Returns true while the user holds down the key identified by the <paramref name="key"/> KeyCode enum parameter.
		/// </summary>
		/// <param name="key">The key to check for</param>
		/// <returns>If the Key is down, it will return true. Otherwise it return false</returns>
		/// <remarks>The summary for this method was taken from Unity Documentation</remarks>
		public static bool GetKey(this KeyCode key)
		{
			var state = User32.GetKeyState(key);
			bool isHeld = state < 0;
			return isHeld;
		}
    }
}
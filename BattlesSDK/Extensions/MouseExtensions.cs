namespace BattlesSDK.Api
{
	/// <summary>
	/// Mouse Extensions
	/// </summary>
	public static class MouseExtensions
	{
		/// <summary>
		/// Returns true while the user holds down the button identified by the <paramref name="mouseButton"/> KeyCode enum parameter.
		/// </summary>
		/// <param name="mouseButton">The button to check for</param>
		/// <returns></returns>
		/// <remarks>The summary for this method was taken from Unity Documentation</remarks>
		public static bool GetButton(this Mouse mouseButton)
		{
			var state = User32.GetKeyState(mouseButton);
			bool isHeld = state < 0;
			return isHeld;
		}
    }
}
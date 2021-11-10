namespace BattlesSDK.Api
{
    /// <summary>
    /// Contains information about the Computer Screen
    /// </summary>
    public static class Screen
    {
        /// <summary>
        /// Gets the Screen Dimensions of this computer
        /// </summary>
        public static Rect ScreenRect
        {
            get 
            {
                if (screenRect.Equals(Rect.Zero))
                {
                    User32.GetWindowRect(User32.GetDesktopWindow(), out screenRect);
                    screenRect.UpdateHeightAndWidth();
                }
                return screenRect; 
            }
            set { screenRect = value; }
        }
        private static Rect screenRect = Rect.Zero;


        /// <summary>
        /// Gets the position of the center of the screen
        /// </summary>
        public static Vector2 CenterScreen
        {
            get { return centerScreen.Equals(Vector2.Zero) ? centerScreen = new Vector2(ScreenRect.Width / 2, ScreenRect.Height / 2) : centerScreen; }
            set { centerScreen = value; }
        }
        private static Vector2 centerScreen = Vector2.Zero;

    }
}

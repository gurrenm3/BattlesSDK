using GameOverlay.Windows;

namespace BattlesSDK.Api
{
    /// <summary>
    /// Extension methods for <see cref="Rect"/>
    /// </summary>
    public static class RectExtensions
    {
        /// <summary>
        /// Creates a new Overlay from this Rect
        /// </summary>
        /// <param name="rect"></param>
        /// <returns></returns>
        public static OverlayWindow CreateOverlay(this Rect rect)
        {
            return new OverlayWindow(rect.Left, rect.Top, rect.Width, rect.Height)
            {
                IsTopmost = true,
                IsVisible = true
            };
        }
    }
}

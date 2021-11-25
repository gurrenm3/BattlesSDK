using GameOverlay.Drawing;
using GameOverlay.Windows;

namespace ModSDK.Api
{
    /// <summary>
    /// Extension Methods for <see cref="OverlayWindow"/>
    /// </summary>
    public static class OverlayWindowExtensions
    {
        /// <summary>
        /// Creates Graphics based on this OverlayWindow
        /// </summary>
        /// <param name="overlayWindow"></param>
        /// <returns></returns>
        public static Graphics CreateGraphics(this OverlayWindow overlayWindow)
        {
            return new Graphics(overlayWindow.Handle, overlayWindow.Width, overlayWindow.Height)
            {
                MeasureFPS = true,
                PerPrimitiveAntiAliasing = true,
                TextAntiAliasing = true,
                UseMultiThreadedFactories = false,
                VSync = true
            };
        }
    }
}

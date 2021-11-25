using ModSDK.Api.Gui;
using GameOverlay.Drawing;
using GameOverlay.Windows;

namespace ModSDK.Api
{
    /// <summary>
    /// A custom InGame popup
    /// </summary>
    public class Popup : GuiPanel
    {
        
        
        /// <summary>
        /// Default constructor for <see cref="Popup"/>
        /// </summary>
        public Popup()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="location"></param>
        public void Show(string message, ScreenLocation location = ScreenLocation.CenterScreen)
        {
            base.Show(250,250, location);
        }
    }
}

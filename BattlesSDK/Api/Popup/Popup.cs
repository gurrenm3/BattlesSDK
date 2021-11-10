using GameOverlay.Drawing;
using GameOverlay.Windows;

namespace BattlesSDK.Api
{
    /// <summary>
    /// A custom InGame popup
    /// </summary>
    public class Popup
    {
        private static IBrush popupBackground = null;

        public bool ShowPopup { get; set; } = true;
        public OverlayWindow window;
        public Graphics graphics;

        private Rect gameRect = Rect.Zero;

        /// <summary>
        /// Default constructor for <see cref="Popup"/>
        /// </summary>
        public Popup()
        {
            gameRect = Game.Instance.GetGameRect();
            window = gameRect.CreateOverlay();
            graphics = window.CreateGraphics();

            window.Create();
            graphics.WindowHandle = window.Handle;
            graphics.Setup();

            if (popupBackground == null)
            {
                Color color = new Color(40, 40, 40);
                popupBackground = graphics.CreateSolidBrush(color);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="location"></param>
        public void Show(string message, PopupLocation location = PopupLocation.CenterScreen)
        {
            graphics.BeginScene();
            graphics.ClearScene();

            //graphics.DrawCrosshair(graphics.CreateSolidBrush(Color.Blue), new Point(1920 / 2, 1080 / 2), 5, 2, CrosshairStyle.Plus);

            graphics.DrawRectangle(popupBackground, 100, 100, 100, 100, 50);
            graphics.EndScene();
        }
    }
}

using GameOverlay.Drawing;
using GameOverlay.Windows;
using System;

namespace BattlesSDK.Api.Gui
{
    /// <summary>
    /// The parent class for all Gui used in the API
    /// </summary>
    public class GuiPanel : IDisposable
    {
        /// <summary>
        /// The location the GuiPanel should be at
        /// </summary>
        public enum ScreenLocation
        {
            /// <summary>
            /// GuiPanel will show in the middle of the screen
            /// </summary>
            CenterScreen
        }

        private static IBrush popupBackground = null;

        /// <summary>
        /// The Window used to display the GuiPanel
        /// </summary>
        public OverlayWindow Window { get; private set; }

        /// <summary>
        /// The Graphics used to display the GuiPanel
        /// </summary>
        public Graphics WindowGraphics { get; private set; }

        /// <summary>
        /// Toggles whether or not this <see cref="GuiPanel"/> is shown on screen
        /// </summary>
        public bool Visibility { get => Window.IsVisible; set => Window.IsVisible = value; }


        private Rect gameRect = Rect.Zero;
        private bool disposedValue;

        /// <summary>
        /// Default constructor
        /// </summary>
        public GuiPanel()
        {
            gameRect = Game.Instance.GetGameRect();
            Window = gameRect.CreateOverlay();
            WindowGraphics = Window.CreateGraphics();

            Window.Create();
            WindowGraphics.WindowHandle = Window.Handle;
            WindowGraphics.Setup();

            if (popupBackground == null)
            {
                Color color = new Color(40, 40, 40);
                popupBackground = WindowGraphics.CreateSolidBrush(color);
            }
        }

        /// <summary>
        /// Show the GuiPanel on screen
        /// </summary>
        /// <param name="screenLocation"></param>
        public virtual void Show(int width, int height, ScreenLocation screenLocation)
        {
            WindowGraphics.BeginScene();
            WindowGraphics.ClearScene();

            //graphics.DrawCrosshair(graphics.CreateSolidBrush(Color.Blue), new Point(1920 / 2, 1080 / 2), 5, 2, CrosshairStyle.Plus);

            Rect panelRect = Rect.Zero;
            switch (screenLocation)
            {
                case ScreenLocation.CenterScreen:
                    var center = Game.Instance.GetCenterScreen();
                    int horizontalLength = width / 2;
                    int verticalLength = height / 2;
                    panelRect = new Rect(center.X - horizontalLength, center.Y + verticalLength, center.X + horizontalLength, center.Y - verticalLength);
                    break;
                default:
                    break;
            }

            WindowGraphics.DrawRectangle(popupBackground, panelRect, 50);
            WindowGraphics.EndScene();
        }

        /// <summary>
        /// Closes the GuiPanel and Releases all resources used by it
        /// </summary>
        public virtual void Close()
        {
            Dispose();
        }

        /// <summary>
        /// Releases all resources used by the GuiPanel
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    WindowGraphics.Destroy();
                    Window.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }
        
        /// <summary>
        /// Deconstructor for the GuiPanel
        /// </summary>
        ~GuiPanel()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }

        /// <summary>
        /// Releases all resources used by the GuiPanel
        /// </summary>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}

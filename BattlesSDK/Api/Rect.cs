using System;

namespace BattlesSDK.Api
{
    /// <summary>
    /// A screen Rectangle.
    /// </summary>
    public struct Rect
    {
        /// <summary>
        /// An empty rect with all values set to zero. Used for comparisson
        /// </summary>
        public static Rect Zero { get; set; } = new Rect(0, 0, 0, 0);

        /// <summary>
        /// Left coordinate.
        /// </summary>
        public int Left { get; set; }

        /// <summary>
        /// Top coordinate.
        /// </summary>
        public int Top { get; set; }

        /// <summary>
        /// Right coordinate.
        /// </summary>
        public int Right { get; set; }

        /// <summary>
        /// Bottom coordinate.
        /// </summary>
        public int Bottom { get; set; }

        /// <summary>
        /// Width of the Rectangle.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Height of the Rectangle.
        /// </summary>
        public int Height { get; set; }


        /// <summary>
        /// Create a Rect based on the sides and top.
        /// </summary>
        /// <param name="left">Left coordinate.</param>
        /// <param name="top">Top coordinate.</param>
        /// <param name="right">Right coordinate.</param>
        /// <param name="bottom">Bottom coordinate.</param>
        public Rect(int left, int top, int right, int bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;

            Width = right - left;
            Height = bottom - top;
        }

        /// <summary>
        /// Create a Rect based on the sides and top.
        /// </summary>
        /// <param name="left">Left coordinate.</param>
        /// <param name="top">Top coordinate.</param>
        /// <param name="right">Right coordinate.</param>
        /// <param name="bottom">Bottom coordinate.</param>
        /// <param name="width">Width of the whole rectangle</param>
        /// <param name="height">Height of the whole rectangle</param>
        public Rect(int left, int top, int right, int bottom, int width, int height)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;

            Width = width;
            Height = height;
        }

        /// <summary>
        /// Creates a <see cref="Rect"/> from a <see cref="System.Drawing.Rectangle"/>
        /// </summary>
        /// <param name="rectangle"></param>
        public Rect(System.Drawing.Rectangle rectangle)
        {
            Left = rectangle.Left;
            Top = rectangle.Top;
            Right = rectangle.Right;
            Bottom = rectangle.Bottom;

            Width = rectangle.Right - rectangle.Left;
            Height = rectangle.Bottom - rectangle.Top;
        }

        /// <summary>
        /// Creates a <see cref="Rect"/> from a <see cref="GameOverlay.Drawing.Rectangle"/>
        /// </summary>
        /// <param name="rectangle"></param>
        public Rect(GameOverlay.Drawing.Rectangle rectangle)
        {
            Left = (int)MathF.Round(rectangle.Left);
            Top = (int)MathF.Round(rectangle.Top);
            Right = (int)MathF.Round(rectangle.Right);
            Bottom = (int)MathF.Round(rectangle.Bottom);

            Width = (int)MathF.Round(rectangle.Right) - (int)MathF.Round(rectangle.Left);
            Height = (int)MathF.Round(rectangle.Bottom) - (int)MathF.Round(rectangle.Top);
        }

        /// <summary>
        /// Updates the Width and Height of the Rect based on the other coordinates.
        /// </summary>
        public void UpdateHeightAndWidth()
        {
            Width = Right - Left;
            Height = Bottom -Top;
        }

        /// <summary>
        /// An override of the default ToString method
        /// </summary>
        /// <returns>A string of all the properties in order.
        /// <br/>Ex: "Rect: (0, 0, 1920, 1080) | Width: 1920, Height: 1080"</returns>
        public override string ToString()
        {
            return $"Rect: ({Left}, {Top}, {Right}, {Bottom}) | Width: {Width}, Height: {Height}";
        }

        /// <summary>
        /// Creates a <see cref="Rect"/> from a <see cref="System.Drawing.Rectangle"/>
        /// </summary>
        /// <param name="rectangle"></param>
        public static implicit operator Rect(System.Drawing.Rectangle rectangle)
        {
            return new Rect(rectangle);
        }

        /// <summary>
        /// Creates a <see cref="Rect"/> from a <see cref="GameOverlay.Drawing.Rectangle"/>
        /// </summary>
        /// <param name="rectangle"></param>
        public static implicit operator Rect(GameOverlay.Drawing.Rectangle rectangle)
        {
            return new Rect(rectangle);
        }

        /// <summary>
        /// Creates a <see cref="GameOverlay.Drawing.Rectangle"/> from a <see cref="Rect"/>
        /// </summary>
        /// <param name="rect"></param>
        public static implicit operator GameOverlay.Drawing.Rectangle(Rect rect)
        {
            return new GameOverlay.Drawing.Rectangle(rect.Left, rect.Top, rect.Right, rect.Bottom);
        }

        /// <summary>
        /// Creates a <see cref="System.Drawing.Rectangle"/> from a <see cref="Rect"/>
        /// </summary>
        /// <param name="rect"></param>
        public static implicit operator System.Drawing.Rectangle(Rect rect)
        {
            return new System.Drawing.Rectangle(rect.Left, rect.Top, rect.Right, rect.Bottom);
        }
    }
}

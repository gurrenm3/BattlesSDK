using System.Drawing;

namespace BattlesSDK.Api
{
    /// <summary>
    /// Used to represent a 2D position
    /// </summary>
    public struct Vector2
    {
        /// <summary>
        /// A default vector with no values. Used for comparisson
        /// </summary>
        public static Vector2 Zero { get; set; } = new Vector2(0,0);

        /// <summary>
        /// The X coordinate of this position
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// The Y coordinate of this position
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Default constructor for <see cref="Vector2"/>
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Vector2(int x, int y)
        {
            this.X = x;
            this.Y = y;  
        }

        /// <summary>
        /// Overloaded constructor that creates a Vector2 out of a <see cref="Point"/>
        /// </summary>
        /// <param name="point"></param>
        public Vector2(Point point)
        {
            this.X = point.X;
            this.Y = point.Y;
        }

        /// <summary>
        /// An override of the default ToString method
        /// </summary>
        /// <returns>A string of all the properties in order.
        /// <br/>Ex: "(0, 10)"</returns>
        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}

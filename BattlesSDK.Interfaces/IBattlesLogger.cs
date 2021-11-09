using Reloaded.Mod.Interfaces;
using Reloaded.Mod.Interfaces.Internal;

namespace BattlesSDK.Interfaces
{
    /// <summary>
    /// A Logger that automatically adds a mod's name to each message
    /// </summary>
    public interface IBattlesLogger
    {
        /// <summary>
        /// The original Logger being used by the mod
        /// </summary>
        ILogger BaseLogger { get; }

        /// <summary>
        /// Info about the mod. Used to logging the mod's name in each message
        /// </summary>
        IModConfigV1 ModInfo { get; }

        /// <summary>
        /// Writes a message to the Console
        /// </summary>
        /// <param name="message">message to write</param>
        void Write(string message);

        /// <summary>
        /// Writes a message to the Console
        /// </summary>
        /// <param name="message">message to write</param>
        void WriteAsync(string message);

        /// <summary>
        /// Writes a new line to the Console
        /// </summary>
        /// <param name="message">message to write</param>
        void WriteLine(string message);

        /// <summary>
        /// Writes a new line to the Console
        /// </summary>
        /// <param name="message">message to write</param>
        void WriteLine(bool message);

        /// <summary>
        /// Writes a new line to the Console
        /// </summary>
        /// <param name="message">message to write</param>
        void WriteLine(int message);

        /// <summary>
        /// Writes a new line to the Console
        /// </summary>
        /// <param name="message">message to write</param>
        void WriteLine(double message);

        /// <summary>
        /// Writes a new line to the Console
        /// </summary>
        /// <param name="message">message to write</param>
        void WriteLineAsync(string message);
    }
}
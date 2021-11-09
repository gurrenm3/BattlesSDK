using Reloaded.Mod.Interfaces;
using Reloaded.Mod.Interfaces.Internal;

namespace BattlesSDK.Interfaces
{
    /// <summary>
    /// A Logger that automatically adds a mod's name to each message.
    /// </summary>
    public interface IBattlesLogger
    {
        /// <summary>
        /// The original Logger being used by the mod.
        /// </summary>
        ILogger BaseLogger { get; }

        /// <summary>
        /// Info about the mod. Used to logging the mod's name in each message.
        /// </summary>
        IModConfigV1 ModInfo { get; }

        /// <summary>
        /// Writes a message to the Console.
        /// </summary>
        /// <param name="message">Message to write.</param>
        /// <param name="logType">The LogType for this message, like whether or not this is an error.</param>
        void Write(string message, LogType logType = LogType.Normal);

        /// <summary>
        /// Writes a message to the Console.
        /// </summary>
        /// <param name="message">Message to write.</param>
        /// <param name="logType">The LogType for this message, like whether or not this is an error.</param>
        void WriteAsync(string message, LogType logType = LogType.Normal);

        /// <summary>
        /// Writes a new line to the Console.
        /// </summary>
        /// <param name="message">Message to write.</param>
        /// <param name="logType">The LogType for this message, like whether or not this is an error.</param>
        void WriteLine(string message, LogType logType = LogType.Normal);

        /// <summary>
        /// Writes a new line to the Console.
        /// </summary>
        /// <param name="message">Message to write.</param>
        /// <param name="logType">The LogType for this message, like whether or not this is an error.</param>
        void WriteLine(bool message, LogType logType = LogType.Normal);

        /// <summary>
        /// Writes a new line to the Console.
        /// </summary>
        /// <param name="message">Message to write.</param>
        /// <param name="logType">The LogType for this message, like whether or not this is an error.</param>
        void WriteLine(int message, LogType logType = LogType.Normal);

        /// <summary>
        /// Writes a new line to the Console.
        /// </summary>
        /// <param name="message">Message to write.</param>
        /// <param name="logType">The LogType for this message, like whether or not this is an error.</param>
        void WriteLine(double message, LogType logType = LogType.Normal);

        /// <summary>
        /// Writes a new line to the Console.
        /// </summary>
        /// <param name="message">Message to write.</param>
        /// <param name="logType">The LogType for this message, like whether or not this is an error.</param>
        void WriteLineAsync(string message, LogType logType = LogType.Normal);
    }
}
using System.Collections.Generic;

namespace ModSDK.Api
{
    /// <summary>
    /// The Battles 2 logger that is used by the game to log important messages to file.
    /// </summary>
    public class NKLogger
    {
        /// <summary>
        /// The filepath to the current and latest log.
        /// </summary>
        public static string LogFilePath { get; internal set; }

        /// <summary>
        /// All of the messages that have been logged to the game's log file so far.
        /// </summary>
        public static List<NKLogMessage> LoggedMessages { get; private set; } = new List<NKLogMessage>();

        /// <summary>
        /// Mod Event that is called every time a new message is logged to the log file.
        /// </summary>
        public static ModEvent<NKLogMessage> OnMessageLogged { get; set; } = new ModEvent<NKLogMessage>();

        /// <summary>
        /// Log a message to file.
        /// </summary>
        /// <param name="message">Message to log.</param>
        public static void LogToFile(string message) => new NKLogMessage(message).LogToFile();

        /// <summary>
        /// Log a message to file.
        /// </summary>
        /// <param name="message">Message to log.</param>
        public static void LogToFile(NKLogMessage message) => message.LogToFile();

        /// <summary>
        /// Log a message to file.
        /// </summary>
        /// <param name="message">Message to log.</param>
        /// <param name="filePath">A different file path to log this message to.</param>
        public static void LogToFile(NKLogMessage message, string filePath) => message.LogToFile(filePath);

        /// <summary>
        /// Log a message to file.
        /// </summary>
        /// <param name="message">Message to log.</param>
        /// <param name="sender">The sender of this message. The game uses this when logging errors, changing the sender to the path
        /// of the file that had an error.</param>
        public static void LogToFile(string message, string sender) => new NKLogMessage(message, sender).LogToFile();

        /// <summary>
        /// Log a message to file.
        /// </summary>
        /// <param name="message">Message to log.</param>
        /// <param name="sender">The sender of this message. The game uses this when logging errors, changing the sender to the path
        /// of the file that had an error.</param>
        /// <param name="filePath">A different file path to log this message to.</param>
        public static void LogToFile(string message, string sender, string filePath) => new NKLogMessage(message, sender).LogToFile(filePath);
    }
}

using BattlesSDK.Interfaces;
using Reloaded.Mod.Interfaces;
using Reloaded.Mod.Interfaces.Internal;
using System.Drawing;

namespace BattlesSDK.Api
{
    internal class BattlesLogger : IBattlesLogger
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IModConfigV1 ModInfo { get; private set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public ILogger BaseLogger { get; private set; }

        internal static IBattlesLogger apiLogger;
        public readonly Color modNameColor = Color.FromArgb(126, 244, 105);


        public BattlesLogger(ILogger baseLogger, IModConfigV1 modInfo)
        {
            BaseLogger = baseLogger;
            ModInfo = modInfo;
        }

        private void WriteModName(Color color) => BaseLogger.Write($"[{ModInfo.ModName}] ", color);

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Write(string message, LogType logType = LogType.Normal)
        {
            WriteModName(modNameColor);
            var logColor = GetLogColor(logType);
            BaseLogger.Write(message, logColor);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void WriteAsync(string message, LogType logType = LogType.Normal)
        {
            WriteModName(modNameColor);
            var logColor = GetLogColor(logType);
            BaseLogger.WriteAsync(message, logColor);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void WriteLine(bool message, LogType logType = LogType.Normal) => WriteLine(message.ToString(), logType);

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void WriteLine(int message, LogType logType = LogType.Normal) => WriteLine(message.ToString(), logType);

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void WriteLine(double message, LogType logType = LogType.Normal) => WriteLine(message.ToString(), logType);

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void WriteLine(string message, LogType logType = LogType.Normal)
        {
            WriteModName(modNameColor);
            var logColor = GetLogColor(logType);
            BaseLogger.WriteLine(message, logColor);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void WriteLineAsync(string message, LogType logType = LogType.Normal)
        {
            WriteModName(modNameColor);
            var logColor = GetLogColor(logType);
            BaseLogger.WriteLineAsync(message, logColor);
        }

        private Color GetLogColor(LogType logType)
        {
            Color logColor = BaseLogger.TextColor;
            switch (logType)
            {
                case LogType.Warning:
                    logColor = Color.Yellow;
                    break;
                case LogType.Error:
                    logColor = Color.Red;
                    break;
                default:
                    break;
            }
            return logColor;
        }

        internal static void SetAPILogger(IBattlesLogger logger) => apiLogger = logger;
        internal static void APIWrite(string message, LogType logType = LogType.Normal) => apiLogger.Write(message, logType);
        internal static void APIWriteLine(string message, LogType logType = LogType.Normal) => apiLogger.WriteLine(message, logType);
    }
}

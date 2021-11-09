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

        private void WriteModName(Color color)
        {
            BaseLogger.Write($"[{ModInfo.ModName}] ", color);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Write(string message)
        {
            WriteModName(modNameColor);
            BaseLogger.Write(message);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void WriteAsync(string message)
        {
            WriteModName(modNameColor);
            BaseLogger.WriteAsync(message);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void WriteLine(bool message) => WriteLine(message.ToString());

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void WriteLine(int message) => WriteLine(message.ToString());

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void WriteLine(double message) => WriteLine(message.ToString());

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void WriteLine(string message)
        {
            WriteModName(modNameColor);
            BaseLogger.WriteLine(message);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void WriteLineAsync(string message)
        {
            WriteModName(modNameColor);
            BaseLogger.WriteLineAsync(message);
        }

        internal static void SetAPILogger(IBattlesLogger logger) => apiLogger = logger;
        internal static void APIWrite(string message) => apiLogger.Write(message);
        internal static void APIWriteLine(string message) => apiLogger.WriteLine(message);
    }
}

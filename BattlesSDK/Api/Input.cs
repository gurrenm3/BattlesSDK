using System;
using System.Collections.Generic;
using System.Drawing;

namespace BattlesSDK.Api
{
    /// <summary>
    /// Class for managing user input, like key and mouse press
    /// </summary>
    public class Input
    {
        private static List<KeyPressInfo> allKeyInfo = new List<KeyPressInfo>();
        private static List<MousePressInfo> allMouseInfo = new List<MousePressInfo>();

        /// <summary>
        /// A BattlesEvent that is invoked whenever a keyboard key is pressed down
        /// </summary>
        public static BattlesEvent<KeyCode> OnKeyDown { get; private set; } = new BattlesEvent<KeyCode>();

        /// <summary>
        /// A BattlesEvent that is invoked whenever a keyboard key is pressed held down
        /// </summary>
        public static BattlesEvent<KeyCode> OnKeyHeld { get; private set; } = new BattlesEvent<KeyCode>();

        /// <summary>
        /// A BattlesEvent that is invoked whenever a keyboard key is released
        /// </summary>
        public static BattlesEvent<KeyCode> OnKeyUp { get; private set; } = new BattlesEvent<KeyCode>();

        /// <summary>
        /// A BattlesEvent that is invoked whenever a mouse button is pressed down
        /// </summary>
        public static BattlesEvent<Mouse> OnMouseDown { get; private set; } = new BattlesEvent<Mouse>();

        /// <summary>
        /// A BattlesEvent that is invoked whenever a mouse button is held down
        /// </summary>
        public static BattlesEvent<Mouse> OnMouseHeld { get; private set; } = new BattlesEvent<Mouse>();

        /// <summary>
        /// A BattlesEvent that is invoked whenever a mouse button is released
        /// </summary>
        public static BattlesEvent<Mouse> OnMouseUp { get; private set; } = new BattlesEvent<Mouse>();


        /// <summary>
        /// Default constructor for Input class
        /// </summary>
        public Input()
        {
            var keys = Enum.GetValues(typeof(KeyCode));
            foreach (KeyCode key in keys)
                allKeyInfo.Add(new KeyPressInfo(key));

            var buttons = Enum.GetValues(typeof(Mouse));
            foreach (Mouse button in buttons)
                allMouseInfo.Add(new MousePressInfo(button));
        }

        /// <summary>
        /// Updates the KeyPress info for keyboard buttons and mouse buttons
        /// </summary>
        internal void Update()
        {
            allKeyInfo.ForEach(key => key.UpdateKeyInfo());
            allMouseInfo.ForEach(button => button.UpdateButtonInfo());
        }

        /// <summary>
		/// Returns true while the user holds down the key identified by the <paramref name="key"/> KeyCode enum parameter.
		/// </summary>
		/// <param name="key">The key to check for</param>
		/// <returns></returns>
		/// <remarks>The summary for this method was taken from Unity Documentation</remarks>
        public static bool GetKey(KeyCode key)
        {
            return key.GetKey();
        }

        /// <summary>
		/// Returns true during the tick the user starts pressing down the key identified by the <paramref name="key"/> KeyCode enum parameter.
		/// </summary>
		/// <param name="key">The key to check for</param>
		/// <remarks>The summary for this method was taken from Unity Documentation</remarks>
        public static bool GetKeyDown(KeyCode key)
        {
            KeyPressInfo pressInfo = GetKeyInfo(key);
            return (pressInfo != null) ? pressInfo.isKeyDown : false;
        }

        /// <summary>
		/// Returns true during the tick the user releases the key identified by the <paramref name="key"/> KeyCode enum parameter.
		/// </summary>
		/// <param name="key">The key to check for</param>
		/// <remarks>The summary for this method was taken from Unity Documentation</remarks>
		public static bool GetKeyUp(KeyCode key)
        {
            KeyPressInfo pressInfo = GetKeyInfo(key);
            return (pressInfo != null) ? pressInfo.isKeyUp : false;
        }


        /// <summary>
		/// Returns true while the user holds down the Mouse Button identified by the <paramref name="mouseButton"/> Mouse enum parameter.
		/// </summary>
		/// <param name="mouseButton">The Mouse Button to check for</param>
		/// <returns></returns>
		/// <remarks>The summary for this method is based off of Unity Documentation</remarks>
        public static bool GetButton(Mouse mouseButton)
        {
            return mouseButton.GetButton();
        }

        /// <summary>
		/// Returns true during the tick the user starts pressing down the Mouse Button identified by the <paramref name="mouseButton"/> Mouse enum parameter.
		/// </summary>
		/// <param name="mouseButton">The Mouse Button to check for</param>
		/// <remarks>The summary for this method is based off of Unity Documentation</remarks>
        public static bool GetButtonDown(Mouse mouseButton)
        {
            MousePressInfo pressInfo = GetButtonInfo(mouseButton);
            return (pressInfo != null) ? pressInfo.isButtonDown : false;
        }

        /// <summary>
		/// Returns true during the tick the user releases the Mouse Button identified by the <paramref name="mouseButton"/> Mouse enum parameter.
		/// </summary>
		/// <param name="mouseButton">The Mouse Button to check for</param>
		/// <remarks>The summary for this method is based off of Unity Documentation</remarks>
		public static bool GetButtonUp(Mouse mouseButton)
        {
            MousePressInfo pressInfo = GetButtonInfo(mouseButton);
            return (pressInfo != null) ? pressInfo.isButtonUp : false;
        }

        /// <summary>
        /// Get the position of the cursor in screen coordinates
        /// </summary>
        /// <returns></returns>
        public static Vector2 GetMousePos()
        {
            User32.GetCursorPos(out Point position);
            return new Vector2(position);
        }


        private static KeyPressInfo GetKeyInfo(KeyCode key)
        {
            return allKeyInfo.Find(keyInfo => keyInfo.key == key);
        }

        private static MousePressInfo GetButtonInfo(Mouse mouseButton)
        {
            return allMouseInfo.Find(mouseInfo => mouseInfo.button == mouseButton);
        }
    }
}

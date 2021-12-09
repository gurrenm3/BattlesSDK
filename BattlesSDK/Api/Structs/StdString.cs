using ModSDK.Api;
using System;
using System.Runtime.InteropServices;

namespace ModSDK.Api
{
    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct StdString : IDisposable
    {
        /// <summary>
        /// Called whenever the game creates a string using this function.
        /// </summary>
        public static ModEvent<string> OnStringCreated { get; set; } = new ModEvent<string>();

        /// <summary>
        /// Unknown value.
        /// </summary>
        [FieldOffset(0x0)]
        public ulong* value0;

        /// <summary>
        /// Total number of characters in this string.
        /// </summary>
        [FieldOffset(0x10)]
        public ulong length;

        /// <summary>
        /// Unknown value.
        /// </summary>
        [FieldOffset(0x18)]
        public long value2;


        public static implicit operator string(StdString stdString)
        {
            return stdString.ToString();
        }

        public override string ToString()
        {
            var stdString = this;
            return StringUtil.TryToString((char*)&stdString);
        }

        public void Dispose()
        {
            var self = this;
            var address = *(long*)&self;
            Marshal.FreeHGlobal((IntPtr)address);
        }
    }
}

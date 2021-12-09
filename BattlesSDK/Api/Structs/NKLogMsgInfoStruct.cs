using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace ModSDK.Api
{
    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct NKLogMsgInfoStruct
    {
        [FieldOffset(0x0)]
        public byte value0;

        /// <summary>
        /// How many characters long the entire message is, including any additional things added by the game.
        /// </summary>
        [FieldOffset(0x8)]
        public long messageLength;

        /// <summary>
        /// The total number of characters that were written to file.
        /// </summary>
        [FieldOffset(0x10)]
        public long numCharactersWritten;


        [FieldOffset(0x18)]
        public DateTime* value3;

        /// <summary>
        /// An address that points to the string name of the sender. Use <see cref="StringUtil.TryToString(long)"/> to convert it.
        /// </summary>
        [FieldOffset(0x28)]
        public long senderName;

        /// <summary>
        /// returns whether or not the entire message was written successfully to file.
        /// </summary>
        /// <returns></returns>
        public bool WasSuccessfullyWritten()
        {
            return numCharactersWritten == messageLength;
        }
    }
}

﻿/*
* Copyright 2016 NHN Entertainment Corp.
*
* NHN Entertainment Corp. licenses this file to you under the Apache License,
* version 2.0 (the "License"); you may not use this file except in compliance
* with the License. You may obtain a copy of the License at:
*
*   http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using System;

namespace Haste.ByteBuffer
{
    public static class ByteBufferUtil
    {
        public static bool IsReveresed(Endian endian)
        {
            return (BitConverter.IsLittleEndian && endian == Endian.BigEndian) ||
                   (!BitConverter.IsLittleEndian && endian == Endian.LittleEndian);
        }

        public static void Copy(Array sourceArray, int sourceIndex, Array destinationArray, int destinationIndex, int length)
        {
            Buffer.BlockCopy(sourceArray, sourceIndex, destinationArray, destinationIndex, length);
        }

        public static short Reverse(this short original)
        {
            return (short)(((original >> 8) & 0xFF) |
                ((original & 0xFF) << 8));
        }

        public static int Reverse(this int original)
        {
            return ((Reverse((short)original) & 0xFFFF) << 16) |
                (Reverse((short)(original >> 16)) & 0xFFFF);
        }

        public static long Reverse(this long original)
        {
            return ((Reverse((int)original) & 0xFFFFFFFF) << 32) |
                (Reverse((int)(original >> 32)) & 0xFFFFFFFF);
        }

        public static float Reverse(this float original)
        {
            var bytes = BitConverter.GetBytes(original);
            Array.Reverse(bytes);
            return BitConverter.ToSingle(bytes, 0);
        }

        public static double Reverse(this double original)
        {
            var bytes = BitConverter.GetBytes(original);
            Array.Reverse(bytes);
            return BitConverter.ToDouble(bytes, 0);
        }
    }
}

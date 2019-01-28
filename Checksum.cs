using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunlUserClient
{
    //Fletcher's checksum for data comparison
    class Checksum
    {
        public Checksum()
        {

        }
        public ulong Sum64 (byte[] Input)
        {
            uint a = 0;
            ulong b = 0;
            for (int i = 0; i < Input.Length; i++)
            {
                a = (byte)((a + Input[i]) % (2^32));
                b = (byte)((b + a) % (2^32));

            }
            Console.Clear();
            return ((b << 32) | a);
        }
        public ushort Sum16 (byte[] Input)
        {
            byte a = 0;
            ushort b = 0;
            for (int i = 0; i < Input.Length; i++)
            {
                a = (byte)((a + Input[i]) % 256);
                b = (byte)((b + a) % 256);
                

            }
            Console.Clear();
            return (ushort)((b << 8) | a);
        }
        public uint Sum32(byte[] Input)
        {
            ushort a = 0;
            uint b = 0;
            for (int i = 0; i < Input.Length; i++)
            {
                a = (byte)((a + Input[i]) % (2^16));
                b = (byte)((b + a) % (2^16));

            }
            Console.Clear();
            return ((b << 16) | a);
        }
    }
}

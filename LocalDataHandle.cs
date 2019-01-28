using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunlUserClient
{
    class LocalDataHandle
    {
        private BinaryReader BinaryReader;
        private BinaryWriter BinaryWriter;

        private Checksum Checksum = new Checksum();
        private byte[] Encloser;
        private byte[] ListSeparator;
        private Stream BinStream;
        public LocalDataHandle(string DataFile, byte[] Encloser, byte[] ListSeparator)
        {
            this.BinStream = File.Open(DataFile, FileMode.Open);

            this.Encloser = Encloser;

            this.ListSeparator = ListSeparator;
        }
        public ulong[] ReadDataByHeader(string SectionHeader)
        {
            
            byte[] StreamBuffer = new byte[SectionHeader.Length];
            byte[] EncloserBuffer = new byte[Encloser.Length];
            int EncloserIndex;
            for (int i = 0; i < BinStream.Length; i++)
            {   
                //read byte[] of section header's length 
                BinStream.Read(StreamBuffer, 0, SectionHeader.Length);
                BinStream.Read(EncloserBuffer, 0, Encloser.Length);
                //check if the buffer read from the data stream contains the section header 
                if ((Checksum.Sum16(StreamBuffer) == Checksum.Sum16(Encoding.ASCII.GetBytes(SectionHeader))) && Checksum.Sum16(EncloserBuffer) == Checksum.Sum16(Encloser))
                {
                    //set an offset for the start of the data
                    int DataStartIndex = i + SectionHeader.Length + Encloser.Length;
                    
                    //locate the index of the section end encloser
                    for (int j = 0; j < BinStream.Length- DataStartIndex; j++)
                    {
                        //seek the reader using an offset from the start of the data
                        BinStream.Seek(DataStartIndex+j, SeekOrigin.Begin);
                        //read bytes of encloser's length into the encloser buffer 
                        BinStream.Read(EncloserBuffer, 0, Encloser.Length);
                        //check if the data in the encloser buffer matches the encloser
                        if (Checksum.Sum16(EncloserBuffer) == Checksum.Sum16(Encloser))
                        {
                            //mark the index of the end of the data
                            EncloserIndex = DataStartIndex + j;
                            //seek the reader to the beginning of the data
                            BinStream.Seek(DataStartIndex, SeekOrigin.Begin);
                            //resize the stream buffer to the length of the data
                            Array.Resize(ref StreamBuffer, EncloserIndex - DataStartIndex);
                            //read the data into the streambuffer
                            BinStream.Read(StreamBuffer,0, EncloserIndex - DataStartIndex);
                            //resize the stream buffer to 8 bytes as to store the data block
                            Array.Resize(ref StreamBuffer, 8);
                            return new ulong[] {(ulong) BitConverter.ToInt64(StreamBuffer, 0) };
                        }
                        
                    }
                }
                // Return the data stream offset to the beginning
                BinStream.Seek(i, SeekOrigin.Begin);
            }
            return null;
        }
        public void WriteDataByHeader(string FileHeader, Stream Data)
        {

        }
        public void CreateDataFile()
        {

        }
        public void CreateDataDirectory()
        {

        }
    }

}
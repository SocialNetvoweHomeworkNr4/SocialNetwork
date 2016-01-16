using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Helpers
{
    public static class FileHelper
    {
        public static bool SaveStreamToFile(string fileFullPath, Stream stream)
        {
            try
            {
                if (stream.Length == 0)
                {
                    return false;
                }

                using (FileStream fileStream = System.IO.File.Create(fileFullPath, (int)stream.Length))
                {
                    byte[] bytesInStream = new byte[stream.Length];
                    stream.Read(bytesInStream, 0, (int)bytesInStream.Length);

                    fileStream.Write(bytesInStream, 0, bytesInStream.Length);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHelpers;

namespace SWGAfterlifeLauncher
{
    [DelimitedRecord(",")]
    public class FileManifest
    {
        public string FileName;
        public Int64 FileSize;
        public string Md5Hash;
    }
}

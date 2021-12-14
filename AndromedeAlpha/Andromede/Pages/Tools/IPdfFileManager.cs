using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Andromede.Pages.Tools
{
    public interface IPdfFileManager
    {
        Task UploadCard(string iFileName, Stream iFileStream);
        Task DeleteCard(string iFileName);
    }
}

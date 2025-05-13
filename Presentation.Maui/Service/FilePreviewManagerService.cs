using ApplicationService;
using FileManager;
using FileManager.DAO;
using FileManager.FileOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Maui.Service
{
    internal class FilePreviewManagerService
    {
        public static List<FileIdentity> FileIdentities { get; private set; }
        public static void SetFilePreviewList(IEnumerable<FileIdentity> lfi)
            => FileIdentities = lfi.ToList();


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Maui.Service
{
    internal static class DirectoryManagerService
    {
        public static DirectoryInfo _dir { get; private set ; }
        public static void SetDirectory(string dir)
            => _dir = new DirectoryInfo(dir);
        public static bool IsValid() => _dir.Exists && _dir.GetFiles().Any();

    }
}

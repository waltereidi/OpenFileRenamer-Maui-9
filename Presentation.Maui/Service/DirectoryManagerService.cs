using CommunityToolkit.Maui.Storage;

namespace Presentation.Maui.Service
{
    internal static class DirectoryManagerService
    {
        public static DirectoryInfo _dir { get; private set ; }

        public static async Task SetDirectory()
        {
            var result = await FolderPicker.Default.PickAsync();
            if (result.IsSuccessful)
                _dir = new(result.Folder.Path);

        }

        public static bool IsValid() 
            =>_dir != null && _dir.Exists && _dir.GetFiles().Any();
        
    }
}

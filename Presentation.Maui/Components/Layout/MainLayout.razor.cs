

namespace Presentation.Maui.Components.Layout
{
    using CommunityToolkit.Maui.Storage;
    using Microsoft.AspNetCore.Components;
    using Presentation.Maui.Components.Pages;

    public partial class MainLayout
    {
        private DirectoryInfo CurrentDirectory { get; set; }
        private string ChooseDirectoryButtonText
            => CurrentDirectory != null
            ? "Change Directory"
            : "Choose Directory";

        private string CurrentDirectoryText
            => CurrentDirectory != null
            ? this.CurrentDirectory.FullName
            : "Choose a directory";

       


    }
}

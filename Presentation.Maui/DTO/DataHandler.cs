namespace Presentation.Maui.DTO
{
    public abstract class DataHandler
    {
        public DirectoryInfo Dir { get; private set; }
        public DataHandler(DirectoryInfo dir)
            => Dir = dir;

    }
}

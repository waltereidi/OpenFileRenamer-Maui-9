using Java.Net;
using System.Text.Encodings.Web;

namespace Presentation.Maui.ValueObjects
{
    public class DirectoryUri
    {
        private readonly DirectoryInfo _dir;
        private DirectoryUri(DirectoryInfo value)
        {
            _dir = value;
            EnsureIsValid();
        }
        private DirectoryUri(string value )
        {
            
            //_dir = new DirectoryInfo(urlDecoder.Decode(value));

            EnsureIsValid();
        }
        private void EnsureIsValid()
        {
            if (!_dir.Exists)
                throw new DirectoryNotFoundException(); 

        }
        public string GetUriEncodedPath()
        {
            return UrlEncoder.Default.Encode(_dir.FullName);
        }

        public static implicit operator string(DirectoryUri uri)
        {
            return uri.GetUriEncodedPath();
        }

        public static explicit operator DirectoryUri(string uri)
        {
            return new DirectoryUri(uri);
        }

    }
}

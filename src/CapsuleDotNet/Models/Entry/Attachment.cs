using System.IO;

namespace CapsuleDotNet.Models{
    public class Attachment{
        private Attachment(string token, string filename, string contentType, long size){
            this.Token = token;
            this.Filename = filename;
            this.ContentType = contentType;
            this.Size = size;
        }

        public static Attachment Create(string filePath){
            // TODO: Add file upload code
            return new Attachment("", Path.GetFileName(filePath), "application/pdf", File.ReadAllBytes(filePath).LongLength);
        }

        public long Id { get; private set; }

        internal string Token { get; private set; }

        public string Filename { get; private set; }

        public string ContentType { get; private set; }

        public long Size { get; private set; }
    }
}
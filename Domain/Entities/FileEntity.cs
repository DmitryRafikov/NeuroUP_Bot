using static System.Net.Mime.MediaTypeNames;

namespace Domain.Entities
{
    internal class FileEntity
    {
        public int Id { get; set; }

        public byte[] Data;
        public string? FileType { get; set; }
    }
}

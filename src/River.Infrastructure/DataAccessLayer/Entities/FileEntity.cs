namespace River.Infrastructure.DataAccessLayer.Entities
{
    public class FileEntity
    {
        public long Id { get; }
        public string Name { get; }
        public string Path { get; }
        public string Extension { get; }
        public int DirectoryId { get; }
        public bool Ignore { get; set; }
        public bool Inactive { get; set; }
    }
}

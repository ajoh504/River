namespace River.Infrastructure.DataAccessLayer.Entities
{
    public class FileEntity
    {
        public long Id { get; init; }
        public string? Name { get; private set; }
        public string? Path { get; set; }
        public string? Extension { get; private set; }
        public long DirectoryId { get; init; }
        public bool Ignore { get; set; }
        public bool Inactive { get; set; }
    }
}

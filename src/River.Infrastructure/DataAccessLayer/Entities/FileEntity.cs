namespace River.Infrastructure.DataAccessLayer.Entities
{
    public class FileEntity
    {
        public long Id { get; private set; }
        public string? Name { get; private set; }
        public string? Path { get; set; }
        public string? Extension { get; private set; }
        public long DirectoryId { get; private set; }
        public bool Ignore { get; set; }
        public bool Inactive { get; set; }
        public FileEntity(string path, long directoryId, bool ignore = false, bool inactive = false)
        {
            Name = System.IO.Path.GetFileNameWithoutExtension(path);
            Path = path;
            Extension = System.IO.Path.GetExtension(path);
            DirectoryId = directoryId;
            Ignore = ignore;
            Inactive = inactive;
        }
        public FileEntity(long id, string name, string path, string extension, long directoryId, bool ignore = false, bool inactive = false)
        {
            Id = id;
            Name = name;
            Path = path;
            Extension = extension;
            DirectoryId = directoryId;
            Ignore = ignore;
            Inactive = inactive;
        }
    }
}

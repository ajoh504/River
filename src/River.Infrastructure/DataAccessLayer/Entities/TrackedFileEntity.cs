namespace River.Infrastructure.DataAccessLayer.Entities
{
    public class TrackedFileEntity
    {
        public ulong Id { get; private set; }
        public string? Name { get; private set; }
        public string? Path { get; set; }
        public string? Extension { get; private set; }
        public ulong DirectoryId { get; private set; }
        public bool Inactive { get; set; }
        public TrackedFileEntity(string path, ulong directoryId, bool inactive = false)
        {
            Name = System.IO.Path.GetFileNameWithoutExtension(path);
            Path = path;
            Extension = System.IO.Path.GetExtension(path);
            DirectoryId = directoryId;
            Inactive = inactive;
        }
        public TrackedFileEntity(ulong id, string name, string path, string extension, ulong directoryId, bool inactive = false)
        {
            Id = id;
            Name = name;
            Path = path;
            Extension = extension;
            DirectoryId = directoryId;
            Inactive = inactive;
        }
    }
}

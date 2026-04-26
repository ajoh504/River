namespace River.Infrastructure.DataAccessLayer.Entities
{
    public class TrackedSoloFileEntity
    {
        public long Id { get; private set; }
        public string? Name { get; private set; }
        public string? Path { get; set; }
        public string? Extension { get; private set; }
        public bool Inactive { get; set; }
        public TrackedSoloFileEntity(string path, bool inactive = false)
        {
            Name = System.IO.Path.GetFileNameWithoutExtension(path);
            Path = path;
            Extension = System.IO.Path.GetExtension(path);
            Inactive = inactive;
        }
        public TrackedSoloFileEntity(long id, string name, string path, string extension, bool inactive = false)
        {
            Id = id;
            Name = name;
            Path = path;
            Extension = extension;
            Inactive = inactive;
        }
    }
}

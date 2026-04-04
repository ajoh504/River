using System.Collections.Generic;

namespace River.Infrastructure.DataAccessLayer.Entities
{
    public class DirectoryEntity
    {
        public long Id { get; init; }
        public string? Name { get; private set; }
        public string? Path { get; set; }
        public bool Ignore { get; set; }
        public ICollection<FileEntity> Files { get; set; } = new List<FileEntity>();
        public bool Inactive { get; set; }
    }
}

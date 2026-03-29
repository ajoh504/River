using System.Collections.Generic;

namespace River.Infrastructure.DataAccessLayer.Entities
{
    public class DirectoryEntity
    {
        public long Id { get; }
        public string Name { get; }
        public string Path { get; }
        public bool Ignore { get; set; }
        public ICollection<FileEntity> Files { get; set; } = new List<FileEntity>();
        public bool Inactive { get; set; }
    }
}

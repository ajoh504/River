using System.Collections.Generic;

namespace River.Infrastructure.DataAccessLayer.Entities
{
    public class TrackedDirectoryEntity
    {
        public ulong Id { get; init; }
        public string? Name { get; private set; }
        public string? Path { get; set; }
        public ICollection<TrackedFileEntity> Files { get; set; } = new List<TrackedFileEntity>();
        public bool Inactive { get; set; }
        public TrackedDirectoryEntity(string path, bool inactive = false)
        {
            
        }
    }
}

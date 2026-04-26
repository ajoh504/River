namespace River.Infrastructure.DataAccessLayer.Entities
{
    public class IgnoredDirectoryEntity
    {
        public long Id { get; init; }
        public string? Name { get; private set; }
        public string? Path { get; set; }
        public bool Inactive { get; set; }
    }
}

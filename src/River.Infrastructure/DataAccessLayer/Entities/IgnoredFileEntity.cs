namespace River.Infrastructure.DataAccessLayer.Entities
{
    public class IgnoredFileEntity
    {
        public ulong Id { get; init; }
        public string? Name { get; private set; }
        public string? Path { get; set; }
        public string? Extension { get; set; }
        public bool Inactive { get; set; }
    }
}

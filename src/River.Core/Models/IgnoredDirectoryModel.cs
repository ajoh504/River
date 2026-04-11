namespace River.Core.Models
{
    public record IgnoredDirectoryModel(
        ulong Id,
        string Name,
        string Path,
        bool Inactive
    );
}

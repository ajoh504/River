namespace River.Core.Models
{
    public record IgnoredDirectoryModel(
        long Id,
        string Name,
        string Path,
        bool Inactive
    );
}

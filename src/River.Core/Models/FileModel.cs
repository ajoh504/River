namespace River.Core.Models
{
    public record FileModel(
        long Id,
        string Path,
        string Name,
        string Extension,
        long DirectoryId,
        bool Ignore,
        bool Inactive
     );
}

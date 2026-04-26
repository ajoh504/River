namespace River.Core.Models
{
    public record TrackedFileModel(
        long Id,
        string Path,
        string Name,
        string Extension,
        long DirectoryId,
        bool Inactive
     );
}

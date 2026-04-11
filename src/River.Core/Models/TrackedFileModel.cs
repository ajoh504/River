namespace River.Core.Models
{
    public record TrackedFileModel(
        ulong Id,
        string Path,
        string Name,
        string Extension,
        ulong DirectoryId,
        bool Inactive
     );
}

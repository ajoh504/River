namespace River.Core.Models
{
    public record TrackedSoloFileModel(
        ulong Id,
        string Path,
        string Name,
        string Extension,
        bool Inactive
     );
}

namespace River.Core.Models
{
    public record TrackedSoloFileModel(
        long Id,
        string Path,
        string Name,
        string Extension,
        bool Inactive
     );
}

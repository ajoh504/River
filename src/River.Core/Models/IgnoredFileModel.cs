namespace River.Core.Models
{
    public record IgnoredFileModel(
        long Id,
        string Path,
        string Name,
        string Extension,
        bool Inactive
     );
}

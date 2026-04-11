namespace River.Core.Models
{
    public record IgnoredFileModel(
        ulong Id,
        string Path,
        string Name,
        string Extension,
        bool Inactive
     );
}

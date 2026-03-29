using System.Collections.Generic;

namespace River.Core.Models
{
    public record DirectoryModel(
        long Id,
        string Name,
        string Path,
        bool Ignore,
        IEnumerable<FileModel> Files,
        bool Inactive
    );
}

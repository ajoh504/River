using System.Collections.Generic;

namespace River.Core.Models
{
    public record TrackedDirectoryModel(
        long Id,
        string Name,
        string Path,
        IEnumerable<TrackedFileModel> Files,
        bool Inactive
    );
}

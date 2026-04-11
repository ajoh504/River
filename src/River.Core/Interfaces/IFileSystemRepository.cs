using River.Core.Models;
using System.Threading.Tasks;

namespace River.Core.Interfaces
{
    public interface IFileSystemRepository
    {
        public Task<TrackedDirectoryModel?> GetDirectoryByIdAsync(ulong Id);
        public Task<TrackedFileModel?> GetFileByIdAsync(ulong Id);
        public Task<int> SaveDirectoryAsync(TrackedDirectoryModel directoryModel);
        public Task<int> SaveFileAsync(TrackedFileModel fileModel, TrackedDirectoryModel directoryModel);
        public Task<int> SaveIgnoredDirectoryAsync(IgnoredDirectoryModel directory);
        public Task<int> SaveIgnoredFileAsync(IgnoredFileModel file, IgnoredDirectoryModel directory);
    }
}

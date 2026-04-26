using River.Core.Models;
using System.Threading.Tasks;

namespace River.Core.Interfaces
{
    public interface IFileSystemRepository
    {
        public Task<TrackedDirectoryModel?> GetDirectoryByIdAsync(long Id);
        public Task<TrackedDirectoryModel?> GetDirectoryByPathAsync(string path);
        public Task<TrackedFileModel?> GetFileByIdAsync(long Id);
        public Task<TrackedFileModel?> GetFileByPathAsync(string path);
        public Task<int> SaveDirectoryAsync(TrackedDirectoryModel directoryModel);
        public Task<int> SaveFileAsync(TrackedFileModel fileModel);
        public Task<int> SaveIgnoredDirectoryAsync(IgnoredDirectoryModel directory);
        public Task<int> SaveIgnoredFileAsync(IgnoredFileModel file, IgnoredDirectoryModel directory);
    }
}

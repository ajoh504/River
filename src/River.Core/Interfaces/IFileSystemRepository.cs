using River.Core.Models;
using System.Threading.Tasks;

namespace River.Core.Interfaces
{
    public interface IFileSystemRepository
    {
        public Task<DirectoryModel?> GetDirectoryByIdAsync(long Id);
        public Task<FileModel?> GetFileByIdAsync(long Id);
        public Task<int> SaveDirectoryAsync(DirectoryModel directory);
        public Task<int> SaveFileAsync(FileModel file, DirectoryModel directory);
    }
}

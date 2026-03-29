using River.Core.Models;
using System.Threading.Tasks;

namespace River.Core.Interfaces
{
    public interface IFileSystemRepository
    {
        public Task<FileModel>? GetFileByIdAsync(long Id);
        public Task<DirectoryModel>? GetDirectoryByIdAsync(long Id);
        public Task SaveDirectoryAsync(FileModel file);
        public Task SaveDirectoryAsync(DirectoryModel directory);
    }
}

using River.Core.Models;
using System.Threading.Tasks;

namespace River.Core.Interfaces
{
    public interface IFileSystemService
    {
        public Task<int> CreateFile(TrackedFileModel model);
    }
}

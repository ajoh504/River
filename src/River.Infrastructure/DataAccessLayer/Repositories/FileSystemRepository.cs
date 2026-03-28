using River.Core.Interfaces;

namespace River.Infrastructure.DataAccessLayer.Repositories
{
    internal class FileSystemRepository : IFileSystemRepository
    {
        private readonly ApplicationDbContext _context;
        public FileSystemRepository(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}

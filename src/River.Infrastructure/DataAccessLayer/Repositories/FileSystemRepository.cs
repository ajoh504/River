using Microsoft.EntityFrameworkCore;
using River.Core.Interfaces;
using River.Core.Models;
using River.Infrastructure.DataAccessLayer.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace River.Infrastructure.DataAccessLayer.Repositories
{
    internal class FileSystemRepository : IFileSystemRepository
    {
        private readonly ApplicationDbContext _context;

        public FileSystemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DirectoryModel>? GetDirectoryByIdAsync(long Id)
        {
            DirectoryEntity? entity = await _context.Directories
                .Include(d => d.Files)
                .FirstOrDefaultAsync(d => d.Id == Id);
            if (entity == null) return null;
            return new DirectoryModel(
                entity.Id,
                entity.Name,
                entity.Path,
                entity.Ignore,
                entity.Files.Select(f => new FileModel(f.Id, f.Path, f.Name, f.Extension, f.DirectoryId, f.Ignore, f.Inactive)),
                entity.Inactive
            );
        }

        public async Task<FileModel>? GetFileByIdAsync(long Id)
        {
            FileEntity? entity = await _context.Files.FirstOrDefaultAsync(f => f.Id == Id);
            if (entity == null) return null;
            return new FileModel(
                entity.Id, 
                entity.Path, 
                entity.Name, 
                entity.Extension, 
                entity.DirectoryId, 
                entity.Ignore, 
                entity.Inactive
            );
        }

        public Task SaveDirectoryAsync(FileModel file)
        {
            throw new System.NotImplementedException();
        }

        public Task SaveDirectoryAsync(DirectoryModel directory)
        {
            throw new System.NotImplementedException();
        }
    }
}

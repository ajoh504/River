using Microsoft.EntityFrameworkCore;
using River.Core.Interfaces;
using River.Core.Models;
using River.Infrastructure.DataAccessLayer.Entities;
using System;
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

        public async Task<DirectoryModel?> GetDirectoryByIdAsync(long Id)
        {
            return await _context.Directories
                    .AsNoTracking()
                    .Where(d => d.Id == Id)
                    .Select(d => new DirectoryModel(
                        d.Id,
                        d.Name,
                        d.Path,
                        d.Ignore,
                        d.Files.Select(f => new FileModel(
                            f.Id, f.Path, f.Name, f.Extension, f.DirectoryId, f.Ignore, f.Inactive
                        )),
                        d.Inactive
                    ))
                    .FirstOrDefaultAsync();
        }

        public async Task<FileModel?> GetFileByIdAsync(long Id)
        {
            return await _context.Files
                .AsNoTracking()
                .Where(f => f.Id == Id)
                .Select(f => new FileModel(
                    f.Id, 
                    f.Path, 
                    f.Name, 
                    f.Extension, 
                    f.DirectoryId, 
                    f.Ignore, 
                    f.Inactive
                ))
                .FirstOrDefaultAsync();
        }

        public Task<int> SaveDirectoryAsync(DirectoryModel directory)
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> SaveFileAsync(FileModel file, DirectoryModel directoryModel)
        {
            string? normalizedFileDir = System.IO.Path.GetDirectoryName(file.Path)?.TrimEnd(System.IO.Path.DirectorySeparatorChar, System.IO.Path.AltDirectorySeparatorChar);
            string? normalizedBaseDir = directoryModel.Path?.TrimEnd(System.IO.Path.DirectorySeparatorChar, System.IO.Path.AltDirectorySeparatorChar);

            if (!string.Equals(normalizedFileDir, normalizedBaseDir, StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("There was a file/directory mismatch during the save operation");
            }

            FileEntity entity = new FileEntity(
                file.Path,
                directoryModel.Id,
                file.Ignore,
                file.Inactive
            );

            _context.Files.Add(entity);
            return await _context.SaveChangesAsync();
        }
    }
}

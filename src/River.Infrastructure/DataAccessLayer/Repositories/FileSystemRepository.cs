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

        public async Task<TrackedDirectoryModel?> GetDirectoryByIdAsync(ulong Id)
        {
            return await _context.Directories
                    .AsNoTracking()
                    .Where(d => d.Id == Id)
                    .Select(d => new TrackedDirectoryModel(
                        d.Id,
                        d.Name,
                        d.Path,
                        d.Files.Select(f => new TrackedFileModel(
                            f.Id, f.Path, f.Name, f.Extension, f.DirectoryId, f.Inactive
                        )),
                        d.Inactive
                    ))
                    .FirstOrDefaultAsync();
        }

        public async Task<TrackedFileModel?> GetFileByIdAsync(ulong Id)
        {
            return await _context.Files
                .AsNoTracking()
                .Where(f => f.Id == Id)
                .Select(f => new TrackedFileModel(
                    f.Id, 
                    f.Path, 
                    f.Name, 
                    f.Extension, 
                    f.DirectoryId, 
                    f.Inactive
                ))
                .FirstOrDefaultAsync();
        }

        public Task<int> SaveDirectoryAsync(TrackedDirectoryModel directoryModel)
        {
            throw new NotImplementedException();
            //string? normalizedBaseDirectory = directoryModel.Path?.TrimEnd(System.IO.Path.DirectorySeparatorChar, System.IO.Path.AltDirectorySeparatorChar);
            //if (normalizedBaseDirectory == null)
            //{
            //    throw new ArgumentException("Path argument normalization returned null");
            //}

            //DirectoryEntity entity = new DirectoryEntity();
        }

        public async Task<int> SaveFileAsync(TrackedFileModel fileModel, TrackedDirectoryModel directoryModel)
        {
            string? normalizedParentDirectory = System.IO.Path.GetDirectoryName(fileModel.Path)?.TrimEnd(System.IO.Path.DirectorySeparatorChar, System.IO.Path.AltDirectorySeparatorChar);
            string? normalizedBaseDirectory = directoryModel.Path?.TrimEnd(System.IO.Path.DirectorySeparatorChar, System.IO.Path.AltDirectorySeparatorChar);
            if (normalizedBaseDirectory == null || normalizedParentDirectory == null)
            {
                throw new ArgumentException("Path argument normalization returned null");
            }
            if (!string.Equals(normalizedParentDirectory, normalizedBaseDirectory, StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("There was a file/directory mismatch during the save operation");
            }

            TrackedFileEntity entity = new TrackedFileEntity(
                fileModel.Path,
                directoryModel.Id,
                fileModel.Inactive
            );

            _context.Files.Add(entity);
            return await _context.SaveChangesAsync();
        }

        public Task<int> SaveIgnoredDirectoryAsync(IgnoredDirectoryModel directoryModel)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveIgnoredFileAsync(IgnoredFileModel fileModel, IgnoredDirectoryModel directoryModel)
        {
            throw new NotImplementedException();
        }
    }
}

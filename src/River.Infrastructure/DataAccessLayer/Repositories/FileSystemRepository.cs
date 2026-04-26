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

        public async Task<TrackedDirectoryModel?> GetDirectoryByIdAsync(long Id)
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

        public async Task<TrackedDirectoryModel?> GetDirectoryByPathAsync(string path)
        {
            return await _context.Directories
                    .AsNoTracking()
                    .Where(d => d.Path == path)
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

        public async Task<TrackedFileModel?> GetFileByIdAsync(long Id)
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

        public async Task<TrackedFileModel?> GetFileByPathAsync(string path)
        {
            return await _context.Files
                .AsNoTracking()
                .Where(f => f.Path == path)
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

        public async Task<int> SaveFileAsync(TrackedFileModel fileModel)
        {
            TrackedFileEntity entity = new TrackedFileEntity(
                fileModel.Path,
                fileModel.DirectoryId,
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

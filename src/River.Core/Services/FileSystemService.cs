using River.Core.DTOs;
using River.Core.Interfaces;
using River.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace River.Core.Services
{
    public class FileSystemService : IFileSystemService
    {
        private IFileSystemRepository _repository;
        public FileSystemService(IFileSystemRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> CreateFile(TrackedFileDto dto)
        {
            string? normalizedParentDirectory = System.IO.Path.GetDirectoryName(dto.Path)?.TrimEnd(System.IO.Path.DirectorySeparatorChar, System.IO.Path.AltDirectorySeparatorChar);
            //string? normalizedBaseDirectory = directoryModel.Path?.TrimEnd(System.IO.Path.DirectorySeparatorChar, System.IO.Path.AltDirectorySeparatorChar);
            //if (normalizedBaseDirectory == null || normalizedParentDirectory == null)
            //{
            //    throw new ArgumentException("Path argument normalization returned null");
            //}
            //if (!string.Equals(normalizedParentDirectory, normalizedBaseDirectory, StringComparison.OrdinalIgnoreCase))
            //{
            //    throw new ArgumentException("There was a file/directory mismatch during the save operation");
            //}

            return await _repository.SaveFileAsync(model);
        }
    }
}

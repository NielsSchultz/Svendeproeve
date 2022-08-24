using RegionSyd.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.Repositories.Interfaces
{
    public interface IFileTypeRepository
    {
        Task<FileType> CreateFileType(FileType newFileType);
        Task<List<FileType>> GetFileTypes();
        Task<FileType> GetFileType(int id);
        Task<FileType> UpdateFileType(FileType newFileType);
        Task<bool> DeleteFileType(int id);
    }
}

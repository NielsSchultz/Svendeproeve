using Microsoft.EntityFrameworkCore;
using RegionSyd.Repositories.Entities;
using RegionSyd.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd.Repositories
{
    public class FileTypeRepository : IFileTypeRepository
    {
        private readonly RegionSydDBContext _context;

        public FileTypeRepository(RegionSydDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<FileType> CreateFileType(FileType newFileType)
        {
            if (newFileType != null)
            {
                _context.FileTypes.Add(newFileType);
                await _context.SaveChangesAsync();
                return newFileType;
            }
            else
            {
                throw new ArgumentNullException(nameof(newFileType));
            }
        }

        public async Task<bool> DeleteFileType(int id)
        {
            var treatment = await _context.FileTypes.Where(b => b.FileTypeId == id).FirstOrDefaultAsync();
            if (treatment != null)
            {
                _context.FileTypes.Remove(treatment);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                throw new ArgumentNullException(nameof(treatment));
            }
        }

        public async Task<FileType> GetFileType(int id)
        {
            return await _context.FileTypes.FindAsync(id);
        }

        public async Task<List<FileType>> GetFileTypes()
        {
            return await _context.FileTypes.ToListAsync();
        }              

        public async Task<FileType> UpdateFileType(FileType newFileType)
        {
            if (newFileType != null)
            {
                _context.FileTypes.Update(newFileType);
                await _context.SaveChangesAsync();
                return newFileType;
            }
            else
            {
                throw new ArgumentNullException(nameof(newFileType));
            }
        }
    }
}

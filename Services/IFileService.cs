using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileAi.Models;

namespace FileAi.Services
{
    internal interface IFileService
    {
        // async; Загрузить файл.
        public Task<Models.File> UploadFileAsync(string filePath);
        public Task<List<Models.File>> GetAllFilesAsync();
        public Task<Models.File> DownloadFileByIdAsync(int id);
        public Task DeleteFileByIdAsync(int id);
        public Task RenameFileByIdAsync(int id, string newName);
    }
}

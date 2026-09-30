using FileAi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAi.Services
{
    internal interface IFileService
    {
        // async; Загрузить файл.
        public Task<Models.File> UploadFileAsync(string filePath);

        // BindingList<> Тоже самое что и List<>, но умеет уведомить UI об изменениях списка.
        public Task<BindingList<Models.File>> GetAllFilesAsync();   
        public Task DownloadFileByIdAsync(Models.File file, string destinationPath);
        public Task DeleteFileByIdAsync(int id);
        public Task RenameFileByIdAsync(int id, string newName);
    }
}

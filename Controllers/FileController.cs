using FileAi.Data;
using FileAi.Models;
using FileAi.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAi.Controllers
{
    // Загрузить, Скачать, Удалить, Переименовать, Получить все;
    public class FileController
    {
        private readonly AppDbContext context;
        private readonly FileService fileService;

        public FileController(AppDbContext context, FileService fileService)
        {
            this.context = context;
            this.fileService = fileService;
        }

        public async Task DowloadFile(int id, string destinationPath)
        {
            if (id <= 0)
                throw new ArgumentException($"[File Controller] Invalid file ID: {id}");

            var file = await context.Files.FindAsync(id);

            if (file == null)
            {
                throw new FileNotFoundException($"[File Service] File with ID {id} not found.");
            }

            await fileService.DownloadFileByIdAsync(file, destinationPath);
        }

        public async Task<Models.File> UploadFileAsync(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException($"[File Controller] Invalid file path: {filePath}");

            return await fileService.UploadFileAsync(filePath);
        }

        public async Task<BindingList<Models.File>> GetAllFilesAsync()
        {
            return await fileService.GetAllFilesAsync();
        }
    }
}

using FileAi.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
namespace FileAi.Services
{
    public class FileService : IFileService
    {
        AppDbContext context = new AppDbContext();
        private const string pathDirectory = @"Z:\Repos\FileAi\Storage\";
        private const string pathDowload = @"Загрузки";

        // Загрузить файл
        public async Task<Models.File> UploadFileAsync(string filePath)
        {

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"[File Service] File not found: {filePath}");
            }
            else
            {
                FileInfo fileInfo = new FileInfo(filePath);
                AppDbContext context = new AppDbContext();

                Models.File file = new Models.File()
                {
                    Name = fileInfo.Name,
                    UnicName = Guid.NewGuid().ToString() + fileInfo.Extension,
                    Size = fileInfo.Length,
                    Type = fileInfo.Extension,
                    UploadedAt = DateTime.Now,
                    Path = fileInfo.FullName
                };


                File.Copy(fileInfo.FullName, Path.Combine(pathDirectory, file.UnicName), true);


                context.Files.Add(file);
                await context.SaveChangesAsync();

                return file;
            }


        }

        public async Task DeleteFileByIdAsync(int id)
        {
            var file = await context.Files.FindAsync(id);

            if (file != null)
            {
                context.Files.Remove(file);
                await context.SaveChangesAsync();

                File.Delete(Path.Combine(pathDirectory, file.UnicName));
            }
            else
            {
                throw new FileNotFoundException($"[File Service] File with ID {id} not found.");
            }
        }

        public async Task DownloadFileByIdAsync(Models.File file, string destinationPath)
        {
            string filePath = Path.Combine(pathDirectory, file.UnicName);
            File.Copy(filePath, destinationPath, true);
        }

        public async Task<BindingList<Models.File>> GetAllFilesAsync()
        {
            var files = await context.Files.ToListAsync();
            return new BindingList<Models.File>(files);
        }

        public Task RenameFileByIdAsync(int id, string newName)
        {
            throw new NotImplementedException();
        }

        
    }
}

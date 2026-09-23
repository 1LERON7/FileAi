using FileAi.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace FileAi.Services
{
    internal class FileService : IFileService
    {
        private const string pathDirectory = @"Z:\Repos\FileAi\Storage\";

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


                File.Copy(fileInfo.FullName, Path.Combine(pathDirectory, file.UnicName));


                context.Files.Add(file);
                await context.SaveChangesAsync();

                return file;
            }


        }
        public Task DeleteFileByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Models.File> DownloadFileByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Models.File>> GetAllFilesAsync()
        {
            throw new NotImplementedException();
        }

        public Task RenameFileByIdAsync(int id, string newName)
        {
            throw new NotImplementedException();
        }

        
    }
}

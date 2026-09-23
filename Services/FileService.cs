using FileAi.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
namespace FileAi.Services
{
    internal class FileService : IFileService
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

        public async Task<Models.File> DownloadFileByIdAsync(int id)
        {
            //AppDbContext context = new AppDbContext();

            //if (id <= 0)
            //    throw new ArgumentException($"[File Service] Invalid file ID: {id}");

            //var file = await context.Files.FindAsync(id);

            //if (file == null)
            //{
            //    throw new FileNotFoundException($"[File Service] File with ID {id} not found.");
            //}
            //else
            //{
            //     string filePath = Path.Combine(pathDirectory, file.UnicName);
            //    File.Copy(filePath, )
            //}

            throw new NotImplementedException();

        }

        public async Task<List<Models.File>> GetAllFilesAsync()
        {
            return await context.Files.ToListAsync();
        }

        public Task RenameFileByIdAsync(int id, string newName)
        {
            throw new NotImplementedException();
        }

        
    }
}

using FileAi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAi.Controllers
{
    // Загрузить, Скачать, Удалить, Переименовать, Получить все;
    internal class FileController
    {
        const string Directory = @"Z:\Repos\FileAi\Storage";
        public void DowloadFile()
        {
            AppDbContext context = new AppDbContext();

            if (id <= 0)
                throw new ArgumentException($"[File Service] Invalid file ID: {id}");

            var file = await context.Files.FindAsync(id);
        }
    }
}

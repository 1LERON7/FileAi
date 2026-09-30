using FileAi.Services;
using FileAi.Controllers;
using FileAi.Data;
namespace FileAi
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            FileService fileService = new FileService();
            AppDbContext context = new AppDbContext();
            FileController fileController = new FileController(context, fileService);
            

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new btnUpload(fileController));
        }
    }
}
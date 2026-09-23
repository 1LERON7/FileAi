

using FileAi.Services;

namespace FileAi
{
    public partial class btnUpload : Form
    {
        public btnUpload()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            IFileService file_service = new FileService();

            // Фильтр файлов расширения
            openFileDialog.Filter = "All files (*.*)|*.*";
            // С какой папки идет старт
            openFileDialog.InitialDirectory = @"C:\";
            // Сохраняет выбранную папку после закрытия
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                await file_service.UploadFileAsync(filePath);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using SaveFileDialog dialog = new SaveFileDialog();
            IFileService file_service = new FileService();
            dialog.FileName = file.Name;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                file_service.DownloadFileByIdAsync(id);
            }
        }
    }
}

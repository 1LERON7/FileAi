
using FileAi.Controllers;
using FileAi.Services;

namespace FileAi
{
    public partial class btnUpload : Form
    {
        private readonly FileController fileController;

        public btnUpload(FileController fileController)
        {
            InitializeComponent();
            this.fileController = fileController;
        }
        //public btnUpload()
        //{
        //    InitializeComponent();
        //}

        private async void Form1_Load(object sender, EventArgs e)
        {
            ListBox1();
        }
        private async void ListBox1()
        {
            try
            {
                var files = await fileController.GetAllFilesAsync();

                // listBox1.Items.AddRange(files.ToArray());
                listBox1.DataSource = files;
                listBox1.DisplayMember = "DisplayText"; // Выведи имя объекта (свойство Name)
                listBox1.ValueMember = "Id"; // при нажатии сохрани именно этот объект (свойство Id)
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке файлов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Фильтр файлов расширения
            openFileDialog.Filter = "All files (*.*)|*.*";
            // С какой папки идет старт
            openFileDialog.InitialDirectory = @"C:\";
            // Сохраняет выбранную папку после закрытия
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                string filePath = openFileDialog.FileName;
                await fileController.UploadFileAsync(filePath);

                ListBox1();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Некорректные данные", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Файл не найден", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private async void button2_Click(object sender, EventArgs e)
        {
            // FileName - полный путь к файлу
            var file = (Models.File)listBox1.SelectedItem;

            using SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = file.UnicName; // SelectedItem - Имя выбранного файла
            dialog.FileName = file.Name; // SelectedItem - Имя выбранного файла


            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string destinationPath = dialog.FileName; // Путь куда сохраняем
                var selectedId = (int)listBox1.SelectedValue;

                try
                {
                    await fileController.DowloadFile(selectedId, destinationPath);

                    MessageBox.Show("Файл успешно загружен", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Некорректные данные", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (FileNotFoundException ex)
                {
                    MessageBox.Show(ex.Message, "Файл не найден", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (IOException ex)
                {
                    MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Непредвиденная ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                return;



        }
        private async void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private async void button2_Click_1(object sender, EventArgs e)
        {
            var selectedId = (int)listBox1.SelectedValue;

            try
            {
                await fileController.DeletedFileByIdAsync(selectedId);
                MessageBox.Show("Файл успешно удален", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ListBox1();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Некорректные данные", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Файл не найден", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Ошибка при удалении файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}

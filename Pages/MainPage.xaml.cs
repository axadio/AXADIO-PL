
using Microsoft.Maui.Controls;
using System.IO;
using System;
using System.Threading;
using AXADIO.Interpreter;
using Microsoft.Maui.Storage;
using System.Collections.ObjectModel;
using Microsoft.Maui.Devices;

namespace AXADIO.Pages
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<FileSystemInfo> FolderItems { get; set; }

        public MainPage()
        {
            InitializeComponent();
            Application.Current.UserAppTheme = AppTheme.Light;
            FolderItems = new ObservableCollection<FileSystemInfo>();
            BindingContext = this;  // Binding FolderItems to the UI
        }

        // Kodni ishga tushirish
        public async void OnCompilePressed(object sender, EventArgs e)
        {
            string compildecode = kodMaydoni.Text ?? "";
            string[] qatorlar = compildecode.Split('\n');

            var checker = new ExpectingCode();
            checker.CheckCode(qatorlar);

            myLabel.TextColor = Colors.Black;
            myLabel.Text = "Dastur ishga tushirilmoqda...";

            await Task.Delay(500); // Asenkron kutish (UI bloklanmaydi)

            if (checker.EveryThingIsClear)
            {
                InterpreterObject stringParser = new InterpreterObject();
                string natija = stringParser.Compile(qatorlar);
                myLabel.Text = natija;
                myLabel.TextColor = Colors.Black;
            }
            else
            {
                myLabel.TextColor = Colors.Red;
                myLabel.Text = "Xatoliklar:\n" + string.Join("\n", checker.Errors);
            }
        }


        // Fayl yoki papka ochish
        public async void OnOpenFilePressed(object sender, EventArgs e)
        {
            // Faylni yoki papkani tanlash
            var filePicker = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Fayl yoki Papkani tanlang",
                FileTypes = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>()
                {
                    { DevicePlatform.iOS, new[] { "*.axa" } },
                    { DevicePlatform.Android, new[] { "*.axa" } },
                    { DevicePlatform.WinUI, new[] { "*.axa" } }
                })
            });

            if (filePicker?.FullPath != null)  // Null check
            {
                string selectedPath = filePicker.FullPath;

                if (Directory.Exists(selectedPath)) // Agar papka bo'lsa
                {
                    // Papka ichidagi fayllar va papkalarni olish
                    string[] directories = Directory.GetDirectories(selectedPath);
                    string[] files = Directory.GetFiles(selectedPath);

                    FolderItems.Clear();  // Yangi papka elementlarini tozalash
                    foreach (var dir in directories)
                    {
                        FolderItems.Add(new DirectoryInfo(dir));  // Papkalar
                    }
                    foreach (var file in files)
                    {
                        FolderItems.Add(new FileInfo(file));  // Fayllar
                    }
                }
                else
                {
                    // Fayl ochish jarayoni
                    string fileContent = await File.ReadAllTextAsync(selectedPath);
                    kodMaydoni.Text = fileContent;
                }
            }
            else
            {
                await DisplayAlert("Xato", "Fayl tanlanmadi", "OK");
            }
        }

        // Faylni saqlash
        public async void OnSaveToFilePressed(object sender, EventArgs e)
        {
            string codeToSave = kodMaydoni.Text;

            if (string.IsNullOrEmpty(codeToSave))
            {
                await DisplayAlert("Xato", "Saqlash uchun kod mavjud emas.", "OK");
                return;
            }

            // Foydalanuvchidan fayl nomini olish
            string fileName = await DisplayPromptAsync("Fayl nomini kiriting", "Saqlash uchun fayl nomini kiriting:", "OK", "Cancel");

            if (string.IsNullOrEmpty(fileName))
            {
                await DisplayAlert("Xato", "Fayl nomi kiritilmadi.", "OK");
                return;
            }

            // Faylni platformaga mos saqlash
            string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "axadiofiles");

            // Agar papka mavjud bo‘lmasa, yaratamiz
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Faylni yaratish va kodni yozish
            string filePath = Path.Combine(folderPath, $"{fileName}.axa");

            await File.WriteAllTextAsync(filePath, codeToSave);

            // Saqlash haqida xabar
            await DisplayAlert("Saqlash muvaffaqiyatli", $"Kod {filePath} manzili bilan saqlandi.", "OK");
        }
    }
}

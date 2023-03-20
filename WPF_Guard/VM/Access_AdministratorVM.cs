using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WPF_Guard.DB;
using WPF_Guard.Model;
using WPF_Guard.Tools;

namespace WPF_Guard.VM
{
    public class Access_AdministratorVM : BaseVM
    {
        private Position selectPosition;
        private ComboBoxItem selectSex;
        public CustomCommand Save { get; set; }
        public CustomCommand Cancel { get; set; }
        public CustomCommand LoadImages { get; set; }
        public CustomCommand Logout { get; set; }
        public ComboBoxItem SelectSex 
        {
            get => selectSex;
            set
            {
                selectSex = value;
                Signal();
            }
        }
        public string FIO { get; set; }
        public UserWorker UserWorker { get; set; } = new();
        public List<Position> Positions { get; set; }
        public BitmapImage BitmapImage { get; set; }

        public Position SelectPosition
        {
            get => selectPosition;
            set
            {
                selectPosition = value;
                Signal();
            }
        }

        public Access_AdministratorVM(UserWorker userWorker1, System.Windows.Window window)
        {
            FIO = userWorker1.Fio;
            Positions = DBInstance.GetInstance().Positions.ToList();

            UserWorker.Image = File.ReadAllBytes("User.png");

            Save = new CustomCommand(() =>
            {
               if(string.IsNullOrEmpty(UserWorker.Fio) || SelectSex == null || SelectPosition == null)
                {
                    MessageBox.Show("Не все поля заполнены");
                    return;
                }
                UserWorker.IdPosition = SelectPosition.Id;
                UserWorker.Sex = SelectSex.Content.ToString(); 
                DBInstance.GetInstance().UserWorkers.Add(UserWorker);
                DBInstance.GetInstance().SaveChanges();
                MessageBox.Show("Сохранение прошло успешно");
                Cancel.Execute(null);
            });

            Cancel = new CustomCommand(() => 
            {
                UserWorker = new();
                SelectPosition = null;
                SelectSex = null;
                UserWorker.Image = File.ReadAllBytes("User.png");
                Signal(nameof(UserWorker));
                Signal(nameof(SelectPosition));
                Signal(nameof(SelectSex));
                return;
            });

            LoadImages = new CustomCommand(() =>
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if(openFileDialog.ShowDialog() == true)
                {
                    UserWorker.Image = File.ReadAllBytes(openFileDialog.FileName);
                    Signal(nameof(UserWorker));
                }
            });
            Logout = new CustomCommand(() =>
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                window.Close();
            });
        }
    }
}

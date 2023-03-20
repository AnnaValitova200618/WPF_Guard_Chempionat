using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WPF_Guard.Model;
using WPF_Guard.Tools;
using WPF_Guard.Views;

namespace WPF_Guard.VM
{
    public class SecurityVM : BaseVM
    {
        public CustomCommand OpenVertification { get; set; }
        public CustomCommand OpenMandat { get; set; }
        public CustomCommand Exit { get; set; }
        private Page currentPage;

        public Page CurrentPage 
        {
            get => currentPage;
            set
            {
                currentPage = value;
                Signal();
            }
        }
        public string FIO { get; set; }
        public SecurityVM(UserWorker userWorker1, System.Windows.Window window)
        {
            FIO = userWorker1.Fio;

            CurrentPage = new VertificationPage();

            OpenVertification = new CustomCommand(() =>
            {
                CurrentPage = new VertificationPage();
            });
            OpenMandat = new CustomCommand(() =>
            {
                CurrentPage = new MandatPage();
            });
            Exit = new CustomCommand(() =>
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                window.Close();
            });
        }
    }
}

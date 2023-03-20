using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF_Guard.VM;

namespace WPF_Guard.Views
{
    /// <summary>
    /// Логика взаимодействия для Access_Administrator_Window.xaml
    /// </summary>
    public partial class Access_Administrator_Window : Window
    {
        public Access_Administrator_Window(Model.UserWorker userWorker1)
        {
            InitializeComponent();
            DataContext = new Access_AdministratorVM(userWorker1, window);
        }
    }
}

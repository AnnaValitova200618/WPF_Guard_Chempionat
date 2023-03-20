using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_Guard.DB;
using WPF_Guard.Model;
using WPF_Guard.Tools;
using WPF_Guard.Views;

namespace WPF_Guard.VM
{
    public class MainVM : BaseVM
    {
        private Model.Type selectedType;
        private UserWorker userWorker = new UserWorker();

        public CustomCommand Login { get; set; }
        public List<Model.Type> Types { get; set; }
        public Model.Type SelectedType
        {
            get => selectedType;
            set
            {
                selectedType = value;
                Signal();
            }
        }
        public UserWorker UserWorker { get => userWorker; set => userWorker = value; }

        public MainVM(Window window)
        {
            Types = DBInstance.GetInstance().Types.ToList();
            SelectedType = Types.First();

            Login = new CustomCommand(() =>
            {
                try
                {
                    var userWorker1 = DBInstance.GetInstance().UserWorkers.FirstOrDefault(s =>
                                s.Login == UserWorker.Login &&
                                s.Password == UserWorker.Password &&
                                s.Word == UserWorker.Word &&
                                s.IdType == SelectedType.Id);

                    if (userWorker1 == null)
                    {
                        MessageBox.Show("Сотрудник не найден");
                        return;
                    }

                    switch (userWorker1.IdType)
                    {
                        case 1:
                            Access_Administrator_Window window1 = new Access_Administrator_Window(userWorker1);
                            window1.Show();
                            window.Close();
                            break;
                        case 2:
                            Security window2 = new Security(userWorker1);
                            window2.Show();
                            window.Close();
                            break;
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Проблемы с БД");
                    return;
                }

                

            });
        }
    }
}

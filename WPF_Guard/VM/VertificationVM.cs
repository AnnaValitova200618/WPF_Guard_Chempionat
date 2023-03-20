using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using WPF_Guard.DB;
using WPF_Guard.Model;
using WPF_Guard.Tools;

namespace WPF_Guard.VM
{
    public class VertificationVM : BaseVM
    {
        private Model.Type selectType;

        public List<UserWorker> UserWorkers { get; set; }
        public List<Model.Type> Types { get; set; }
        public CustomCommand ApprovedCommmand { get; set; }

        public VertificationVM()
        {
            UserWorkers = DBInstance.GetInstance().UserWorkers.Include("IdPositionNavigation").Where(s=>s.Approved==null).ToList();
            Types = DBInstance.GetInstance().Types.ToList();
           
            ApprovedCommmand = new CustomCommand(() =>
            {
                DBInstance.GetInstance().SaveChanges();
                MessageBox.Show("ОКс");
            });
        }
    }

    
}

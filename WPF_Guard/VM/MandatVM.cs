using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_Guard.DB;
using WPF_Guard.Model;
using WPF_Guard.Tools;

namespace WPF_Guard.VM
{
    public class MandatVM
    {
        public List<UserWorker> UserWorkers { get; set; }
        public CustomCommand Save { get; set; } 
        public MandatVM()
        {
            UserWorkers = DBInstance.GetInstance().UserWorkers.Include("IdPositionNavigation").Where(s=>s.Approved==1).ToList();

            Save = new CustomCommand(() =>
            {
                DBInstance.GetInstance().SaveChanges();
                MessageBox.Show("ОКс");
            });
        }
    }
}

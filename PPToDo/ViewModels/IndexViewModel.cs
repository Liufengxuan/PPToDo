using PPToDo.Common.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPToDo.ViewModels
{
    public class IndexViewModel:BindableBase
    {
        public IndexViewModel()
        {
            TaskBar = new ObservableCollection<TaskBar>();
            CreateTaskBars();
        }

        private ObservableCollection<TaskBar> taskBar;
       public ObservableCollection<TaskBar> TaskBar
        {
            get { return taskBar; }
            set { taskBar = value;RaisePropertyChanged(); }
        }


        void CreateTaskBars()
        {
            TaskBar.Add(new TaskBar() { Icon = "ClockFast", Title = "汇总", Content = "9", Color = "#FF0CA0FF", Target = "" });
            TaskBar.Add(new TaskBar() { Icon = "ClockCheckOutline", Title = "已完成", Content = "9", Color = "#FF1ECA3A", Target = "" });
            TaskBar.Add(new TaskBar() { Icon = "ChartLineVariant", Title = "完成比例", Content = "100%", Color = "#FF02C6DC", Target = "" });
            TaskBar.Add(new TaskBar() { Icon = "PlaylistStar", Title = "备忘录", Content = "19", Color = "#FFFFA000", Target = "" });
        }
    }
}

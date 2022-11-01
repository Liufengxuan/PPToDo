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
    public class MainViewModel : BindableBase
    {
        public MainViewModel()
        {
            MenuBars = new ObservableCollection<MenuBar>();
            CreateMenuBar();
        }

        private ObservableCollection<MenuBar> menuBars;

        public ObservableCollection<MenuBar> MenuBars
        {
            get { return menuBars; }    
            set { menuBars = value; }
        }

        public void CreateMenuBar()
        {
            MenuBars.Add(new MenuBar() { Title = "首页", Icon = "Home", NameSpace = "IndexView" });
            MenuBars.Add(new MenuBar() { Title = "待办事项", Icon = "Alarm", NameSpace = "ToDoView" });
            MenuBars.Add(new MenuBar() { Title = "备忘录", Icon = "NotebookEdit", NameSpace = "MomoView" });
            MenuBars.Add(new MenuBar() { Title = "设置", Icon = "Cog", NameSpace = "SettingView" });
        }


    }
}

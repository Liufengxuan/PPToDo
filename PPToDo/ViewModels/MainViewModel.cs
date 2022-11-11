using PPToDo.Common.Models;
using PPToDo.Extensions;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
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
        public MainViewModel(IRegionManager regionManager)
        {
            MenuBars = new ObservableCollection<MenuBar>();
            CreateMenuBar();
            NavigateCommand = new DelegateCommand<MenuBar>(Navigate);
            this.regionManager = regionManager;
            GoBackCommand = new DelegateCommand(() => {
                if (journal!=null&& journal.CanGoBack)
                    journal.GoBack();
            });
            GoForwardCommand = new DelegateCommand(() =>
            {
                if (journal != null && journal.CanGoForward)
                    journal.GoForward();
            });
        }

        private void Navigate(MenuBar obj)
        {
            if (obj == null || string.IsNullOrWhiteSpace(obj.NameSpace)) return;
            regionManager.Regions[PrismManager.MainViewRegionName].RequestNavigate(obj.NameSpace, back => {
                journal = back.Context.NavigationService.Journal;//每次切换更新导航日志
            });
         
        }
        private readonly IRegionManager regionManager;
        private IRegionNavigationJournal journal;
        public DelegateCommand<MenuBar> NavigateCommand { get; set; }
        public DelegateCommand GoBackCommand { get; set; }
        public DelegateCommand GoForwardCommand { get; set; }
  

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
            MenuBars.Add(new MenuBar() { Title = "备忘录", Icon = "NotebookEdit", NameSpace = "MemoView" });
            MenuBars.Add(new MenuBar() { Title = "设置", Icon = "Cog", NameSpace = "SettingsView" });
        }


    }
}

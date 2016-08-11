using Newtonsoft.Json;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using XFCreative.Models;
using XFCreative.Services;
using System.Linq;
using Plugin.Share;
using Plugin.ExternalMaps;

namespace XFCreative.ViewModels
{
    public class BusinessSpacePageViewModel : BindableBase, INavigationAware
    {
        private readonly INavigationService _navigationService;

        #region 創業空間NodeViewModel 清單
        private ObservableCollection<創業空間NodeViewModel> _創業空間Nodes = new ObservableCollection<創業空間NodeViewModel>();
        public ObservableCollection<創業空間NodeViewModel> 創業空間Nodes
        {
            get { return this._創業空間Nodes; }
            set { this.SetProperty(ref this._創業空間Nodes, value); }
        }
        #endregion

        #region 創業空間Selected
        public 創業空間NodeViewModel 創業空間Selected { get; set; }
        #endregion

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public BusinessSpacePageViewModel(INavigationService navigationService)
        {
            // 取得頁面導航的實作
            _navigationService = navigationService;

        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " ...";

            系統初始化();
        }

        public void 系統初始化()
        {
            創業空間Nodes.Clear();
            var foo創業空間s = GlobalData.創業空間Repository.Items;

            foreach (var item in foo創業空間s)
            {
                var fooItem = new 創業空間NodeViewModel()
                {
                    縣市區域 = item.縣市區域,
                    使用坪數 = item.使用坪數,
                    創業空間名稱 = item.創業空間名稱,
                    地址 = item.地址,
                    空間主照片 = item.空間主照片.Replace("https", "http")
                };

                創業空間Nodes.Add(fooItem);
            }
        }
    }
}

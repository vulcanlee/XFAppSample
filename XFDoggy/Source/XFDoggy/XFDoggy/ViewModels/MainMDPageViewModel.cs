using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XFDoggy.ViewModels
{
    public class MainMDPageViewModel : BindableBase
    {
        private readonly INavigationService _navigationService;

        public DelegateCommand 差旅費用申請Command { get; private set; } 
        public DelegateCommand 登出Command { get; private set; } 

        public MainMDPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            差旅費用申請Command = new DelegateCommand(差旅費用申請);
            登出Command = new DelegateCommand(登出);
        }

        private async void 登出()
        {
            await _navigationService.NavigateAsync("xf:///LoginPage");
        }

        private void 差旅費用申請()
        {
            throw new NotImplementedException();
        }
    }
}

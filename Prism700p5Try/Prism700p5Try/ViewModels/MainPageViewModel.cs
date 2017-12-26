using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Prism700p5Try.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public ICommand TryRealmCommand { get; }

        public MainPageViewModel(INavigationService navigationService) 
            : base (navigationService)
        {
            Title = "Main Page";

            TryRealmCommand = new DelegateCommand(async () =>
            {
                await navigationService.NavigateAsync("StaffListPage");
            });
        }
    }
}

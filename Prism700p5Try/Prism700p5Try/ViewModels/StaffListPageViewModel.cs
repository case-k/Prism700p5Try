using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism700p5Try.Models;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace Prism700p5Try.ViewModels
{
	public class StaffListPageViewModel : ViewModelBase
    {
        private Realm _realm;

        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; private set; }

        public IEnumerable<TStaff> Staffs { get; private set; }


        public StaffListPageViewModel(INavigationService navigationService, Realm realm, TNaviParams naviparams) : base (navigationService)
        {
            _realm = realm;

            AddCommand = new DelegateCommand(async () =>
            {
                naviparams.Set(_realm.BeginWrite());
                naviparams.Set(_realm.CreateObject("TStaff", null));
                await NavigationService.NavigateAsync("StaffEditPage");
            });

            DeleteCommand = new Command<TStaff>(DeleteStaff);



            Staffs = _realm.All<TStaff>() as IEnumerable<TStaff>;
        }

        private void DeleteStaff(TStaff staff)
        {
            _realm.Write(() => _realm.Remove(staff));
        }
    }
}

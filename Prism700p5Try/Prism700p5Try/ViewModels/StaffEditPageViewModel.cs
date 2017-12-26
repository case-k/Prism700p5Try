using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism700p5Try.Models;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Input;
using Xamarin.Forms;

namespace Prism700p5Try.ViewModels
{
	public class StaffEditPageViewModel : ViewModelBase
    {
        private Realm _realm;
        private Transaction _transaction;

        public TStaff Staff { get; private set; }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }


        public StaffEditPageViewModel(INavigationService navigationService, Realm realm, TNaviParams naviparams) : base(navigationService)
        {
            _realm = realm;
            _transaction = naviparams.Get<Transaction>();
            Staff = naviparams.Get<TStaff>();


            SaveCommand = new DelegateCommand(async () =>
            {
                // コミットして前画面に戻る
                _transaction.Commit();
                await NavigationService.GoBackAsync();
            });

            CancelCommand = new DelegateCommand(async () =>
            {
                // ロールバックして前画面に戻る
                _transaction.Rollback();
                await NavigationService.GoBackAsync();
            });
        }


        override public void OnNavigatedFrom(NavigationParameters parameters)
        {
            if (_realm.IsInTransaction)
            {
                _transaction.Rollback();
            }
            _transaction.Dispose();
        }
    }
}

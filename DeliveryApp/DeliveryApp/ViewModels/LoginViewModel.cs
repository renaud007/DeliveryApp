using DeliveryApp.Services;
using DeliveryApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DeliveryApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _Username;
        public string Username
        {
            get { return _Username; }
            set
            {
                _Username = value;
                OnPropertyChanged();
            }
        }

        private string _Passeword;
        public string Passeword
        {
            get { return _Passeword; }
            set
            {
                _Passeword = value;
                OnPropertyChanged();
            }
        }

        private bool _IsBusy;
        public bool IsBusy
        {
            get { return _IsBusy; }
            set
            {
                _IsBusy = value;
                OnPropertyChanged();
            }
        }

        private bool _Disable;
        public bool Disable
        {
            get { return _Disable; }
            set
            {
                _Disable = value;
                OnPropertyChanged();
            }
        }

        private bool _Result;
        public bool  Result
        {
            get { return _Result; }
            set
            {
                _Result = value;
                OnPropertyChanged();
            }
        }


        public Command LoginCommand { get; set; }
        public Command RegisterCommand { get; set; }

        public LoginViewModel()
        {
            Disable = false;
            LoginCommand = new Command(async () => await LoginCommandAsync());
            RegisterCommand = new Command(async () => await RegisterCommandAsync());
        }

        private async Task RegisterCommandAsync()
        {
            if (IsBusy) return;
            try
            {
                IsBusy = true;
                var userService = new UserService();
                Result = await userService.RegisterUser(Username, Passeword);

                if (Result)
                {
                   await Application.Current.MainPage.DisplayAlert("Succès", "Utilisateur enregister", "OK");
                } else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Il existe déja un utilisateur avec ce nom", "OK");
                }
            }catch(Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "0K");

            }
            finally
            {
                IsBusy = false;
            }

        }

        private async Task LoginCommandAsync()
        {

            if (IsBusy) return;
            try
            {
                IsBusy = true;
                var userService = new UserService();
                Result = await userService.LoginUser(Username, Passeword);

                if (Result)
                {
                    Preferences.Set("Username", Username);
                    await Application.Current.MainPage.Navigation.PushModalAsync(new ProductsView());
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Nom d'utilisateur ou mot de passe incorrect ", "OK");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "0K");

            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}

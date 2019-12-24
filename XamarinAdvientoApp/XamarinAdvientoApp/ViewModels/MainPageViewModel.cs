using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinAdvientoApp.Dtos;
using XamarinAdvientoApp.Views;

namespace XamarinAdvientoApp.ViewModels
{    
    public class MainPageViewModel: INotifyPropertyChanged
    {
        #region PropiedadesVariables
        string nickDummie = "ArmandoCl", passDummie="ACL2019";
        public ICommand LoginCommand { get; set; }
        public ICommand SignupCommand { get; set; }
        public DtoUsuario Usuario { get; set; } = new DtoUsuario();
        #endregion
        #region Metodos
        public MainPageViewModel()
        {
            LoginCommand = new Command(Login);
            SignupCommand=new Command(SignUp);
        }

        private async void SignUp()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new SignUpPage());
        }

        private async void Login()
        {
            if (Usuario.Nick.Equals(nickDummie)&&Usuario.Pass.Equals(passDummie))
            {
                Usuario.Error = false;
                Usuario.MensajeError = "";
                await Application.Current.MainPage.DisplayAlert("Bienvenido "+Usuario.Nick, "Su inicio de sesión fue correcto", "Ok");
            }
            else
            {
                Usuario.Error = true;
                Usuario.MensajeError = "Usuario o contraseña incorrectas";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}

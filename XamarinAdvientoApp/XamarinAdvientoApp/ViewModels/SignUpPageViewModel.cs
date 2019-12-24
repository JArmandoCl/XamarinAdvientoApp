using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinAdvientoApp.Dtos;
using XF.Material.Forms.UI.Dialogs;

namespace XamarinAdvientoApp.ViewModels
{
    public class SignUpPageViewModel : INotifyPropertyChanged
    {
        #region Propiedades

        public DtoUsuario Usuario { get; set; } = new DtoUsuario();
        public ICommand RegistrarCommand { get; set; }

        #endregion
        #region Metodos

        public SignUpPageViewModel()
        {
            RegistrarCommand = new Command(Registrar);
        }

        private async void Registrar()
        {
            try
            {
                if (!string.IsNullOrEmpty(Usuario.Correo) && !string.IsNullOrEmpty(Usuario.Nick) && !string.IsNullOrEmpty(Usuario.Pass))
                {
                    if (!IsValidEmail(Usuario.Correo))
                    {
                        Usuario.CorreoError = true;
                        Usuario.CorreoMensajeError = "El correo no es válido";
                        Usuario.Error = false;
                        Usuario.MensajeError = "";
                    }
                    else
                    {
                        Usuario.CorreoError = false;
                        Usuario.CorreoMensajeError = "";
                        Usuario.Error = false;
                        Usuario.MensajeError = "";
                        using (IMaterialModalPage dialog = await MaterialDialog.Instance.LoadingDialogAsync(message: "Espere un momento..."))
                        {
                            await Task.Delay(5000);
                            dialog.MessageText = "Estamos guardando sus datos";
                            await Task.Delay(5000);
                        }
                        await MaterialDialog.Instance.SnackbarAsync(message: "Gracias por registrarse");
                    }
                }
                else if (string.IsNullOrEmpty(Usuario.Nick) || string.IsNullOrEmpty(Usuario.Pass))
                {
                    Usuario.Error = true;
                    Usuario.MensajeError = "El nick y la contraseña son obligatorios";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                await MaterialDialog.Instance.SnackbarAsync(message: "Algo no salió bien :(", actionButtonText: "OK");
            }
        }
        private bool IsValidEmail(string email)
        {
            // Return true if strIn is in valid e-mail format.
            return Regex.IsMatch(email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}

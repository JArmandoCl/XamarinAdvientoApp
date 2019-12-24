using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace XamarinAdvientoApp.Dtos
{
    public class DtoUsuario : INotifyPropertyChanged
    {
        #region Propiedades
        private string nick = "";

        public string Nick
        {
            get => nick;
            set { nick = value; OnPropertyChanged("Nick"); }
        }

        private string pass = "";

        public string Pass
        {
            get => pass;
            set { pass = value; OnPropertyChanged("Pass"); }
        }
        private bool error;

        public bool Error
        {
            get => error;
            set { error = value; OnPropertyChanged("Error"); }
        }

        private string mensajeError = "";

        public string MensajeError
        {
            get => mensajeError;
            set { mensajeError = value; OnPropertyChanged("MensajeError"); }
        }

        private string correo="";

        public string Correo
        {
            get => correo;
            set
            {
                correo = value; OnPropertyChanged("Correo");
            }
        }

        private string correoMensajeError;

        public string CorreoMensajeError
        {
            get { return correoMensajeError; }
            set
            {
                correoMensajeError=value;OnPropertyChanged("CorreoMensajeError"); }
        }
        private bool correoError;

        public bool CorreoError
        {
            get { return correoError; }
            set
            {
                correoError = value; OnPropertyChanged("CorreoError");
            }
        }
        #endregion

        #region NotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}

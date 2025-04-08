using FarmaAlert.Models;
using FarmaAlert.Services;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace FarmaAlert.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        private readonly AuthService _authService;
        private string _nombre;
        private string _email;
        private string _contrasena;
        private string _confirmarContrasena;

        public string Nombre
        {
            get => _nombre;
            set => SetProperty(ref _nombre, value);
        }

        public string email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public string Contrasena
        {
            get => _contrasena;
            set => SetProperty(ref _contrasena, value);
        }

        public string ConfirmarContrasena
        {
            get => _confirmarContrasena;
            set => SetProperty(ref _confirmarContrasena, value);
        }

        public ICommand RegisterCommand { get; }
        // Añadimos el comando faltante
        public ICommand BackToLoginCommand { get; }

        public RegisterViewModel(AuthService authService)
        {
            _authService = authService;
            RegisterCommand = new Command(async () => await RegisterUser());
            // Inicializamos el comando BackToLoginCommand
            BackToLoginCommand = new Command(async () => await GoBackToLogin());
        }

        // Método para controlar la navegación de regreso a la página de login
        private async Task GoBackToLogin()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async Task RegisterUser()
        {
            if (IsBusy) return;

            try
            {
                SetBusy(true);

                // Validaciones
                if (string.IsNullOrEmpty(Nombre) ||
                    string.IsNullOrEmpty(email) ||
                    string.IsNullOrEmpty(Contrasena) ||
                    string.IsNullOrEmpty(ConfirmarContrasena))
                {
                    ErrorMessage = "Todos los campos son obligatorios.";
                    return;
                }

                if (!IsValidEmail(email))
                {
                    ErrorMessage = "email electrónico no válido.";
                    return;
                }

                if (!IsValidPassword(Contrasena))
                {
                    ErrorMessage = "La contraseña debe tener al menos 8 caracteres, una mayúscula, un número y un carácter especial.";
                    return;
                }

                if (Contrasena != ConfirmarContrasena)
                {
                    ErrorMessage = "Las contraseñas no coinciden.";
                    return;
                }

                var registerModel = new RegisterRequest
                {
                    Nombre = Nombre.Trim(),
                    email = email.Trim(),
                    Contrasena = Contrasena,
                    ConfirmarContrasena = ConfirmarContrasena
                };

                bool result = await _authService.Register(registerModel);

                if (result)
                {
                    // Aquí puedes manejar el éxito (no desde el ViewModel)
                    await Shell.Current.DisplayAlert("Éxito", "Registro exitoso", "OK");
                    ClearFields();
                    await Shell.Current.GoToAsync("//login");
                }
                else
                {
                    ErrorMessage = "Error en el registro. Inténtalo de nuevo.";
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Error: {ex.Message}";
            }
            finally
            {
                SetBusy(false);
            }
        }

        private void ClearFields()
        {
            Nombre = string.Empty;
            email = string.Empty;
            Contrasena = string.Empty;
            ConfirmarContrasena = string.Empty;
        }

        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        private bool IsValidPassword(string password)
        {
            return Regex.IsMatch(password, @"^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$");
        }
    }
}
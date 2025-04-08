using FarmaAlert.Models;
using FarmaAlert.Services;
using System.Diagnostics;
using System.Windows.Input;

namespace FarmaAlert.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly AuthService _authService;
        private string _email;
        private string _contrasena;

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public string Contrasena
        {
            get => _contrasena;
            set => SetProperty(ref _contrasena, value);
        }

        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }
        public ICommand ForgotPasswordCommand { get; }

        public LoginViewModel(AuthService authService)
        {
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));

            // Implementamos los comandos de forma segura con verificación de nulos
            LoginCommand = new Command(async () => await ExecuteSafely(LoginUser));
            RegisterCommand = new Command(async () => await ExecuteSafely(GoToRegister));
            ForgotPasswordCommand = new Command(async () => await ExecuteSafely(GoToForgotPassword));
        }

        // Método auxiliar para ejecutar tareas de forma segura
        private async Task ExecuteSafely(Func<Task> action)
        {
            try
            {
                await action();
            }
            catch (Exception ex)
            {
                // Log del error
                Debug.WriteLine($"Error en comando: {ex.Message}");
                ErrorMessage = $"Error: {ex.Message}";
            }
        }

        private async Task LoginUser()
        {
            if (IsBusy) return;

            try
            {
                SetBusy(true);

                // Validaciones básicas
                if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Contrasena))
                {
                    ErrorMessage = "Por favor, completa todos los campos.";
                    return;
                }

                var loginModel = new LoginRequest
                {
                    email = Email.Trim(),
                    Contrasena = Contrasena
                };

                // Método temporal para debugging
                await Task.Delay(500); // Simular tiempo de procesamiento

                // Comentar esta línea y descomentar la siguiente para pruebas sin API
                var token = await _authService.Login(loginModel);

                if (!string.IsNullOrEmpty(token))
                {
                    // Guardar el token en el almacenamiento seguro
                    await SecureStorage.Default.SetAsync("token", token);

                    // Navegar a la página principal (TabBar)
                    await Shell.Current.GoToAsync("//Pastillas");

                    // Limpiar campos
                    ClearFields();
                }
            }
            catch (UnauthorizedAccessException)
            {
                ErrorMessage = "email o contraseña incorrectos.";
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Error: {ex.Message}";
                Debug.WriteLine($"Error en login: {ex}");
            }
            finally
            {
                SetBusy(false);
            }
        }

        private async Task GoToRegister()
        {
            await Shell.Current.GoToAsync("register");
        }

        private async Task GoToForgotPassword()
        {
            await Shell.Current.GoToAsync("forgotpassword");
        }

        private void ClearFields()
        {
            Email = string.Empty;
            Contrasena = string.Empty;
        }
    }
}
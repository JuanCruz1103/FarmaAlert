using FarmaAlert.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace FarmaAlert.Services
{
    public class AuthService : BaseApiService
    {
        public async Task<bool> Register(RegisterRequest model)
        {
            try
            {
                var response = await _httpCliente.PostAsJsonAsync("/api/auth/register", model);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en registro: {ex.Message}");
                throw;
            }
        }

        public async Task<string> Login(LoginRequest model)
        {
            try
            {
                var response = await _httpCliente.PostAsJsonAsync("/api/auth/login", model);

                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Login status: {response.StatusCode}, content: {content}");
                Console.WriteLine($"El email enviado es {model.email} y la contrasena enviada es {model.Contrasena}");

                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedAccessException("email o contraseña incorrectos");
                }

                if (response.IsSuccessStatusCode)
                {
                    if (response.Content.Headers.ContentLength == 0)
                    {
                        throw new Exception("El servidor respondió sin contenido.");
                    }

                    var json = await response.Content.ReadFromJsonAsync<JsonElement>();
                    var token = json.GetProperty("token").GetString();
                    return token;
                }
                else
                {
                    throw new Exception("Error en el login");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en login: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> ForgotPassword(string email)
        {
            try
            {
                var response = await _httpCliente.PostAsJsonAsync("/api/auth/forgot-password", email);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en recuperación de contraseña: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> ResetPassword(RestablecerContrasenaRequest model)
        {
            try
            {
                var response = await _httpCliente.PostAsJsonAsync("/api/auth/reset-password", model);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cambiar contraseña: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> ValidateToken(string token)
        {
            try
            {
                var request = new { Token = token };
                var response = await _httpCliente.PostAsJsonAsync("/api/auth/validate-token", request);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en validación de token: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> Logout(string userId)
        {
            try
            {
                var response = await _httpCliente.PostAsJsonAsync("/api/auth/logout", userId);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en logout: {ex.Message}");
                throw;
            }
        }
    }
}
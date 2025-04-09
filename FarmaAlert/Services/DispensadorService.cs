// DispensadorService.cs
namespace FarmaAlert.Services
{
    public class DispensadorService : BaseApiService
    {
        public DispensadorService() : base()
        {
        }

        public async Task<bool> ActivarDispensador(string nombre)
        {
            try
            {
                var response = await PostAsync<string>("api/Dispensador/activar", nombre);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al activar dispensador: {ex.Message}");
                return false;
            }
        }
    }
}
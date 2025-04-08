using FarmaAlert.Models;
using FarmaAlert.Services;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FarmaAlert.Services
{
    public class AlarmaService : BaseApiService
    {

        public async Task<List<AlarmaModel>> GetAllAlarmas()
        {
            try
            {
                var response = await _httpCliente.GetAsync("/api/Alarma/GetAll");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<AlarmaModel>>();
                }
                return new List<AlarmaModel>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching alarmas: {ex.Message}");
                return new List<AlarmaModel>();
            }
        }

        public async Task<AlarmaModel> GetAlarmaById(string id)
        {
            try
            {
                // Corregir la URL para el endpoint
                return await GetAsync<AlarmaModel>($"/api/Alarma/GetById/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching alarma: {ex.Message}");
                return null;
            }
        }

        public async Task<AlarmaModel> UpdateAlarma(string id, AlarmaModel alarma)
        {
            try
            {
                // Corregir la URL para el endpoint
                return await PutAsync<AlarmaModel>($"/api/Alarma/Actualizar/{id}", alarma);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating alarma: {ex.Message}");
                return null;
            }
        }

        public async Task<AlarmaModel> CreateAlarma(AlarmaModel alarma)
        {
            try
            {
                // Agrega logs para depuración
                Console.WriteLine($"Enviando datos de alarma: {System.Text.Json.JsonSerializer.Serialize(alarma)}");

                return await PostAsync<AlarmaModel>("/api/Alarma/Crear", alarma);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating alarma: {ex.Message}");
                // Si hay información de error adicional
                if (ex is HttpRequestException httpEx && httpEx.Data.Contains("ResponseContent"))
                {
                    Console.WriteLine($"Response content: {httpEx.Data["ResponseContent"]}");
                }
                return null;
            }
        }

        public async Task<bool> DeleteAlarma(string id)
        {
            try
            {
                return await DeleteAsync($"/api/Alarma/Eliminar{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting alarma: {ex.Message}");
                return false;
            }
        }
    }
}
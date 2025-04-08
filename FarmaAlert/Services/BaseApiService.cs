using System.ComponentModel;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;

namespace FarmaAlert.Services
{
    public class BaseApiService : INotifyPropertyChanged
    {
        protected readonly HttpClient _httpCliente;
        public BaseApiService()
        {
            _httpCliente = new HttpClient();
#if ANDROID
                _httpCliente.BaseAddress = new Uri("https://svsvf749-44398.usw3.devtunnels.ms"); // Reemplaza con tu IPv4
#elif IOS
                _httpCliente.BaseAddress = new Uri("https://svsvf749-44398.usw3.devtunnels.ms"); // Reemplaza con tu IPv4
#else
            _httpCliente.BaseAddress = new Uri("https://svsvf749-44398.usw3.devtunnels.ms"); // Reemplaza con tu IPv4
#endif
        }
        private bool _isBusy;
        private string _title;

        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public async Task<T> GetAsync<T>(string url)
        {
            var response = await _httpCliente.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task<T> PostAsync<T>(string url, object data)
        {
            var response = await _httpCliente.PostAsJsonAsync(url, data);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task<T> PutAsync<T>(string url, object data)
        {
            var response = await _httpCliente.PutAsJsonAsync(url, data);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task<bool> DeleteAsync(string url)
        {
            var response = await _httpCliente.DeleteAsync(url);
            return response.IsSuccessStatusCode;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "", Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

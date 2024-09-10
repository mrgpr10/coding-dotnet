using ProductClient.Models;
namespace ProductClient.Services
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;
        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Product>> GetProductsAsync()
        {
            var response = await
           _httpClient.GetAsync("http://localhost:5082/gateway/product");
            response.EnsureSuccessStatusCode();
            return await
           response.Content.ReadFromJsonAsync<List<Product>>();
        }

    }
}

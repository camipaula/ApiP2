using Proyecto_Progreso1_1.Models;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;

namespace Proyecto_Progreso1_1.NewFolder
{
    public class Services : IServices
    {
        //inicializa httpClient
        private readonly HttpClient _httpClient;
        private readonly string _url = "https://apiproyecto120231203190048.azurewebsites.net";

        public Services()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(_url)
            };
        }

        // Realiza una solicitud HTTP para obtener la lista de prendas
        public async Task<List<Prenda>> GetAllPrendas()

        {

            var response = await _httpClient.GetFromJsonAsync<List<Prenda>>("api/Prenda");
            return response;
        }

        public async Task<Prenda> GetPrenda(int IdPrenda)
        {
            // Obtiene 1 solo prendas por su Id
            var response = await _httpClient.GetFromJsonAsync<Prenda>($"api/Prenda/{IdPrenda}");


            return response;
        }

        // Realiza una solicitud HTTP POST para crear una prenda

        public async Task<Prenda> CreatePrenda(PrendaUsuario prenda)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Prenda", prenda);
            return await response.Content.ReadFromJsonAsync<Prenda>();
        }

        public async Task<Prenda> UpdatePrenda(int IdPrenda, Prenda prenda)
        {
            /*var content = new StringContent(JsonConvert.SerializeObject(prenda), Encoding.UTF8, "application/json");

            //var response = await _httpClient.PutAsync("api/Prenda/" + IdPrenda, content);*/

            var response = await _httpClient.PutAsJsonAsync("api/Prenda/" + IdPrenda,prenda);

            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Prenda prod = JsonConvert.DeserializeObject<Prenda>(json_response);
                return prod;
            }
            return new Prenda();
        }

        // Realiza una solicitud HTTP para eliminar una prenda

        public async void DeletePrenda(int IdPrenda)
        {
            _httpClient.DeleteAsync($"api/Prenda/{IdPrenda}");
        }



        ///////////////////////////ACCESORIO///////////////////////////////////////
        // Realiza una solicitud HTTP para obtener la lista de accesorios
        public async Task<List<Accesorio>> GetAllAccesorios()

        {

            var response = await _httpClient.GetFromJsonAsync<List<Accesorio>>("api/Accesorio");

            

            return response;
        }

        public async Task<Accesorio> GetAccesorio(int IdAccesorio)
        {
            // Obtiene 1 solo accesorio por su Id
            var response = await _httpClient.GetFromJsonAsync<Accesorio>($"api/Accesorio/{IdAccesorio}");
            return response;
        }

        // Realiza una solicitud HTTP POST para crear un accesorio

        public async Task<Accesorio> CreateAccesorio(Accesorio accesorio)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Accesorio", accesorio);
            return await response.Content.ReadFromJsonAsync<Accesorio>();
        }

        public async Task<Accesorio> UpdateAccesorio(int IdAccesorio, Accesorio accesorio)
        {
            // Realiza una solicitud HTTP PUT para modificar un accesorio
            var response = await _httpClient.PutAsJsonAsync($"api/Accesorio/{IdAccesorio}", accesorio);
            return await response.Content.ReadFromJsonAsync<Accesorio>();
        }

        // Realiza una solicitud HTTP para eliminar un accesorio

        public async void DeleteAccesorio(int IdAccesorio)
        {
            _httpClient.DeleteAsync($"api/Accesorio/{IdAccesorio}");
        }

        ///////////////////////////PROMOCIONES///////////////////////////////////////
        // Realiza una solicitud HTTP para obtener la lista de accesorios
        public async Task<List<Promocion>> GetAllPromociones()

        {

            var response = await _httpClient.GetFromJsonAsync<List<Promocion>>("api/Promocion");
            return response;
        }

        public async Task<Promocion> GetPromocion(int IdPromocion)
        {
            // Obtiene 1 solo accesorio por su Id
            var response = await _httpClient.GetFromJsonAsync<Promocion>($"api/Promocion/{IdPromocion}");
            return response;
        }

        // Realiza una solicitud HTTP POST para crear un accesorio

        public async Task<Promocion> CreatePromocion(Promocion promocion)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Promocion", promocion);
            return await response.Content.ReadFromJsonAsync<Promocion>();
        }

        public async Task<Promocion> UpdatePromocion(int IdPromocion, Promocion promocion)
        {
            // Realiza una solicitud HTTP PUT para modificar un accesorio
            var response = await _httpClient.PutAsJsonAsync($"api/Promocion/ {IdPromocion}", promocion);
            return await response.Content.ReadFromJsonAsync<Promocion>();
        }

        // Realiza una solicitud HTTP para eliminar un accesorio

        public async void DeletePromocion(int IdPromocion)
        {
            _httpClient.DeleteAsync($"api/Promocion/{IdPromocion}");
        }

        ///////////////////////////Categorias///////////////////////////////////////
      
        public async Task<List<Categoria>> GetAllCategorias()

        {

            var response = await _httpClient.GetFromJsonAsync<List<Categoria>>($"api/Categoria");
            return response;
        }

        public async Task<Categoria> GetCategoria(int IdCategoria)
        {
            // Obtiene 1 sola categoria por su Id
            var response = await _httpClient.GetFromJsonAsync<Categoria>($"api/Categoria/{IdCategoria}");
            return response;
        }

        // Realiza una solicitud HTTP POST para crear un accesorio

        public async Task<Categoria> CreateCategoria(Categoria categoria)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Categoria", categoria);
            return await response.Content.ReadFromJsonAsync<Categoria>();
        }

        public async Task<Categoria> UpdateCategoria(int IdCategoria, Categoria categoria)
        {
            // Realiza una solicitud HTTP PUT para modificar un accesorio
            var response = await _httpClient.PutAsJsonAsync($"api/Categoria/ {IdCategoria}", categoria);
            return await response.Content.ReadFromJsonAsync<Categoria>();
        }

        // Realiza una solicitud HTTP para eliminar un accesorio

        public async void DeleteCategoria(int IdCategoria)
        {
            _httpClient.DeleteAsync($"api/Categoria/{IdCategoria}");

        }

        ///////////////////////////Marca///////////////////////////////////////
        public async Task<List<Marca>> GetAllMarcas()

        {

            var response = await _httpClient.GetFromJsonAsync<List<Marca>>("api/Marca");
            return response;
        }

        public async Task<Marca> GetMarca(int IdMarca)
        {
            // Obtiene 1 solo accesorio por su Id
            var response = await _httpClient.GetFromJsonAsync<Marca>($"api/Marca/{IdMarca}");
            return response;
        }

        // Realiza una solicitud HTTP POST para crear un accesorio

        public async Task<Marca> CreateMarca(Marca marca)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Marca", marca);
            return await response.Content.ReadFromJsonAsync<Marca>();
        }

        public async Task<Marca> UpdateMarca(int IdMarca, Marca marca)
        {
            // Realiza una solicitud HTTP PUT para modificar un accesorio
            var response = await _httpClient.PutAsJsonAsync($"api/Marca/ {IdMarca}", marca);
            return await response.Content.ReadFromJsonAsync<Marca>();
        }

            // Realiza una solicitud HTTP para eliminar un accesorio

            public async void DeleteMarca(int IdMarca)
            {
                _httpClient.DeleteAsync($"api/Marca/{IdMarca}");
            }


        ///////////////////////////Marca///////////////////////////////////////
        public async Task<List<Usuario>> GetAllUsuarios()
        {

            var response = await _httpClient.GetFromJsonAsync<List<Usuario>>("api/Usuario");
            return response;
        }

        public async Task<Usuario> GetUsuario(int IdUsuario)
        {
            // Obtiene 1 solo accesorio por su Id
            var response = await _httpClient.GetFromJsonAsync<Usuario>($"api/Usuario/{IdUsuario}");
            return response;
        }

        // Realiza una solicitud HTTP POST para crear un accesorio

        public async Task<Usuario> CreateUsuario(Usuario usuario)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Usuario", usuario);
            return await response.Content.ReadFromJsonAsync<Usuario>();
        }

        public async Task<Usuario> UpdateUsuario(int IdUsuario, Usuario usuario)
        {
            // Realiza una solicitud HTTP PUT para modificar un accesorio
            var response = await _httpClient.PutAsJsonAsync($"api/Usuario/ {IdUsuario}", usuario);
            return await response.Content.ReadFromJsonAsync<Usuario>();
        }

        // Realiza una solicitud HTTP para eliminar un accesorio

        public async void DeleteUsuario(int IdUsuario)
        {
            _httpClient.DeleteAsync($"api/Usuario/{IdUsuario}");
        }


        public async Task<Usuario> GetUsuario(string usuario, string contrasena)
        {
            var response = await _httpClient.GetAsync("api/Usuario/" + usuario + "/" + contrasena);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Usuario usuarios = JsonConvert.DeserializeObject<Usuario>(json_response);
                return usuarios;
            }
            return null;
        }

    }



}

using Proyecto_Progreso1_1.Models;

namespace Proyecto_Progreso1_1.NewFolder
{
    public interface IServices
    {
        Task<List<Prenda>> GetAllPrendas();
        Task<Prenda> GetPrenda(int IdPrenda);
        Task<Prenda> CreatePrenda(PrendaUsuario prenda);
        Task<Prenda> UpdatePrenda(int IdPrenda, Prenda prenda);
        void DeletePrenda(int IdPrenda);



        Task<List<Accesorio>> GetAllAccesorios();
        Task<Accesorio> GetAccesorio(int IdAccesorio);
        Task<Accesorio> CreateAccesorio(Accesorio accesorio);
        Task<Accesorio> UpdateAccesorio(int IdAccesorio, Accesorio accesorio);
        void DeleteAccesorio(int IdAccesorio);


        Task<List<Promocion>> GetAllPromociones();
        Task<Promocion> GetPromocion(int IdPromocion);
        Task<Promocion> CreatePromocion(Promocion promocion);
        Task<Promocion> UpdatePromocion(int IdPromocion, Promocion promocion);
        void DeletePromocion(int IdPromocion);



        Task<List<Categoria>> GetAllCategorias();
        Task<Categoria> GetCategoria(int IdCategoria);
        Task<Categoria> CreateCategoria(Categoria categoria);
        Task<Categoria> UpdateCategoria(int IdCategoria, Categoria categoria);
        void DeleteCategoria(int IdCategoria);


        Task<List<Marca>> GetAllMarcas();
        Task<Marca> GetMarca(int IdMarca);
        Task<Marca> CreateMarca(Marca marca);
        Task<Marca> UpdateMarca(int IdMarca, Marca marca);
        void DeleteMarca(int IdMarca);

        Task<List<Usuario>> GetAllUsuarios();
        Task<Usuario> GetUsuario(int IdUsuario);
        Task<Usuario> CreateUsuario(Usuario usuario);
        Task<Usuario> UpdateUsuario(int IdUsuario, Usuario usuario);
        void DeleteUsuario(int IdUsuario);

        Task<Usuario> GetUsuario(string usuario, string contrasena);
    }
}

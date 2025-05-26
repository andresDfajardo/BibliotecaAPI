using BibliotecaAPI.DTO;
using BibliotecaAPI.Models;
using BibliotecaAPI.Repositories;

namespace BibliotecaAPI.Services
{
    public interface IEjemplaresService
    {
        Task<EjemplaresModel> CreateEjemplares(int idLibro, string ubicacion);
        Task<List<EjemplaresDTO>> GetAll();
        Task<EjemplaresModel> UpdateEjemplares(int id, int? idLibro, string? ubicacion);
        Task<EjemplaresDTO> GetEjemplares(int id);
        Task<EjemplaresModel> DeleteEjemplares(int id);
    }
    public class EjemplaresService : IEjemplaresService
    {
        private readonly IEjemplaresRepository _ejemplarRepository;
        public EjemplaresService(IEjemplaresRepository ejemplarRepository)
        {
            _ejemplarRepository = ejemplarRepository;
        }
        public async Task<EjemplaresModel> CreateEjemplares(int idLibro, string ubicacion)
        {
            return await _ejemplarRepository.CreateEjemplares(idLibro, ubicacion);
        }

        public async Task<EjemplaresModel> DeleteEjemplares(int id)
        {
            var ejemplaresDTO = await _ejemplarRepository.GetEjemplares(id);
            EjemplaresModel ejemplaresModel = new EjemplaresModel();
            ejemplaresModel.IdEjemplar = ejemplaresDTO.IdEjemplar;
            return await _ejemplarRepository.DeleteEjemplares(ejemplaresModel);
        }

        public async Task<List<EjemplaresDTO>> GetAll()
        {
            return await _ejemplarRepository.GetAll();
        }

        public async Task<EjemplaresDTO> GetEjemplares(int id)
        {
            return await _ejemplarRepository.GetEjemplares(id);
        }

        public async Task<EjemplaresModel> UpdateEjemplares(int id, int? idLibro, string? ubicacion)
        {
            var ejemplaresDTO = await _ejemplarRepository.GetEjemplares(id);
            EjemplaresModel ejemplaresModel = new EjemplaresModel();
            ejemplaresModel.IdEjemplar = ejemplaresDTO.IdEjemplar;
            ejemplaresModel.IdLibro = ejemplaresDTO.IdLibro;
            ejemplaresModel.Ubicacion = ejemplaresDTO.Ubicacion;

            if (ejemplaresModel != null)
            {
                if (idLibro != null)
                    ejemplaresModel.IdLibro = idLibro;
                else if (ubicacion != null)
                    ejemplaresModel.Ubicacion = ubicacion;
                return await _ejemplarRepository.UpdateEjemplares(ejemplaresModel);
            }
            else
                return null;
        }
    }
}

using BibliotecaAPI.DTO;
using BibliotecaAPI.Models;
using BibliotecaAPI.Repositories;
using System.Reflection.Metadata;

namespace BibliotecaAPI.Services
{
    public interface ILectoresService
    {
        Task<LectoresModel> CreateLectores(int idPersona, DateOnly fechaRegistro, string ocupacion);
        Task<List<LectoresDTO>> GetAll();
        Task<LectoresModel> UpdateLectores(int id, int? idPersona, DateOnly? fechaRegistro, string? ocupacion);
        Task<LectoresDTO> GetLectores(int id);
        Task<LectoresModel> DeleteLectores(int id);
    }
    public class LectoresService : ILectoresService
    {
        private readonly ILectoresRepository _lectoresRepository;
        public LectoresService(ILectoresRepository lectoresRepository)
        {
            _lectoresRepository = lectoresRepository;
        }
        public async Task<LectoresModel> CreateLectores(int idPersona, DateOnly fechaRegistro, string ocupacion)
        {
            return await _lectoresRepository.CreateLectores(idPersona,fechaRegistro,ocupacion);
        }

        public async Task<LectoresModel> DeleteLectores(int id)
        {
            var lectoresDTO = await _lectoresRepository.GetLectores(id);
            LectoresModel lectoresModel = new LectoresModel();
            lectoresModel.IdLector = lectoresDTO.IdLector;
            return await _lectoresRepository.DeleteLectores(lectoresModel);
        }

        public async Task<List<LectoresDTO>> GetAll()
        {
            return await _lectoresRepository.GetAll();
        }

        public async Task<LectoresDTO> GetLectores(int id)
        {
            return await _lectoresRepository.GetLectores(id);
        }

        public async Task<LectoresModel> UpdateLectores(int id, int? idPersona, DateOnly? fechaRegistro, string? ocupacion)
        {
            var lectoresDTO = await _lectoresRepository.GetLectores(id);
            LectoresModel lectoresModel= new LectoresModel();
            lectoresModel.IdLector= lectoresDTO.IdLector;
            lectoresModel.IdPersona= lectoresDTO.IdPersona;
            lectoresModel.FechaRegistro= lectoresDTO.FechaRegistro;
            lectoresModel.Ocupacion = lectoresDTO.Ocupacion;
            if (lectoresModel != null)
            {
                if (idPersona != null)
                    lectoresModel.IdPersona = idPersona;
                if (fechaRegistro != null)
                    lectoresModel.FechaRegistro = fechaRegistro;
                if (ocupacion != null)
                    lectoresModel.Ocupacion = ocupacion;
                return await _lectoresRepository.UpdateLectores(lectoresModel);
            }
            else
                return null;
        }
    }
}

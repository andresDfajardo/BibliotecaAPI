using BibliotecaAPI.DTO;
using BibliotecaAPI.Models;
using BibliotecaAPI.Repositories;

namespace BibliotecaAPI.Services
{
    public interface IBibliotecariosService
    {
        Task<List<BibliotecariosDTO>> GetAll();
        Task<BibliotecariosDTO> GetBibliotecario(int id);
        Task<BibliotecariosModel> CreateBibliotecario(int idPersona, DateOnly fechaContratacion, string turno);
        Task<BibliotecariosModel> UpdateBibliotecario(int id, int? idPersona, DateOnly? fechaContratacion, string? turno);
        Task<BibliotecariosModel> DeleteBibliotecario(int id);
    }
    public class BibliotecariosService : IBibliotecariosService
    {
        private readonly IBibliotecariosRepository _bibliotecariosRepository;
        public BibliotecariosService(IBibliotecariosRepository clientRepository)
        {
            _bibliotecariosRepository = clientRepository;
        }
        public async Task<BibliotecariosModel> CreateBibliotecario(int idPersona, DateOnly fechaContratacion, string turno)
        {
            return await _bibliotecariosRepository.CreateBibliotecario(idPersona, fechaContratacion, turno);
        }

        public async Task<BibliotecariosModel> DeleteBibliotecario(int id)
        {
            var bibliotecariosDTO = await _bibliotecariosRepository.GetBibliotecario(id);
            BibliotecariosModel bibliotecariosModel = new BibliotecariosModel();
            bibliotecariosModel.IdBibliotecario = bibliotecariosDTO.IdBibliotecario;
            return await _bibliotecariosRepository.DeleteBibliotecario(bibliotecariosModel);
        }

        public async Task<List<BibliotecariosDTO>> GetAll()
        {
            return await _bibliotecariosRepository.GetAll();
        }

        public async Task<BibliotecariosDTO> GetBibliotecario(int id)
        {
            return await _bibliotecariosRepository.GetBibliotecario(id);
        }

        public async Task<BibliotecariosModel> UpdateBibliotecario(int id, int? idPersona, DateOnly? fechaContratacion, string? turno)
        {
            var bibliotecariosDTO = await _bibliotecariosRepository.GetBibliotecario(id);
            BibliotecariosModel bibliotecariosModel = new BibliotecariosModel();
            bibliotecariosModel.IdBibliotecario = bibliotecariosDTO.IdBibliotecario;
            bibliotecariosModel.IdPersona = bibliotecariosDTO.IdPersona;
            bibliotecariosModel.FechaContratacion = bibliotecariosDTO.FechaContratacion;
            bibliotecariosModel.Turno = bibliotecariosDTO.Turno;

            if (bibliotecariosModel != null)
            {
                if (idPersona != null)
                    bibliotecariosModel.IdPersona = idPersona;
                else if (fechaContratacion != null)
                    bibliotecariosModel.FechaContratacion = fechaContratacion;
                else if (turno != null)
                    bibliotecariosModel.Turno = turno;
                return await _bibliotecariosRepository.UpdateBibliotecario(bibliotecariosModel);
            }
            else
                return null;

        }
    }
}

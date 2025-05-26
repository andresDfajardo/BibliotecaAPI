using BibliotecaAPI.Models;
using BibliotecaAPI.Repositories;

namespace BibliotecaAPI.Services
{
    public interface IEditorialesService
    {
        Task<List<EditorialesModel>> GetAll();
        Task<EditorialesModel> GetEditorial(int id);
        Task<EditorialesModel> CreateEditoriales(string nombre, string pais, string ciudad, string sitioWeb);
        Task<EditorialesModel> UpdateEditoriales(int id,string? nombre, string? pais, string? ciudad, string? sitioWeb);
        Task<EditorialesModel> DeleteEditoriales(int id);
    }
    public class EditorialesService : IEditorialesService
    {
        private readonly IEditorialesRepository _editorialesRepository;
        public EditorialesService(IEditorialesRepository editorialesRepository)
        {
            _editorialesRepository = editorialesRepository;
        }
        public async Task<EditorialesModel> CreateEditoriales(string nombre, string pais, string ciudad, string sitioWeb)
        {
            return await _editorialesRepository.CreateEditoriales(nombre, pais, ciudad, sitioWeb);
        }

        public async Task<EditorialesModel> DeleteEditoriales(int id)
        {
            EditorialesModel model = await _editorialesRepository.GetEditorial(id);
            return await _editorialesRepository.DeleteEditoriales(model);
        }

        public async Task<List<EditorialesModel>> GetAll()
        {
            return await _editorialesRepository.GetAll();
        }

        public async Task<EditorialesModel> GetEditorial(int id)
        {
            return await _editorialesRepository.GetEditorial(id);
        }

        public async Task<EditorialesModel> UpdateEditoriales(int id, string? nombre, string? pais, string? ciudad, string? sitioWeb)
        {
            EditorialesModel editorialesModel = await _editorialesRepository.GetEditorial(id);
            if (editorialesModel != null)
            {
                if (nombre != null)
                    editorialesModel.Nombre = nombre;
                else if (pais != null)
                    editorialesModel.Pais = pais;
                else if (ciudad != null)
                    editorialesModel.Ciudad = ciudad;
                else if (sitioWeb != null)
                    editorialesModel.SitioWeb = sitioWeb;
                return await _editorialesRepository.UpdateEditoriales(editorialesModel);
            }
            else
                return null;
        }
    }
}

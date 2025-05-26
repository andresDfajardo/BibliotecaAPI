using BibliotecaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Repositories
{
    public interface IEditorialesRepository
    {
        Task<List<EditorialesModel>> GetAll();
        Task<EditorialesModel> GetEditorial(int id);
        Task<EditorialesModel> CreateEditoriales(string nombre, string pais, string ciudad, string sitioWeb);
        Task<EditorialesModel> UpdateEditoriales(EditorialesModel editorialesModel);
        Task<EditorialesModel> DeleteEditoriales(EditorialesModel editorialesModel);
    }
    public class EditorialesRepository : IEditorialesRepository
    {
        private readonly ApplicationDbContext _db;
        public EditorialesRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<EditorialesModel> CreateEditoriales(string nombre, string pais, string ciudad, string sitioWeb)
        {
            EditorialesModel editorModel = new EditorialesModel
            {
                Nombre = nombre,
                Pais = pais,
                Ciudad = ciudad,
                SitioWeb = sitioWeb
            };
            await _db.Editoriales.AddAsync(editorModel);
            _db.SaveChanges();
            return editorModel;
        }

        public async Task<EditorialesModel> DeleteEditoriales(EditorialesModel editorialesModel)
        {
            _db.Editoriales.Remove(editorialesModel);
            await _db.SaveChangesAsync();
            return editorialesModel;
        }

        public async Task<List<EditorialesModel>> GetAll()
        {
            return await _db.Editoriales.ToListAsync();
        }

        public Task<EditorialesModel> GetEditorial(int id)
        {
            return _db.Editoriales.FirstOrDefaultAsync(x => x.IdEditorial == id);
        }

        public async Task<EditorialesModel> UpdateEditoriales(EditorialesModel editorialesModel)
        {
            _db.Editoriales.Update(editorialesModel);
            await _db.SaveChangesAsync();
            return editorialesModel;
        }
    }
}

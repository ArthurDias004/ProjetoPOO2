using academico.Models;

namespace academico.Repositories
{
    public interface IProjetoRepository
    {
        Task<IEnumerable<Projeto>> GetAll();
        Task<Projeto> GetId(int id);
        Task Create(Projeto projeto);
        Task Edit(Projeto projeto);
        Task Delete(int id);
    }
}


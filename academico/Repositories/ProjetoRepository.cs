using academico.Models;

namespace academico.Repositories
{
    public class ProjetoRepository : IProjetoRepository
    {
        private List<Projeto> _projetos = new();
        private int _id = 1;

        public ProjetoRepository()
        {
            _projetos.Add(new Projeto
            {
                ProjetoId = 1,
                Nome = "Projeto A",
                Sigla = "PA",
                Ano = DateTime.Now.Year,
                Ativo = true
            });

            _projetos.Add(new Projeto
            {
                ProjetoId = 2,
                Nome = "Projeto B",
                Sigla = "PB",
                Ano = DateTime.Now.Year,
                Ativo = false
            });

            _id = 3;
        }

        public Task<IEnumerable<Projeto>> GetAll()
        {
            return Task.FromResult(_projetos.AsEnumerable());
        }

        public Task<Projeto> GetId(int id)
        {
            return Task.FromResult(_projetos.FirstOrDefault(p => p.ProjetoId == id));
        }

        public Task Create(Projeto projeto)
        {
            projeto.ProjetoId = _id++;
            _projetos.Add(projeto);
            return Task.CompletedTask;
        }

        public Task Edit(Projeto projeto)
        {
            var p = _projetos.FirstOrDefault(x => x.ProjetoId == projeto.ProjetoId);
            if (p != null)
            {
                p.Nome = projeto.Nome;
                p.Sigla = projeto.Sigla;
                p.Ano = projeto.Ano;
                p.Ativo = projeto.Ativo;
            }
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var p = _projetos.FirstOrDefault(x => x.ProjetoId == id);
            if (p != null)
                _projetos.Remove(p);

            return Task.CompletedTask;
        }
    }
}
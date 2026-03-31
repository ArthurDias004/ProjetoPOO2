using Microsoft.AspNetCore.Mvc;
using academico.Models;
using academico.Repositories;

namespace academico.Controllers
{
    public class ProjetoController : Controller
    {
        private readonly IProjetoRepository _repo;

        public ProjetoController(IProjetoRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _repo.GetAll());
        }

        public IActionResult Create()
        {
            return View(new Projeto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Projeto projeto)
        {
            if (projeto.Ano != DateTime.Now.Year)
            {
                ModelState.AddModelError("Ano", "Só pode ano atual");
            }

            if (!ModelState.IsValid)
                return View(projeto);

            await _repo.Create(projeto);
            return RedirectToAction("Index");
        }
    }
}
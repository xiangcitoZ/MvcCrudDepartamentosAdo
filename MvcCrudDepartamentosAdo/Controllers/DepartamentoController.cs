using Microsoft.AspNetCore.Mvc;
using MvcCrudDepartamentosAdo.Repositories;
using MvcCrudDepartamentosAdo.Models;


namespace MvcCrudDepartamentosAdo.Controllers
{
    

    public class DepartamentoController : Controller
    {
        private RepositoryDepartamentos repo;

        public DepartamentoController()
        {
            this.repo = new RepositoryDepartamentos();
        }
        public IActionResult Index()
        {
            List<Departamento> departamentos = this.repo.GetDepartamentos();
            return View(departamentos);
        }

        public IActionResult Details(int iddepartamento)
        {
            Departamento departamento = this.repo.FindDepartamento(iddepartamento);
            return View(departamento);
        }

        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Create(Departamento departamento)
        {
            this.repo.InsertDepartamento(departamento.IdDepartamento
                , departamento.Nombre, departamento.Localidad);
            ViewData["MENSAJE"] = "Departamento insertado";
            //return View("Index");
            //EXISTE UN METODO LLAMADO RedirectToAction
            //QUE NO MANDA A UNA VISTA, SINO QUE MANDA AL ACTION
            return RedirectToAction("Index");
        }

        //PARA ELIMINAR NO VAMOS A TENER NINGUNA VISTA
        //DIRECTAMENTE PONDREMOS UN ENLACE DENTRO DE Index.cshtml
        //Y QUE LLAME A ESTE METODO.
        //DESPUES DE LEER EL METODO, LO LLEVAMOS A INDEX
        public IActionResult Delete(int iddepartamento)
        {
            this.repo.DeleteDepartamento(iddepartamento);            
            return RedirectToAction("Index");
        }

        public IActionResult Update(int iddepartamento)
        {
            Departamento departametno = this.repo.FindDepartamento(iddepartamento);
           
            return View(departametno);
        }

        [HttpPost]
        public IActionResult Update(Departamento departamento)
        {
            this.repo.UpdateDepartamento(departamento.IdDepartamento,
                 departamento.Nombre, departamento.Localidad);
            return RedirectToAction("Index");
        }
    }
}

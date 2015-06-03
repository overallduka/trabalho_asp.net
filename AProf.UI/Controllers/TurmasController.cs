using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AProf.Repository;

namespace AProf.UI.Controllers
{
    public class TurmasController : Controller
    {
        //
        // GET: /Turmas/
        public ActionResult Index()
        {
            List<Turma> turmas = TurmaRepository.GetAll();
            return View(turmas);
        }

        //
        // GET: /Turmas/Details/5
        public ActionResult Details(int id)
        {
            var turma = TurmaRepository.Get(id);
            return View(turma);
        }

        //
        // GET: /Turmas/Create
        public ActionResult Create()
        {
            ViewBag.cursos = CursoRepository.GetAll();
            ViewBag.professores = ProfessorRepository.GetAll();
            return View();
        }

        //
        // POST: /Turmas/Create
        [HttpPost]
        public ActionResult Create(Turma turma)
        {
            TurmaRepository.Create(turma);
            return RedirectToAction("Index");
        }

        //
        // GET: /Turmas/Edit/5
        public ActionResult Edit(int id)
        {
            var turma = TurmaRepository.Get(id);
            ViewBag.cursos = CursoRepository.GetAll();
            ViewBag.professores = ProfessorRepository.GetAll();
            return View(turma);
        }

        //
        // POST: /Turmas/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Turma turma)
        {
            TurmaRepository.Update(id, turma);
            return RedirectToAction("index");
        }

        //
        // GET: /Turmas/Delete/5
        public ActionResult Delete(int id)
        {
            TurmaRepository.Delete(id);
            return RedirectToAction("index");
        }

        //
        // POST: /Turmas/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

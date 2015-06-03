using AProf.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AProf.UI.Controllers
{
    public class CursosController : Controller
    {
        //
        // GET: /Cursos/
        public ActionResult Index()
        {
            List<Curso> cursos = CursoRepository.GetAll();
            return View(cursos);
        }

        //
        // GET: /Cursos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Cursos/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Cursos/Create
        [HttpPost]
        public ActionResult Create(Curso curso)
        {
            CursoRepository.Create(curso);
            return RedirectToAction("index");            
        }

        //
        // GET: /Cursos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Cursos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Cursos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Cursos/Delete/5
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

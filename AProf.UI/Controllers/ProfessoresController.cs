using AProf.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AProf.UI.Controllers
{
    public class ProfessoresController : Controller
    {
        //
        // GET: /Professores/
        public ActionResult Index()
        {
            List<Professor> professores = ProfessorRepository.GetAll();
            return View(professores);
        }

        //
        // GET: /Professores/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Professores/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Professores/Create
        [HttpPost]
        public ActionResult Create(Professor professores)
        {
            ProfessorRepository.Create(professores);
            return RedirectToAction("index");
           
        }

        //
        // GET: /Professores/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Professores/Edit/5
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
        // GET: /Professores/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Professores/Delete/5
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

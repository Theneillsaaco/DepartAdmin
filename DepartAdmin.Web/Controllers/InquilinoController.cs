using DepartAdmin.DAL.Entities;
using DepartAdmin.DAL.Interfaces;
using DepartAdmin.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminDepart.Web.Controllers
{
    public class InquilinoController : Controller
    {
        private readonly IDaoInquilino daoInquilino;

        public InquilinoController(IDaoInquilino daoInquilino)
        {
            this.daoInquilino = daoInquilino;
        }


        // GET: InquilinoController
        public ActionResult Index()
        {
            var inquilinos = this.daoInquilino
                                .GetInquilinos()
                                .Select(cd => new InquilinoModel()
                                {
                                    UserId = cd.UserId,
                                    FirstName = cd.FirstName,
                                    LastName = cd.LastName,
                                    Cedula = cd.Cedula,
                                    NumeroDepartamento = cd.NumeroDepartamento,
                                    NumeroTelefonico = cd.NumeroTelefonico,
                                    CreationDate = cd.CreationDate

                                });

            return View(inquilinos);
        }

        // GET: InquilinoController/Details/5
        public ActionResult Details(int Id)
        {
            var inquilino = this.daoInquilino.GetInquilino(Id);

            var modelDepto = new InquilinoModel()
            {
                UserId = inquilino.UserId,
                FirstName = inquilino.FirstName,
                LastName = inquilino.LastName,
                Cedula = inquilino.Cedula,
                NumeroDepartamento = inquilino.NumeroDepartamento,
                NumeroTelefonico = inquilino.NumeroTelefonico,
                CreationDate = inquilino.CreationDate
            };
            return View(modelDepto);
        }

        // GET: InquilinoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InquilinoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InquilinoModel inquilinoModel)
        {
            try
            {
                Inquilino inquilino = new Inquilino()
                {
                    FirstName = inquilinoModel.FirstName,
                    LastName = inquilinoModel.LastName,
                    Cedula = inquilinoModel.Cedula,
                    NumeroDepartamento = inquilinoModel.NumeroDepartamento,
                    NumeroTelefonico = inquilinoModel.NumeroTelefonico,
                    CreationDate = DateTime.Now,
                    CreationUser = 1
                };


                this.daoInquilino.SaveInquilino(inquilino);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InquilinoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InquilinoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InquilinoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InquilinoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
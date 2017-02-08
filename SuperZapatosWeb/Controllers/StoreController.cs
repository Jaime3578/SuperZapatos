using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperZapatosDomain.BussinessLogic;
using SuperZapatosModel;
using SuperZapatosModel.UnitOfWork;
using SuperZapatosWeb.Mappings;
using SuperZapatosWeb.Models;

namespace SuperZapatosWeb.Controllers
{
    public class StoreController : Controller
    {

        private readonly IStoreOperations _storeOperations;
        private readonly IUnitOfWork _unitOfWork;

        public StoreController(IStoreOperations storeOperations)
        {
            _storeOperations = storeOperations;
        }
        //
        // GET: /Store/
        /// <summary>
        /// Return all stores
        /// </summary>
        /// <returns>store</returns>
        public ActionResult Index()
        {
            List<StoreModel> stores = StoreMappings.ToViewEntityList(_storeOperations.GetAll().ToList());
            return View(stores);
        }

        //
        // GET: /Store/Details/5
        /// <summary>
        /// Return detail of store by id
        /// </summary>
        /// <param name="id">id of store</param>
        /// <returns>store object</returns>
        public ActionResult Details(int id)
        {
            StoreModel store = new StoreModel();
            store = StoreMappings.ToViewEntity(_storeOperations.FindById(id));

            return View(store);
        }

        //
        // GET: /Default1/Create
        /// <summary>
        /// Creates a new store
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Store/Create
        /// <summary>
        /// Creates a new store
        /// </summary>
        /// <param name="store">store to insert</param>
        /// <returns>view</returns>
        [HttpPost]
        public ActionResult Create(StoreModel store)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int result = _storeOperations.Insert(StoreMappings.toEntity(store));
                    if (result > 0)
                    {
                        ViewBag.result = "Se ha insertado correctamente!";
                    }
                    else
                    {
                        ViewBag.result = "Ha ocurrido un error";
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Store/Edit/5
        /// <summary>
        /// Updates a store
        /// </summary>
        /// <param name="id">id of a store</param>
        /// <returns>view</returns>
        public ActionResult Edit(int id)
        {
            StoreModel store = new StoreModel();
            store = StoreMappings.ToViewEntity(_storeOperations.FindById(id));
            return View(store);
        }

        //
        // POST: /Store/Edit/5
        /// <summary>
        /// Updates a store
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(StoreModel store)
        {
            try
            {
                _storeOperations.Update(StoreMappings.toEntity(store));

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Store/Delete/5
        /// <summary>
        /// Delete a store
        /// </summary>
        /// <param name="id">id of store</param>
        /// <returns>view</returns>
        public ActionResult Delete(int id)
        {
            StoreModel store = new StoreModel();
            store = StoreMappings.ToViewEntity(_storeOperations.FindById(id));
            return View(store);
        }

        //
        // POST: /Store/Delete/5
        /// <summary>
        /// Deletes a store
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(StoreModel store)
        {
            try
            {
                _storeOperations.Delete(store.id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

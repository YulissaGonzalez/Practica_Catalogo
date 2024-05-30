using Practica_Catalogo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practica_Catalogo.Controllers
{
    public class RolesController : Controller
    {

        // GET: /Roles


        public List<Roles> IndexRoles()
            {
                using (DbModels context = new DbModels())
                {
                    var roles = context.Roles.ToList();
                    return roles;
                }
            }        


        /*public ActionResult IndexRoles()
        {
            using (DbModels context = new DbModels())
            {
                return View(context.Roles.ToList());
            }
        }*/

        // GET: /Roles/Details/5
        public ActionResult Details(int id)
            {
                using (DbModels context = new DbModels())
                {
                    return View(context.Roles.Where(x => x.idRol == id).FirstOrDefault());
                }
            }

            // GET: /Roles/Create
            public ActionResult CreateRol()
            {
                return View();
            }

            // POST: /Roles/Create
            [HttpPost]
            public ActionResult CreateRol(Roles rol)
            {
                try
                {
                    using (DbModels context = new DbModels())
                    {
                        context.Roles.Add(rol);
                        context.SaveChanges();
                    }

                    return RedirectToAction("IndexRoles");
                }
                catch
                {
                    return View();
                }
            }

            // GET: /Roles/Edit/5
            public ActionResult EditRol(int id)
            {
                using (DbModels context = new DbModels())
                {
                    return View(context.Roles.Where(x => x.idRol == id).FirstOrDefault());
                }
            }

            // POST: /Roles/Edit/5
            [HttpPost]
            public ActionResult EditRol(int id, Roles rol)
            {
                try
                {
                    using (DbModels context = new DbModels())
                    {
                        context.Entry(rol).State = EntityState.Modified;
                        context.SaveChanges();
                    }

                    return RedirectToAction("IndexRoles");
                }
                catch
                {
                    return View();
                }
            }

            // GET: Roles/Delete/5
            public ActionResult DeleteRol(int id)
            {
                using (DbModels context = new DbModels())
                {
                    return View(context.Roles.Where(x => x.idRol == id).FirstOrDefault());
                }
            }

            // POST: Roles/Delete/5
            [HttpPost]
            public ActionResult DeleteRol(int id, FormCollection collection)
            {
                try
                {
                    using (DbModels context = new DbModels())
                    {
                        Roles rol = context.Roles.Where(x => x.idRol == id).FirstOrDefault();
                        context.Roles.Remove(rol);
                        context.SaveChanges();
                    }

                    return RedirectToAction("IndexRoles");
                }
                catch
                {
                    return View();
                }
            }
        }
    }

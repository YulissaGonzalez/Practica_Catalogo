using Practica_Catalogo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data;
using System.Net;
using System.Web.ApplicationServices;


namespace Practica_Catalogo.Controllers
{
    [Authorize]
    public class UsuariosController : Controller
    {

        private DbModels db = new DbModels();
        private RolesController rc = new RolesController();
        // GET: Usuarios
        
        public ActionResult IndexUsuarios()
        {

            
            var usuarios = db.Usuarios.Include(u => u.Roles).ToList();
            var roles = db.Roles.ToList();

            ViewBag.Lista = roles;

            return View(usuarios);
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        
        // GET: Usuarios/Create
        public ActionResult CreateUsuario()
        {
            var Lista = rc.IndexRoles();
            ViewBag.Lista = Lista;
            return View();
        }

        
        // POST: Usuarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUsuario([Bind(Include = "id,Nombre,Correo,Contrasena,Curp,Edad,Genero,IdRol")] Usuarios usuario)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //throw new Exception();

                    db.Usuarios.Add(usuario);
                    db.SaveChanges();
                    TempData["SuccessMessage"] = "Usuario agregado con éxito.";
                    return RedirectToAction("IndexUsuarios");
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = " Error al guardar el usuario";
                }
            }

            ViewBag.Roles = rc.IndexRoles();
            return View(usuario);
        
    }
        
        // GET: Usuarios/Edit/5
        public ActionResult EditUsuario(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }

            ViewBag.Lista = rc.IndexRoles();
            return View(usuario);
        }

        
        // POST: Usuarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUsuario([Bind(Include = "id,Nombre,Correo,Contrasena,Curp,Edad,Genero,IdRol")] Usuarios usuario)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //throw new Exception();

                    db.Entry(usuario).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["SuccessMessage"] = "Usuario editado con éxito.";
                    return RedirectToAction("IndexUsuarios");
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = " Error al editar el usuario";
                }
            }
            ViewBag.Lista = rc.IndexRoles();
            return View(usuario);
        }

        
        // GET: Usuarios/Delete/5
        public ActionResult DeleteUsuario(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        
        // POST: Usuarios/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteUsuario(int id, FormCollection collection)
        {
            try
            {
                Usuarios usuario = db.Usuarios.Find(id);
                if (usuario != null)
                {
                    db.Usuarios.Remove(usuario);
                    db.SaveChanges();
                    TempData["SuccessMessage"] = "¡Usuario eliminado con éxito!";
                }
                else
                {
                    TempData["ErrorMessage"] = "Usuario no encontrado.";
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error al eliminar el usuario.";
            }
            return RedirectToAction("IndexUsuarios");
        }
    }
}

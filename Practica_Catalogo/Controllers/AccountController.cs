using Practica_Catalogo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Practica_Catalogo.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        private DbModels db = new DbModels();

        // GET: Account/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            /*if (ModelState.IsValid)
            {
                var user = db.Usuarios.FirstOrDefault(u => u.Correo == model.Correo && u.Contrasena == model.Contrasena);
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.Correo, false);
                    return RedirectToAction("IndexUsuarios", "Usuarios");
                }
                else
                {
                    ModelState.AddModelError("", "Correo electrónico o contraseña incorrectos.");
                }
            }
            return View(model);*/

            if (ModelState.IsValid)
            {
                var user = db.Usuarios.Include("Roles").FirstOrDefault(u => u.Correo == model.Correo && u.Contrasena == model.Contrasena);
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.Correo, false);
                    Session["UserID"] = user.id;
                    Session["UserEmail"] = user.Correo;
                    Session["UserRole"] = user.Roles.Nombre; 
                    return RedirectToAction("IndexUsuarios", "Usuarios");
                }
                else
                {
                    ModelState.AddModelError("", "Correo electrónico o contraseña incorrectos.");
                }
            }
            return View(model);
        }

        // GET: Account/Logout
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}
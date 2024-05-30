using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Practica_Catalogo.Models
{
    public class LoginViewModel
    {
        public string Correo { get; set; }

        [Display(Name = "Contraseña")]
        public string Contrasena { get; set; }
    }
}
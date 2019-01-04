using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SistemaDeRecomendacion.Library;

namespace SistemaDeRecomendacion.Areas.Usuarios.Pages.Registrar
{
    public class RegistrarModel : PageModel
    {
        private LUsuarios _usuarios;
        public void OnGet()
        {
            _usuarios = new LUsuarios();
            ViewData["Roles"] = _usuarios.userData(HttpContext);
        }
    }
}
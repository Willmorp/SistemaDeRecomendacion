using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using SistemaDeRecomendacion.Areas.Principal.Controllers;
using SistemaDeRecomendacion.Library;
using SistemaDeRecomendacion.Models;

namespace SistemaDeRecomendacion.Controllers
{
    public class HomeController : Controller
    {
        private Usuarios _usuarios;
        private SignInManager<IdentityUser> _signInManager; 

        public HomeController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _usuarios = new Usuarios(userManager, signInManager, roleManager);
        }
        //public HomeController(IServiceProvider serviceProvider)
        //{
        //    CreateRoles(serviceProvider);
        //}

        public IActionResult Index()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction(nameof(PrincipalController.Index),"Principal");

            }
            else
            {
                return View();
            }

        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(LoginViewModels model)
        {
            if (ModelState.IsValid)
            {
                List<object[]> listObject = await _usuarios.userLogin(model.Input.Email, model.Input.Password);
                object[] objects = listObject[0];
                var _identityError = (IdentityError)objects[0];
                model.ErrorMessage = _identityError.Description;
                if (model.ErrorMessage.Equals("True"))
                {
                    var data = JsonConvert.SerializeObject(objects[1]);
                    return RedirectToAction(nameof(PrincipalController.Index), "Principal");
                }
                else
                {
                    return View(model);
                }
               
            }

            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            String mensaje;

            try
            {
                var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
                String[] rolesName = { "Admin", "User" };
                foreach (var item in rolesName)
                {
                    var roleExist = await roleManager.RoleExistsAsync(item);
                    if (!roleExist)
                    {
                        await roleManager.CreateAsync(new IdentityRole(item));
                    }
                }
            }
            catch (Exception ex)
            {

                mensaje = ex.Message;
                }
        }
    }
}

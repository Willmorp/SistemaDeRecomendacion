using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaDeRecomendacion.Data;
using SistemaDeRecomendacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeRecomendacion.Library
{
    public class ListObject
    {
        public String description, code;

        public UsersRoles _usersRole;
        public UserData _userData;
        public IdentityError _identityError;
        public ApplicationDbContext _context;
         
        public List<SelectListItem> _userRoles;

        public RoleManager<IdentityRole> _roleManager;
        public UserManager<IdentityUser> _userManager;
        public SignInManager<IdentityUser> _signInManager;

        public List<Object[]> dataList = new List<object[]>();
    }
}

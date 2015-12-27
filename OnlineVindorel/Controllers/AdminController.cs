using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using OnlineVindorel.Models;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Identity;

namespace OnlineVindorel.Controllers
{
    public class AdminController : Controller
    {
        private VindorelDbContext _context;
        private readonly UserManager<Account> _userManager;


        public AdminController(VindorelDbContext context,UserManager<Account> um)
        {
            _context = context;
            _userManager = um;    
        }


    }
}

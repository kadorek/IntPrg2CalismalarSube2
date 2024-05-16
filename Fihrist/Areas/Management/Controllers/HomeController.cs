using Fihrist.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fihrist.Areas.Management.Controllers
{
    [Area("Management")]
    public class HomeController : Controller
    {
        private readonly Fihrist2Context context;
        public HomeController()
        {
            context=new Fihrist2Context();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AssignRoleToUser() {

            var members = context.Members.ToList();//db de bulunan tüm kullanıcılar alındı
            var roles= context.Roles.ToList(); //db bulunan tüm roller alındı

            var selectListMember = new SelectList(members, "Id", "Username");// select elementinde kullanılabilmesi için member listesi düzenlendi
            var selectListRoles = new SelectList(roles, "Id", "Name");// select elementinde kullanılabilmesi için rol listesi düzenlendi

            ViewBag.ListMember=selectListMember; //viewbag aracıyla memeber listesi view e gönderildi
            ViewBag.ListRoles=selectListRoles; //viewbag aracıyla role listesi view e gönderildi


            return View();        
        }


    }
}

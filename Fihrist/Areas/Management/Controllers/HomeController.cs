using Fihrist.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fihrist.Areas.Management.Controllers
{
    [Area("Management")]
    [Authorize]
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

        [HttpPost]
        public IActionResult AssignRoleToUser(RolMember formData) {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("Model hatalı geldi");
                }

                context.RolMembers.Add(formData);
                context.SaveChanges();
                return RedirectToAction("Index", "Home", new { area=""});
            }
            catch (Exception ex)
            {
                return View(formData);
            }

        }

        [AllowAnonymous]
        public IActionResult SerbestAction() {
            return View();
        }


    }
}

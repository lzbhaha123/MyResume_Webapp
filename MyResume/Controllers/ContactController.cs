using Microsoft.AspNetCore.Mvc;
using MyResume.Data;
using MyResume.Models;

namespace MyResume.Controllers
{

    public class ContactController : Controller
    {
        private readonly MyResumeContext _context;
        public ContactController(MyResumeContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public IActionResult LeaveMessage(string fullName, string email, string message)
        {
            
            Message message1 = new Message();
            message1.FullName = fullName;
            message1.Email = email;
            message1.Body = message;
            message1.CreatedAt = DateTime.Now;
            _context.Message.Add(message1);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                ViewData["msg"] = $"<script> window.location.replace('/'); </script>";

                
            }
            finally
            {
                ViewData["msg"] = $"<script> window.location.replace('/'); </script>";

            }

            return View();

        }

    }
}

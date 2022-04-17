using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyResume.Data;
using MyResume.Models;
using System.Diagnostics;

namespace MyResume.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly MyResumeContext _context;

        //public HomeController(ILogger<HomeController> logger)
        public HomeController(MyResumeContext context)
        {
            //_logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            IQueryable<Project> projectIQ = from p in _context.Project select p;
            projectIQ = projectIQ.OrderByDescending(p => p.Id);
            projectIQ = projectIQ.Take(3);
            ViewData["projects"] = projectIQ;

            IQueryable<Article> articleIQ = from a in _context.Article select a;
            articleIQ = articleIQ.OrderByDescending(a => a.Id);
            articleIQ = articleIQ.Take(3);
            ViewData["articles"] = articleIQ;

            IQueryable<Experience> experienceIQ = from e in _context.Experience select e;
            experienceIQ = experienceIQ.OrderByDescending(e => e.Id);
            experienceIQ = experienceIQ.Take(3);
            ViewData["experiences"] = experienceIQ;
            return View();




            /*
            Skill[] skills = new Skill[]
            {
                new Skill
                {
                    Name = "Java",
                    Percentage = 90
                },
                new Skill
                {
                    Name = "Python",
                    Percentage = 95
                },
                new Skill
                {
                    Name = "PHP",
                    Percentage = 90
                },
                new Skill
                {
                    Name = "Mysql",
                    Percentage = 90
                },
                new Skill
                {
                    Name = ".NET",
                    Percentage = 80
                },
                new Skill
                {
                    Name = "Go lang",
                    Percentage = 75
                },
            };
            
            var model = new ListModel();
            //model.SkillModel = await _context.Skill.ToListAsync();
            List<Skill> skills = new List<Skill>();
            skills.Add(new Skill
            {
                Name = "Python",
                Percentage = 95
            });
            skills.Add(new Skill
            {
                Name = "Java",
                Percentage = 95
            });
            skills.Add(new Skill
            {
                Name = "Go lang",
                Percentage = 75
            });
            skills.Add(new Skill
            {
                Name = ".NET",
                Percentage = 80
            });
            model.SkillModel = skills;
            model.ArticleModel = await _context.Article.ToListAsync();
            model.ExperienceModel = await _context.Experience.ToListAsync();
            model.PortfolioModel = await _context.Portfolio.ToListAsync();
            return View(model);*/


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

        public string Test() {
            return "hello world!";
        }
    }
}
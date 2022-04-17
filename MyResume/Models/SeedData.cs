using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyResume.Data;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Bogus;

namespace MyResume.Models
{
    public static class SeedData
    {

        private static List<Message> FakeMessages(int count)
        {

            var messageFaker = new Faker<Message>()
                .RuleFor(m => m.Email, f => f.Person.Email)
                .RuleFor(m => m.FullName, f => f.Person.FullName)
                .RuleFor(m => m.Body, f => f.Lorem.Paragraph())
                .RuleFor(m => m.CreatedAt, f => f.Date.Past());
            return messageFaker.Generate(count);

        }


        private static Skill[] AddSkill()
        {
            return new Skill[]
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
        }

        private static Portfolio[] AddPortfolio()
        {
            return new Portfolio[] { new Portfolio
                {
                Title = "DOCCMS",
                Body = "Doccms is a popular open-source content management system in China. It was established in 2006 and has a history of 15 years. According to incomplete statistics, it has more than 40,000 website users. I am one of the founders and use PHP+Mysql to code the entire system. url: https://www.doccms.com",
                Picture = "/pic/cases/01.png"
                },
                new Portfolio{
                Title = "MaxCMS (JAVA)",
                Body = "Built in 2019, it is a full-featured blog system, which is implemented by SpringBoot + Apache Shiro + Mybatis Plus + Thymeleaf + Bootstrap. I call it MaxCMS. It is a personal project and I have used it to make some simple websites for some businesses.",
                Picture = "/pic/cases/02.png"
                },
                new Portfolio{
                Title = "Interview Questionnaire System",
                Body = "Established in 2020, it is an online exam system for a Chinese company to conduct remote interviews for the company during the COVID-19 period. It is based on PHP + Mysql, which includes my custom template system. On the front end, Bootstrap is used for CSS and JS development. ",
                Picture = "/pic/cases/03.png"
                },
                new Portfolio{
                Title = "Enterprise website management system",
                Body = "Established in 2019, it is another PHP version of CMS, but it is lighter. It uses PHP+SQLite and can be easily deployed to the server without excessive configuration. Of course, it also supports Mysql. The front end uses Bootstrap. This is a personal project. ",
                Picture = "/pic/cases/02.png"
                },
                new Portfolio{
                Title = "WorkLog",
                Body = "Established in 2020, a remote work log reporting system established for a company during the COVID19 period. It is a very simple system, but it is very useful and is used daily by the company. It uses Python + Flask + VUE + VUX + ELEMENTUI technology stack.",
                Picture = "/pic/cases/03.png"
                },
                new Portfolio{
                Title = "Safeheron Website",
                Body = "The project started in May 2021. Safeheron is a blockchain security product of Xuanbing Technology. It is committed to providing customers with more secure digital asset Custody solutions. I am responsible for the front-end part of this project, mainly using VUE to convert design drawings to web pages. It is an exciting project. Under the project confidentiality agreement, could not to display the management panel. ",
                Picture = "/pic/cases/01.png"
                },

        };
        }
        
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MyResumeContext(serviceProvider.GetRequiredService<DbContextOptions<MyResumeContext>>()))
            {

                if (!context.Skill.Any())
                    context.Skill.AddRange(AddSkill());

                if (!context.Portfolio.Any())
                    context.Portfolio.AddRange(AddPortfolio());
                if (!context.Message.Any())
                    context.Message.AddRange(FakeMessages(100));


                context.SaveChanges();
            }
        }
    }
}
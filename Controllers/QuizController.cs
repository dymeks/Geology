using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Geology.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Geology.Controllers
{
    public class QuizController : Controller
    {
        private GeologyContext _context;
 
        public QuizController(GeologyContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("quiz_landingpage")]
        public IActionResult DisplayQuizPage()
        {
            ViewBag.userId = HttpContext.Session.GetInt32("UserId");
            return View("DisplayQuizPage");
        }

        [HttpPost]
        [Route("quizAll")]
        public IActionResult quizAll(int numberOfQuestions)
        {
            List<Rock> rocks = _context.rocks.ToList();
            List<Mineral> minerals = _context.minerals.ToList();

            List<string> imagesNames = new List<string>();
            for(int i = 1; i <= numberOfQuestions; i++)
            {

            }

            return View();

        }
    }

}
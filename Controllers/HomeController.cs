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
    public class HomeController : Controller
    {
        private GeologyContext _context;
 
        public HomeController(GeologyContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.userId = HttpContext.Session.GetInt32("UserId");
            return View();
        }

        [HttpGet]
        [Route("saveFavorites/{mineralId}")]
        public IActionResult saveFavorite(int mineralId)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if(userId.HasValue) {
                UserLikesMineral alreadyLiked = _context.users_like_minerals.SingleOrDefault(likeMineral => likeMineral.UserId == userId.Value && likeMineral.MineralId == mineralId);
                if(alreadyLiked == null)
                {
                    UserLikesMineral favorite = new UserLikesMineral()
                    {
                        UserId = userId.Value,
                        MineralId = mineralId

                    };

                    _context.users_like_minerals.Add(favorite);
                    _context.SaveChanges();
                    
                }
                return Redirect($"/user");

                
            } else {
                TempData["notLoggedIn"] = $"Must be logged in to save favorites!";
                return Redirect($"/mineral/{mineralId}");
            }
        }

        [HttpGet]
        [Route("/user")]
        public IActionResult DisplayProfile()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if(userId.HasValue)
            {
                User currentUser = _context.users.SingleOrDefault(user => user.UserId == userId.Value);
                List<UserLikesMineral> favoriteMinerals = _context.users_like_minerals.Include(likeMineral => likeMineral.Mineral).Where(likeMineral => likeMineral.UserId == userId.Value).ToList();
                ViewBag.user = currentUser;
                ViewBag.favoriteMinerals = favoriteMinerals;
                return View("Profile");
            } else {
                return Redirect("/login_page");
            }
            
        }

        [HttpPost]
        [Route("find_mineral")]
        public IActionResult FindMineral(string mineralName)
        {
            Mineral mineralFound = _context.minerals.SingleOrDefault(mineral => mineral.Name == mineralName);

            if(mineralFound != null) 
            {
                return Redirect($"/mineral/{mineralFound.MineralId}");
            } else {
                ViewBag.error = $"Mineral {mineralName} not found. Please check your spelling.";
                return View();
            }
            
        }

        [HttpGet]
        [Route("rocks")]
        public IActionResult DisplayAllRocks()
        {

            List<Rock> rockFound = _context.rocks.ToList();
            ViewBag.rocks = rockFound;
            return View("DisplayRocks");
            
        }

        [HttpGet]
        [Route("minerals")]
        public IActionResult DisplayAllMinerals()
        {
            List<Mineral> mineralFound = _context.minerals.Include(mineral => mineral.ChemicalFormula).ToList();
            ViewBag.minerals = mineralFound;
            return View("DisplayMinerals");
        }

        [HttpGet]
        [Route("mineral/{mineralId}")]
        public IActionResult DisplayMineral(int mineralId)
        {
            Mineral mineralFound = _context.minerals.Include(mineral => mineral.ChemicalFormula).SingleOrDefault(mineral => mineral.MineralId == mineralId);
            ViewBag.mineral = mineralFound;
            ViewBag.error = TempData["notLoggedIn"];
            return View("DisplayMineral");
        }

        [HttpPost]
        [Route("find_rock")]
        public IActionResult FindRock(string rockName)
        {
            Rock rockFound = _context.rocks.SingleOrDefault(rock => rock.Name == rockName);

            if(rockFound != null) 
            {
                return Redirect($"/rock/{rockFound.RockId}");
            } else {
                ViewBag.error = $"Mineral {rockName} not found. Please check your spelling.";
                return View();
            }
        }

        [HttpGet]
        [Route("rock/{rockId}")]
        public IActionResult DisplayRock(int rockId)
        {
            Rock rockFound = _context.rocks.Include(rock => rock.minerals).ThenInclude(rockmineral => rockmineral.Mineral).SingleOrDefault(rock => rock.RockId == rockId);
            ViewBag.rock = rockFound;
            return View("DisplayRock");
        }

        [HttpGet]
        [Route("registration_page")]
        public IActionResult DisplayRegistration()
        {
            return View("Registration");
        }

        [HttpPost]
        [Route("registration")]
        [ValidateAntiForgeryToken]
        public IActionResult Registration(UserViewModel model, User newUser)
        {
            
            if(ModelState.IsValid)
            {
                
                User exists = _context.users.SingleOrDefault(user => user.Email == newUser.Email);
                if(exists == null){
                    PasswordHasher<User> Hasher = new PasswordHasher<User>();
                    newUser.Password = Hasher.HashPassword(exists, model.Password);
                   
                    _context.users.Add(newUser);
                    _context.SaveChanges();
                    HttpContext.Session.SetInt32("UserId", newUser.UserId);
                    // TempData.name = $"{newUser.FirstName} {newUser.LastName}";
                    return Redirect("/");
                } else {
                    ViewBag.error_exists = "This email already exists in the database. Try Logging in.";
                    return View("Registration");
                }
                
            } else {
                return View("Registration");
            }
            
        }

        [HttpGet]
        [Route("login_page")]
        public IActionResult DisplayLogin()
        {
            return View("Login");
        }

        [HttpPost]
        [Route("login")]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string Email, string Password)
        {
            
            User exists = _context.users.SingleOrDefault(user => user.Email == Email);
            if(exists != null && Password != null)
            {
                var Hasher = new PasswordHasher<User>();
                if(0 != Hasher.VerifyHashedPassword(exists,exists.Password,Password))
                {
                    HttpContext.Session.SetInt32("UserId", exists.UserId);
                    return Redirect("/");
                }
            }
            ViewBag.error = $"Must submit an email and a password";
            return View("Login"); 
            
        }

        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/");
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HYPERION_ASSESSMENT.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using System.Globalization;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Configuration;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HYPERION_ASSESSMENT.Controllers
{
    public class UsersController : Controller
    {
        private readonly CUsersMalcolmDesktopHyperionAssessmentHyperiondevassessmentMdfContext _context;
        private readonly IHttpContextAccessor htcontext;
        public UsersController(CUsersMalcolmDesktopHyperionAssessmentHyperiondevassessmentMdfContext context, HttpContextAccessor _htcontext)
        {
            _context = context;
            htcontext = _htcontext;
        }

        
        
        public async Task<IActionResult> Index(string SearchBy, string Search)
        {


            
            var users = _context.Users.AsQueryable();
            if (SearchBy == "LASTNAME")
            {

                users = users.Where(x => x.Lastname.StartsWith(Search) || Search == null);
            }
            else
            {

                users = users.Where(x => x.Email.Contains(Search) || Search == null);
            }
            
            return View(await users.ToListAsync());
        }
        public IActionResult UserIndex()
        {
            return View();
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        
        public IActionResult Create()
        {
            return View();
        }

         
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,Email,Password,Firstname,Lastname,Phonenumber")] User user)
        {
            if (_context.Users.Any(x=>x.Email==user.Email)) 
            {
                ModelState.AddModelError("Email", "Email Already Exists");
            }
            if (ModelState.IsValid)
            {
               _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,Email,Password,Firstname,Lastname,Phonenumber]")] User user)
        {
            
            if (id != user.UserId)
            {
                return NotFound();
            }
           
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.UserId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
            
        }
       



        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'CUsersMalcolmDesktopHyperionAssessmentHyperiondevassessmentMdfContext.Users'  is null.");
            }
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
       

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                var users = _context.Users.Where(x => x.Email.Equals(user.Email) && x.Password.Equals(user.Password)).FirstOrDefault();

                if (users != null)
                {

                    _context.SaveChanges();

                    var claims = new List<Claim>
                    {

                        new Claim(ClaimTypes.Name, users.Email),

                    };

                    var userRoles = _context.UserRoles.Join(
                        _context.Roles,
                        ur => ur.UsRid,
                        r => r.RoleId,
                        (ur, r) => new
                        {
                            ur.UsRid,
                            r.Rolename,
                            ur.UsId

                        }).Where(x => x.UsId == users.UserId).ToList();
                    foreach (var ur in userRoles)
                    {
                        var roleClaim = new Claim(ClaimTypes.Role, ur.Rolename);
                        claims.Add(roleClaim);

                    }

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties();
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                    return RedirectToAction("DashBoard");
                }
                else
                {
                    ModelState.AddModelError("LoginError", "Either username or password is not correct");
                }

           }
            return View(user);

        }
        [HttpGet]
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("Login");
        }
        public IActionResult DashBoard()
        {
            return View();
        }
    }
}

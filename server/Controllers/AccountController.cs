using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VirtualLeague.Models;
using System.Linq.Dynamic.Core;
using VirtualLeague;

namespace VirtualLeague
{
    public partial class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IWebHostEnvironment env;
        private VirtualLeague.Data.ConDataContext context1;

        public AccountController(IWebHostEnvironment env, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, VirtualLeague.Data.ConDataContext context)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.env = env;
            context1 = context;
        }

        private IActionResult RedirectWithError(string error, string redirectUrl)
        {
             if (!string.IsNullOrEmpty(redirectUrl))
             {
                 return Redirect($"~/Login?error={error}&redirectUrl={Uri.EscapeDataString(redirectUrl)}");
             }
             else
             {
                 return Redirect($"~/Login?error={error}");
             }
        }

        [HttpPost]
        public async Task<IActionResult> Login(string userName, string password, string redirectUrl)
        {
            if (env.EnvironmentName == "Development" && userName == "admin" && password == "admin")
            {
                var claims = new List<Claim>()
                {
                        new Claim(ClaimTypes.Name, "admin"),
                        new Claim(ClaimTypes.Email, "admin")
                };

                roleManager.Roles.ToList().ForEach(r => claims.Add(new Claim(ClaimTypes.Role, r.Name)));
                await signInManager.SignInWithClaimsAsync(new ApplicationUser { UserName = userName, Email = userName }, isPersistent: false, claims);

                return Redirect($"~/{redirectUrl}");
            }

            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {

                var result = await signInManager.PasswordSignInAsync(userName, password, false, false);

                if (result.Succeeded)
                {
                    return Redirect($"~/{redirectUrl}");
                }
            }

            return RedirectWithError("Invalid user or password", redirectUrl);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(string userName, string password,string firstName,string lastName,string whatsappnumber,string photo)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                return Redirect("~/Login?error=Invalid user or password");
            }

            var user = new ApplicationUser { UserName = userName, Email = userName , FirstName=firstName, LastName=lastName, WhatsAppNumber=whatsappnumber, Photo=photo};

            var result = await userManager.CreateAsync(user, password);

            if (result.Succeeded)//user creation is successful
            {
                var newlyCreatedUser=context1.AspNetUsers.FirstOrDefault(p=>p.UserName==user.UserName);
                if(newlyCreatedUser!=null)
                {
                    newlyCreatedUser.FirstName = user.FirstName;
                    newlyCreatedUser.LastName=user.LastName;
                    newlyCreatedUser.WhatsAppNumber = whatsappnumber;
                    newlyCreatedUser.Photo = photo;
                    string defaultRole = ApplicationConstants.DEFAULT_ROLE;

                    var userRole = context1.AspNetRoles.FirstOrDefault(p => p.Name == defaultRole);
                    if(userRole!=null)
                    {
                        context1.AspNetUserRoles.Add(new Models.ConData.AspNetUserRole { RoleId = userRole.Id, UserId = newlyCreatedUser.Id });
                    }

                    await context1.SaveChangesAsync();

                    
                }
                await signInManager.SignInAsync(user, isPersistent: false);
                return Redirect("~/");
            }

            var message = string.Join(", ", result.Errors.Select(error => error.Description));

            return Redirect($"~/Login?error={message}");
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ChangePassword(string oldPassword, string newPassword)
        {
            if (oldPassword == null || newPassword == null)
            {
                return Redirect($"~/Profile?error=Invalid old or new password");
            }

            var id = this.HttpContext.User.FindFirst("sub").Value;

            var user = await userManager.FindByIdAsync(id);

            var result = await userManager.ChangePasswordAsync(user, oldPassword, newPassword);

            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: true);

                return Redirect("~/");
            }

            var message = string.Join(", ", result.Errors.Select(error => error.Description));

            return Redirect($"~/Profile?error={message}");
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return Redirect("~/");
        }
    }
}

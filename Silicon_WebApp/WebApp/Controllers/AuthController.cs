using Infrastructure.Context;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class AuthController(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager, ApplicationContext context) : Controller
{
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly SignInManager<UserEntity> _signInManager = signInManager;
    private readonly ApplicationContext _context = context;

    [Route("/signup")]
    public IActionResult SignUp()
    {
        return View();
    }


    [HttpPost]
    [Route("/signup")]
    public async Task<IActionResult> SignUp(SignUpViewModel model)
    {
        if (ModelState.IsValid)
        {
            if (!await _context.Users.AnyAsync(x => x.Email == model.Email))
            {
                var userEntity = new UserEntity
                {
                    Email = model.Email,
                    UserName = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                };

                if ((await _userManager.CreateAsync(userEntity, model.Password)).Succeeded)
                {
                    if ((await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false)).Succeeded)
                    {
                        return LocalRedirect("/");
                    }
                    else
                    {
                        return LocalRedirect("/signin");
                    }
                }
                else
                {
                    ViewData["StatusMessage"] = "Something went wrong. Try again later or contact customer service";
                }
            }
            else
            {
                ViewData["StatusMessage"] = "User with same email already exists";
            }
        }

        return View(model);
    }

    [Route("/signin")]
    public IActionResult SignIn(string returnUrl)
    {
        ViewData["ReturnUrl"] = returnUrl ?? "/account/details";
        return View();
    }


    [HttpPost]
    [Route("/signin")]
    public async Task<IActionResult> SignIn(SignInViewModel model, string returnUrl)
    {
        if (ModelState.IsValid)
        {
            if ((await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.IsPresistent, false)).Succeeded)
            {
                return LocalRedirect(returnUrl);
            }

        }
        ViewData["ReturnUrl"] = returnUrl ?? "/account/details"; ;
        ViewData["StatusMessage"] = "Incorrect Email or Password";
        return View(model);
    }

    [Route("/signout")]
    public new async Task<IActionResult> SignOut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Home", "Default");
    }
}

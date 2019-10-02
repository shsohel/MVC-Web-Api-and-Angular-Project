﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobCoreApi.Models;
using JobCoreApi.Models.AccountViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace JobCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountApiController : ControllerBase
    {
        public class AccountController : Controller
        {
            private readonly UserManager<ApplicationUser> _userManager;
            private readonly SignInManager<ApplicationUser> _signInManager;
            private readonly ILogger _logger;

            public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ILogger<AccountController> logger)
            {
                _userManager = userManager;
                _signInManager = signInManager;
                _logger = logger;
            }

            public IActionResult Index()
            {
                return View();
            }

            private void AddErrors(IdentityResult result)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            private IActionResult RedirectToLocal(string returnUrl)
            {
                if (Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return Ok();
                }
            }

            [HttpGet]
            [AllowAnonymous]
            public IActionResult Register(string returnUrl = null)
            {
                ViewData["ReturnUrl"] = returnUrl;
                return View();
            }

            [HttpPost]
            [AllowAnonymous]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
            {
                ViewData["ReturnUrl"] = returnUrl;
                if (ModelState.IsValid)
                {
                    var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                    var result = await _userManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        _logger.LogInformation("User Created a new account with password.");

                        await _signInManager.SignInAsync(user, isPersistent: false);
                        _logger.LogInformation("User Created a new account with password.");
                        return RedirectToLocal(returnUrl);
                    }
                    AddErrors(result);
                }
                return View(model);
            }

            [HttpGet]
            [AllowAnonymous]
            public async Task<IActionResult> Login(string returnUrl = null)
            {
                await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

                ViewData["ReturnUrl"] = returnUrl;
                return View();
            }

            [HttpPost]
            [AllowAnonymous]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
            {
                ViewData["ReturnUrl"] = returnUrl;
                if (ModelState.IsValid)
                {
                    var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                    if (result.Succeeded)
                    {
                        _logger.LogInformation("User logged in.");
                        return RedirectToLocal(returnUrl);
                    }
                    if (result.IsLockedOut)
                    {
                        _logger.LogWarning("User account locked out.");
                        return RedirectToAction(nameof(Lockout));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                        return View(model);
                    }
                }

                return View(model);
            }
            [Route("")]
            [HttpGet]
            [AllowAnonymous]
            public IActionResult Lockout()
            {
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Logout()
            {
                await _signInManager.SignOutAsync();
                _logger.LogInformation("User logged out.");
                return Ok();
            }

        }

    }
}
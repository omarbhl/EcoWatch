// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TP3_EcoWatch.Models;
using Microsoft.AspNetCore.Http;

namespace TP3_EcoWatch.Areas.Identity.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ILogger<LogoutModel> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LogoutModel(SignInManager<AppUser> signInManager, ILogger<LogoutModel> logger, IHttpContextAccessor httpContextAccessor)
        {
            _signInManager = signInManager;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");

            // Clear session upon logout
            _httpContextAccessor.HttpContext.Session.Clear();

            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                // This needs to be a redirect so that the browser performs a new
                // request and the identity for the user gets updated.
                return RedirectToPage();
            }
        }

        // Method to handle session expiration
        public IActionResult OnGet()
        {
            // Clear session upon session expiration
            _httpContextAccessor.HttpContext.Session.Clear();

            // Sign out user
            _signInManager.SignOutAsync().Wait();
            _logger.LogInformation("User logged out due to session expiration.");

            // Redirect to logout page
            return RedirectToPage("/Identity/Account/Logout");
        }
    }
}

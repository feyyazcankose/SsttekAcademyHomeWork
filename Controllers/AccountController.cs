using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SsttekAcademyHomeWork.Models.Services.Accounts;
using SsttekAcademyHomeWork.Models.ViewModels.Auth;

namespace SsttekAcademyHomeWork.Controllers;

[Authorize]
public class AccountController : Controller
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpGet]
    public async Task<IActionResult> EditProfile()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var result = await _accountService.GetProfileAsync(userId);
      
        return View(result.Data);
    }

    [HttpPost]
    public async Task<IActionResult> EditProfile(AccountViewModel model)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (ModelState.IsValid)
        {
            var result = await _accountService.UpdateProfileAsync(userId, model);

            if (result.Success)
            {
                TempData["Success"] = result.Message;
                return RedirectToAction("EditProfile");
            }

            ModelState.AddModelError("", result.Message);
        }

        return View(model);
    }

    [HttpGet]
    public IActionResult ChangePassword()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (ModelState.IsValid)
        {
            var result = await _accountService.ChangePasswordAsync(userId, model);

            if (result.Success)
            {
                TempData["Success"] = result.Message;
                return RedirectToAction("EditProfile");
            }

            ModelState.AddModelError("", result.Message);
        }

        return View(model);
    }
}
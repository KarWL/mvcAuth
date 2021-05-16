using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using mvcApp.Data;
using mvcApp.Models;

namespace mvcApp.Controllers
{
    public class PropertyInfoController : Controller
    {
        public struct loginInInfo
        {
            public bool isLogin { get; set; }

            public string userId { get; set; }
        }

        private readonly ApplicationDbContext _context;

        public virtual ClaimsPrincipal LoginUser { get; }

        public string ReturnUrl { get; set; }

        public PropertyInfoController(ApplicationDbContext context)
        {
            _context = context;
        }
        public loginInInfo isUserLogin()
        {
            loginInInfo loginInfo = new loginInInfo();
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var isUserLogin = currentUser.Identity.IsAuthenticated;
            if (!isUserLogin)
            {
                loginInfo.isLogin = false;
                loginInfo.userId = null;
            }

            if (isUserLogin)
            {
                var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
                loginInfo.isLogin = true;
                loginInfo.userId = currentUserID;
            }

            return loginInfo;
        }

        public JsonResult CreatePropertyInfo(string Name, string Type, string Description, string UserId)
        {
            PropertyInfo propertyInfo = new PropertyInfo();
            propertyInfo.AssetName = Name;
            propertyInfo.AssetType = Type;
            propertyInfo.Description = Description;
            propertyInfo.UserId = UserId;

            var user = _context.Users.FirstOrDefault(m => m.Id == UserId);
            propertyInfo.User = user;

            _context.Add(propertyInfo);
            _context.SaveChanges();

            return Json(null);
        }

        //home page
        public IActionResult Index()
        {
            return View();
        }

        //user page 
        public async Task<IActionResult> Users()
        {
            return View(await _context.Users.ToListAsync());
        }

        //create page
        public async Task<IActionResult> Create(string id)
        {
            loginInInfo createCheckLogin = isUserLogin();
            ReturnUrl ??= Url.Content("/Identity/Account/Login");

            if (!createCheckLogin.isLogin)
            {
                return LocalRedirect(ReturnUrl);
            }

            if (id == null)
            {
                return NotFound();
            }
            var data = await _context.Users
            .Include(x => x.PropertyInfos)
            .FirstOrDefaultAsync(m => m.Id == id);

            if (data == null)
            {
                Response.StatusCode = 404;
                return View("ErrorPage", id);
            }

            return View(data);
        }

        //edit page
        public async Task<IActionResult> Edit(Guid id)
        {
            //reroute back to homepage.
            loginInInfo editCheckLogin = isUserLogin();
            ReturnUrl ??= Url.Content("/Identity/Account/Login");

            if (!editCheckLogin.isLogin)
            {
                return LocalRedirect(ReturnUrl);
            }

            if (editCheckLogin.userId == null)
            {
                return NotFound();
            }

            var data = await _context.PropertyInfo
                    .FirstOrDefaultAsync(m => m.Id == id);

            if (data == null)
            {
                Response.StatusCode = 404;
                return View("ErrorPage", id);
            }

            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            loginInInfo postEditCheckLogin = isUserLogin();
            ReturnUrl ??= Url.Content("/Identity/Account/Login");

            if (!postEditCheckLogin.isLogin)
            {
                return LocalRedirect(ReturnUrl);
            }

            if (postEditCheckLogin.userId == null)
            {
                return NotFound();
            }

            var propertyToUpdate = await _context.PropertyInfo
            .Include(i => i.User)
            .FirstOrDefaultAsync(s => s.Id == id && s.UserId == postEditCheckLogin.userId);

            if (propertyToUpdate == null)
            {
                Response.StatusCode = 404;
                return View("ErrorPage", id.Value);
            }

            if (await TryUpdateModelAsync<PropertyInfo>(propertyToUpdate, "", i => i.AssetName, i => i.AssetType, i => i.Description))
            {
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
                return RedirectToAction("Details");

            }
            return RedirectToAction("Details");
        }
        public async Task<IActionResult> Delete(Guid? id, bool? saveChangesError = false)
        {
            loginInInfo deleteCheckLogin = isUserLogin();
            ReturnUrl ??= Url.Content("/Identity/Account/Login");

            if (!deleteCheckLogin.isLogin)
            {
                return LocalRedirect(ReturnUrl);
            }

            if (deleteCheckLogin.userId == null)
            {
                return NotFound();
            }

            if (id == null)
            {
                return NotFound();
            }
            var data = await _context.PropertyInfo
                    .FirstOrDefaultAsync(m => m.Id == id);

            if (data == null)
            {
                Response.StatusCode = 404;
                return View("ErrorPage", id.Value);
            }

            return View(data);
        }

        //if can trgger this action and can navigate back to the users page

        [HttpPost, ActionName("Delete")]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            loginInInfo postDeleteCheckLogin = isUserLogin();
            ReturnUrl ??= Url.Content("/Identity/Account/Login");

            if (!postDeleteCheckLogin.isLogin)
            {
                return LocalRedirect(ReturnUrl);
            }

            if (postDeleteCheckLogin.userId == null)
            {
                return NotFound();
            }
            var asset = await _context.PropertyInfo.FirstOrDefaultAsync(x=>x.Id == id && x.UserId == postDeleteCheckLogin.userId);
            if (asset == null)
            {
                return RedirectToAction(nameof(Details));
            }

            try
            {
                _context.PropertyInfo.Remove(asset);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details));
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }


        //details page
        public async Task<IActionResult> Details(string ReturnUrl)
        {
            //reroute back to homepage.
            ReturnUrl ??= Url.Content("/Identity/Account/Login");

            loginInInfo checkLogin = isUserLogin();

            if (!checkLogin.isLogin)
            {
                return LocalRedirect(ReturnUrl);
            }

            if (checkLogin.userId == null)
            {
                return NotFound();
            }


            var data = await _context.Users
            .Include(x => x.PropertyInfos)
            .FirstOrDefaultAsync(m => m.Id == checkLogin.userId);

            if (data == null)
            {
                Response.StatusCode = 404;
                return View("ErrorPage", checkLogin.userId);
            }

            return View(data);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}

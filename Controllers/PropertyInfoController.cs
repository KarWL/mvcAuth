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
        private readonly ApplicationDbContext _context;

        public virtual ClaimsPrincipal LoginUser { get; }

        public string ReturnUrl { get; set; }

        public PropertyInfoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public JsonResult CreatePropertyInfo(string Name, string Type, string Description, string UserId)
        {
            PropertyInfo propertyInfo = new PropertyInfo();
            propertyInfo.AssetName = Name;
            propertyInfo.AssetType = Type;
            propertyInfo.Description = Description;
            propertyInfo.UserId = UserId;

            var user = _context.Users.FirstOrDefault(m => m.Id == UserId);

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
            ReturnUrl ??= Url.Content("/Identity/Account/Login");

            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var isUserLogin = currentUser.Identity.IsAuthenticated;
            if (!isUserLogin)
            {
                return LocalRedirect(ReturnUrl);
            }
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (currentUserID == null)
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
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,AssetName,AssetType,Description, UserId")] PropertyInfo propertyInfo)
        {          
            if (id != propertyInfo.Id)
            {
                return NotFound();
            }

            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var isUserLogin = currentUser.Identity.IsAuthenticated;
            if (!isUserLogin)
            {
                return LocalRedirect(ReturnUrl);
            }
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (currentUserID == null || propertyInfo.UserId != currentUserID)
            {
                return NotFound();
            }

            ApplicationUser user = _context.ApplicationUser.FirstOrDefault(x=>x.Id == currentUserID);
            propertyInfo.User = user;

            var data = await _context.PropertyInfo
                    .FirstOrDefaultAsync(m => m.Id == id);

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(propertyInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                }
                return RedirectToAction("Details");
            }
            return View(propertyInfo);
        }
        public async Task<IActionResult> Delete(Guid? id, bool? saveChangesError = false)
        {

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
            var asset = await _context.PropertyInfo.FindAsync(id);
            if (asset == null)
            {
                return RedirectToAction(nameof(Users));
            }

            try
            {
                _context.PropertyInfo.Remove(asset);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Users));
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

            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var isUserLogin = currentUser.Identity.IsAuthenticated;
            if (!isUserLogin)
            {
                return LocalRedirect(ReturnUrl);
            }
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (currentUserID == null)
            {
                return NotFound();
            }
            var data = await _context.Users
            .Include(x => x.PropertyInfos)
            .FirstOrDefaultAsync(m => m.Id == currentUserID);

            if (data == null)
            {
                Response.StatusCode = 404;
                return View("ErrorPage", currentUserID);
            }

            return View(data);
        }

        // public IActionResult Create()
        // {
        //     return View();
        // }

        //error
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

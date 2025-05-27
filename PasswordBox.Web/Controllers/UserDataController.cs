using Microsoft.AspNetCore.Mvc;
using PasswordBox.Web.Data;
using PasswordBox.Web.Models.Data;
using PasswordBox.Web.Models.ViewModels;
using System;
using System.Linq;
using System.Security.Claims;  

namespace PasswordBox.Web.Controllers
{
    public class UserDataController : Controller
    {
        private readonly PasswordDbContext passwordDbContext;

        public UserDataController(PasswordDbContext passwordDbContext)
        {
            this.passwordDbContext = passwordDbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Add")]
        public IActionResult Add(AddDataRequest addDataRequest)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                
                return RedirectToAction("Login", "Account");
            }

            var dataRecord = new DataRecord
            {
                WebsiteName = addDataRequest.WebsiteName,
                UserName = addDataRequest.UserName,
                Password = addDataRequest.Password,
                UserId = userId   
            };

            passwordDbContext.Records.Add(dataRecord);
            passwordDbContext.SaveChanges();

            return RedirectToAction("List");
        }

        [HttpGet]
        [ActionName("List")]
        public IActionResult List()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var dataRecords = passwordDbContext.Records
                .Where(r => r.UserId == userId)
                .ToList();

            return View(dataRecords);
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var record = passwordDbContext.Records
                .FirstOrDefault(x => x.Id == id && x.UserId == userId);

            if (record != null)
            {
                var editDataRequest = new EditDataRequest
                {
                    Id = record.Id,
                    WebsiteName = record.WebsiteName,
                    UserName = record.UserName,
                    Password = record.Password
                };
                return View(editDataRequest);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(EditDataRequest editDataRequest)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var record = passwordDbContext.Records
                .FirstOrDefault(x => x.Id == editDataRequest.Id && x.UserId == userId);

            if (record != null)
            {
                record.WebsiteName = editDataRequest.WebsiteName;
                record.UserName = editDataRequest.UserName;
                record.Password = editDataRequest.Password;
                passwordDbContext.SaveChanges();
                return RedirectToAction("List");
            }

            return RedirectToAction("Edit", new { id = editDataRequest.Id });
        }

        [HttpPost]
        public IActionResult Delete(EditDataRequest editDataRequest)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var record = passwordDbContext.Records
                .FirstOrDefault(x => x.Id == editDataRequest.Id && x.UserId == userId);

            if (record != null)
            {
                passwordDbContext.Records.Remove(record);
                passwordDbContext.SaveChanges();

                return RedirectToAction("List");
            }
            return RedirectToAction("Edit", new { id = editDataRequest.Id });
        }
    }
}

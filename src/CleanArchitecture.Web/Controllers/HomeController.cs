using CleanArchitecture.Core.Entities;
using CleanArchitecture.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CleanArchitecture.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var guestbook = new Guestbook() { Name = "My Guestbook" };
            guestbook.Entries.Add(new GuestbookEntry() { EmailAddress = "vlad@google.com", Message = "hi  I am Vlad", DateTimeCreated = DateTime.UtcNow.AddHours(4) });
            guestbook.Entries.Add(new GuestbookEntry() { EmailAddress = "ada@hotmail.com", Message = "hi from Ada", DateTimeCreated = DateTime.UtcNow.AddHours(5) });
            guestbook.Entries.Add(new GuestbookEntry() { EmailAddress = "adam@mitic.net", Message = "hi Adam!", DateTimeCreated = DateTime.UtcNow.AddDays(4) });
            guestbook.Entries.Add(new GuestbookEntry() { EmailAddress = "Patricia@mitic.net", Message = "hi Pat!" });

            var viewModel = new HomePageViewModel();
            viewModel.GuestBookName = guestbook.Name;
            viewModel.PreviousEntries.AddRange(guestbook.Entries);
            return View(viewModel);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}

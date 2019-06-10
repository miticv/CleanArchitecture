﻿using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CleanArchitecture.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository _repository;

        public HomeController(IRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            if (!_repository.List<Guestbook>().Any())
            {
                var newGuestbook = new Guestbook() { Name = "My Guestbook" };
                newGuestbook.Entries.Add(new GuestbookEntry() { EmailAddress = "vlad@google.com", Message = "hi  I am Vlad", DateTimeCreated = DateTime.UtcNow.AddHours(4) });
                newGuestbook.Entries.Add(new GuestbookEntry() { EmailAddress = "ada@hotmail.com", Message = "hi from Ada", DateTimeCreated = DateTime.UtcNow.AddHours(5) });
                newGuestbook.Entries.Add(new GuestbookEntry() { EmailAddress = "adam@mitic.net", Message = "hi Adam!", DateTimeCreated = DateTime.UtcNow.AddDays(4) });
                newGuestbook.Entries.Add(new GuestbookEntry() { EmailAddress = "Patricia@mitic.net", Message = "hi Pat!" });
                _repository.Add(newGuestbook);
            }

            var guestbook = _repository.GetById<Guestbook>(1); // hardcoded for this sample; could support multi-tenancy in real app
            List<GuestbookEntry> guestbookEntries = _repository.List<GuestbookEntry>();
            guestbook.Entries.Clear(); // remove in-memory Guestbook Entries
            guestbook.Entries.AddRange(guestbookEntries); // Fetch Entries from database.

            var viewModel = new HomePageViewModel();
            viewModel.GuestBookName = guestbook.Name;
            viewModel.PreviousEntries.AddRange(guestbook.Entries);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(HomePageViewModel model)
        {
            if (ModelState.IsValid)
            {
                var guestbook = _repository.GetById<Guestbook>(1);
                List<GuestbookEntry> guestbookEntries = _repository.List<GuestbookEntry>();
                guestbook.Entries.Clear();
                guestbook.Entries.AddRange(guestbookEntries); // maintain existing Guestbook Entries

                guestbook.AddEntry(model.NewEntry);
                _repository.Update(guestbook);

                model.PreviousEntries.Clear();
                model.PreviousEntries.AddRange(guestbook.Entries);
            }
            return View(model);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}

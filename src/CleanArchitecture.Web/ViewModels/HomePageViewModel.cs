using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Core.Entities;

namespace CleanArchitecture.Web.ViewModels
{
    public class HomePageViewModel
    {
        public string GuestBookName { set; get; }
        public List<GuestbookEntry> PreviousEntries { get; } = new List<GuestbookEntry>();
    }
}

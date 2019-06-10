using CleanArchitecture.Core.Events;
using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities
{
    public class Guestbook: BaseEntity 
    {
        public string Name { set; get; }
        public List<GuestbookEntry> Entries { set; get; } = new List<GuestbookEntry>();

        public void AddEntry(GuestbookEntry entry)
        {
            Entries.Add(entry);
            Events.Add(new EntryAddedEvent(this.Id, entry));
        }
    }
}

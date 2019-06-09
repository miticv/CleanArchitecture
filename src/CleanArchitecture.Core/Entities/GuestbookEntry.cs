using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities
{
    public class GuestbookEntry: BaseEntity
    {
        public string EmailAddress { set; get; }
        public string Message { set; get; }
        public DateTimeOffset DateTimeCreated { get; set; } = DateTime.UtcNow;
    }
}

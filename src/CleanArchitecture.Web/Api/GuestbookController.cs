using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Web.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Web.Api
{

    [VerifyGuestbookExists]
    public class GuestbookController : BaseApiController
    {

        private readonly IRepository _repository;

        public GuestbookController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Guestbook/1
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var guestbook = _repository.GetById<Guestbook>(id);
            //if (guestbook == null)
            //{
            //    return NotFound(id);
            //}
            var entries = _repository.List<GuestbookEntry>();
            guestbook.Entries.Clear();
            guestbook.Entries.AddRange(entries);
            return Ok(guestbook);
        }

        // GET: api/Guestbook/1
        [HttpPost("{id:int}/NewEntry")]
        public IActionResult NewEntry(int id, [FromBody] GuestbookEntry guestbookEntry)
        {
            var guestbook = _repository.GetById<Guestbook>(id);
            //if (guestbook == null)
            //{
            //    return NotFound(id);
            //}
            var entries = _repository.List<GuestbookEntry>();
            guestbook.Entries.Clear();
            guestbook.Entries.AddRange(entries);
            guestbook.AddEntry(guestbookEntry);
            _repository.Update(guestbook);

            return Ok(guestbook);
        }
    }
}

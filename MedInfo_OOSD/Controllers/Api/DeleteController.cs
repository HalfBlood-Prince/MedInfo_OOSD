using System;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using MedInfo_OOSD.Core.Domain;
using MedInfo_OOSD.Dtos;
using MedInfo_OOSD.Persistence;

namespace MedInfo_OOSD.Controllers.Api
{
    public class DeleteController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public DeleteController()
        {
            _context = ApplicationDbContext.Create();
        }


        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }


        [HttpDelete]
        public IHttpActionResult DeleteComment(int id)
        {
            var comment = _context.Comments.SingleOrDefault(c => c.Id == id);

            if (comment == null)
                return NotFound();

            var dto = Mapper.Map<Comment, CommentDto>(comment);

            _context.Comments.Remove(comment);
            _context.SaveChanges();

            return Ok(dto);
        }
    }
}

using System;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using MedInfo_OOSD.Core.Domain;
using MedInfo_OOSD.Dtos;
using MedInfo_OOSD.Persistence;

namespace MedInfo_OOSD.Controllers.Api
{
    public class DoctorsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public DoctorsController()
        {
            _context = ApplicationDbContext.Create();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();

            base.Dispose(disposing);
        }


        [HttpDelete]
        public IHttpActionResult DeleteDoctor(Guid id)
        {
            var doctor = _context.Doctors.SingleOrDefault(d => d.Id == id);

            if (doctor == null)
                return NotFound();

            var doctorDto = Mapper.Map<Doctor, DoctorDto>(doctor);

            _context.Doctors.Remove(doctor);
            _context.SaveChanges();

            return Ok(doctorDto);
        }
    }
}

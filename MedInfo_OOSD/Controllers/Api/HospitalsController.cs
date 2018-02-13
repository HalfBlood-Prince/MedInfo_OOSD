using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using MedInfo_OOSD.Core.Domain;
using MedInfo_OOSD.Dtos;
using MedInfo_OOSD.Persistence;

namespace MedInfo_OOSD.Controllers.Api
{
    public class HospitalsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public HospitalsController()
        {
            _context = ApplicationDbContext.Create();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }


        [HttpDelete]
        public IHttpActionResult DeleteHospital(Guid id)
        {
            var hospital = _context.Hospitals.Include(h => h.Speciality).SingleOrDefault(h => h.Id == id);

            if (hospital == null)
                return NotFound();

            var hospitaDto = Mapper.Map<Hospital, HospitalDto>(hospital);

            _context.Hospitals.Remove(hospital);
            _context.SaveChanges();

            return Ok(hospitaDto);
        }
    }
}

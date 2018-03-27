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





        // DELETE: /api/Hospitals/id
        /// <summary>
        ///     This action takes an id and delete a 
        ///     Hospital coresponding to that id.
        /// </summary>
        /// <param name="id"> Parameter of this action is an guid id. </param>
        /// <returns>it returns an deleted Hospital object in form of a dto</returns>
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



        //
        // PUT: /api/Hospitals/id
        /// <summary>
        ///     This action takes an id and approve a 
        ///     hospital coresponding to that id.
        /// </summary>
        /// <param name="id"> Parameter of this action is an guid id.</param>
        /// <returns> it returns an updated hospital object in form of a dto </returns>
        [HttpPut]
        public IHttpActionResult ApproveHospital(Guid id)
        {
            var hospital = _context.Hospitals.SingleOrDefault(h => h.Id == id);

            if (hospital == null)
                return NotFound();

            hospital.IsApproved = true;
            _context.SaveChanges();

            return Ok(Mapper.Map<Hospital, HospitalDto>(hospital));
        }
    }
}

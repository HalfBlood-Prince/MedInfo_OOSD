using System;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using MedInfo_OOSD.Core.Domain;
using MedInfo_OOSD.Dtos;
using MedInfo_OOSD.Persistence;

namespace MedInfo_OOSD.Controllers.Api
{
    public class BanksController : ApiController
    {
        private readonly ApplicationDbContext _context;


        public BanksController()
        {
            _context = ApplicationDbContext.Create();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }


        public IHttpActionResult DeleteBank(Guid id)
        {
            var bank = _context.BloodBanks.SingleOrDefault(b => b.Id == id);

            if (bank == null)
                return NotFound();


            var dto = Mapper.Map<BloodBank, BloodBankDto>(bank);

            _context.BloodBanks.Remove(bank);
            _context.SaveChanges();

            return Ok(dto);
        }




        public IHttpActionResult Approve(Guid id)
        {
            var bank = _context.BloodBanks.SingleOrDefault(d => d.Id == id);

            if (bank == null)
                return NotFound();

            var bloodBankDto = Mapper.Map<BloodBank, BloodBankDto>(bank);

            _context.BloodBanks.Remove(bank);
            _context.SaveChanges();

            return Ok(bloodBankDto);
        }
    }
}

using System.Collections.Generic;

namespace MedInfo_OOSD.Core.Domain
{
    public class Speciality
    {
        public short Id { get; set; }

        public string Name { get; set; }

        public IList<Doctor> Doctors { get; set; }
    }
}
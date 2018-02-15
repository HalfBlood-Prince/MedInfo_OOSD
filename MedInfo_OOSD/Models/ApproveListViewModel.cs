using System.Collections.Generic;
using MedInfo_OOSD.Core.Domain.Interface;

namespace MedInfo_OOSD.Models
{
    public class ApproveListViewModel
    {
        public IEnumerable<IEntity> Entities { get; set; }

        public string Action { get; set; }

        public string Controller { get; set; }

        public string Api { get; set; }
    }
}
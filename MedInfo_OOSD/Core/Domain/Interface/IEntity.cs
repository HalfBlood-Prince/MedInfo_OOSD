using System;

namespace MedInfo_OOSD.Core.Domain.Interface
{
    public interface IEntity
    {
        Guid Id { get; set; }

        string Name { get; set; }

        string Email { get; set; }

    }
}
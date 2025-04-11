using MediatR;
using PatientManagementSystem.Application.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementSystem.Application.Quries
{
    public record PatientByIdQuery(Guid id) : IRequest<PatientResDto>;
}

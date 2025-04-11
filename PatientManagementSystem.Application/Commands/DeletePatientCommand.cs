using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementSystem.Application.Commands
{
    public record DeletePatientCommand(Guid id): IRequest<string>;
}

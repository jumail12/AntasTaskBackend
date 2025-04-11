using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementSystem.Application.Commands
{
    public record UpdatePatientCommand : IRequest<string>
    {
        public Guid PatientId { get; set; }
        public string? Name { get; set; }
        public DateTime? DOB { get; set; }
        public string? Phone { get; set; }
    }
}

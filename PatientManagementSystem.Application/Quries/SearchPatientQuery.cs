using MediatR;
using PatientManagementSystem.Application.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementSystem.Application.Quries
{
    public record SearchPatientQuery() : IRequest<PatientPaginationResDto>
    {
        public  int pageNumber { get; set; }
        public int pageSize { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
        public string? Phone { get; set; }
    }
}

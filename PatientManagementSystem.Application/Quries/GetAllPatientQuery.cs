using MediatR;
using PatientManagementSystem.Application.Common.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementSystem.Application.Quries
{
    public record GetAllPatientQuery(int pageNumber, int pageSize) : IRequest<PatientPaginationResDto>;
}

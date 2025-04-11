using MediatR;
using PatientManagementSystem.Application.Common.DTOs;
using PatientManagementSystem.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementSystem.Application.Quries.Handler
{
   
    public class PatientByIdQueryHandler : IRequestHandler<PatientByIdQuery,PatientResDto>
    {
        private readonly IPatientRepo _repo;
        public PatientByIdQueryHandler(IPatientRepo repo)
        {
             _repo = repo;
        }

        public async Task<PatientResDto> Handle(PatientByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var patient = await _repo.GetPatientById(request.id);
                if (patient == null) return null;

                var res = new PatientResDto()
                {
                    Id = request.id,
                    Age=patient.Age,
                    Phone=patient.Phone,
                    Name=patient.Name,
                    DOB=patient.DOB.ToString("dd-MM-yyyy"),
                };

                return res;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }
    }
}

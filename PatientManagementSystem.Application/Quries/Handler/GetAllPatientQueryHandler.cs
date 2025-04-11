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
    public class GetAllPatientQueryHandler : IRequestHandler<GetAllPatientQuery, PatientPaginationResDto>
    {
        private readonly IPatientRepo _repo;
        public GetAllPatientQueryHandler(IPatientRepo repo)
        {
            _repo = repo;
        }
        public async Task<PatientPaginationResDto> Handle(GetAllPatientQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var allpatients = await _repo.GetAllPatients();

                var list = allpatients.Select(x => new PatientResDto()
                {
                    Name = x.Name,
                    Phone = x.Phone,
                    DOB= x.DOB.ToString("dd-MM-yyyy"),
                    Age=x.Age,
                    Id=x.Id,
                })
                      .Skip((request.pageNumber - 1) * request.pageSize)
                    .Take(request.pageSize)
                    .ToList();

                var res = new PatientPaginationResDto
                {
                    total_pages= (int)Math.Ceiling((double)allpatients.Count / request.pageSize),
                    items =list
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

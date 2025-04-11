using MediatR;
using PatientManagementSystem.Application.Common.DTOs;
using PatientManagementSystem.Application.Interfaces;


namespace PatientManagementSystem.Application.Quries.Handler
{
    public class SearchPatientQueryHandler : IRequestHandler<SearchPatientQuery, PatientPaginationResDto>
    {
        private readonly IPatientRepo _patientRepo;
        public SearchPatientQueryHandler(IPatientRepo patientRepo)
        {
            _patientRepo = patientRepo;
        }

        public async Task<PatientPaginationResDto> Handle(SearchPatientQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var patients = await _patientRepo.SearchPatient(request.Name, request.Age, request.Phone);
                var list = patients.Where(n=>!n.IsDelete).Select(a => new PatientResDto
                {
                    Phone = a.Phone,
                    Age = a.Age,
                    DOB =a.DOB.ToString("dd-MM-yyyy"),
                    Id = a.Id,
                    Name = a.Name,
                })
                      .Skip((request.pageNumber - 1) * request.pageSize)
                    .Take(request.pageSize)
                    .ToList();

                var res = new PatientPaginationResDto
                {
                    total_pages= (int)Math.Ceiling((double)patients.Count / request.pageSize),
                    items = list
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

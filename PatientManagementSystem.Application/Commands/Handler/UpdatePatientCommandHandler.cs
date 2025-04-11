using MediatR;
using PatientManagementSystem.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementSystem.Application.Commands.Handler
{
    public class UpdatePatientCommandHandler : IRequestHandler<UpdatePatientCommand, string>
    {
        private readonly IPatientRepo _repo;
        public UpdatePatientCommandHandler(IPatientRepo repo)
        {
            _repo = repo;
        }

        public async Task<string> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var patient= await _repo.GetPatientById(request.PatientId);
                if (patient == null)
                {
                    throw new Exception("Patient not found");
                }

                int age = CalculateAge(request.DOB);

                patient.Name = request.Name!=null? request.Name : patient.Name;
                patient.Phone = request.Phone!=null ? request.Phone : patient.Phone;
                patient.DOB= (DateTime)(request.DOB !=null ? request.DOB : patient.DOB);
                patient.Age= age>0? age : patient.Age;
                patient.UpdatedAt = DateTime.UtcNow;

                return "Updation completed";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }

        private int CalculateAge(DateTime? dob)
        {
            if (dob == null) return 0;

            var today = DateTime.Today;
            var age = today.Year - dob.Value.Year;
            return age;
        }
    }
}

using MediatR;
using PatientManagementSystem.Application.Interfaces;
using PatientManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementSystem.Application.Commands.Handler
{
    public class AddPatientCommandHandler : IRequestHandler<AddPatientCommand, string>
    {
        private readonly IPatientRepo _repo;
        public AddPatientCommandHandler(IPatientRepo repo)
        {
          _repo = repo;
        }
        public async Task<string> Handle(AddPatientCommand request, CancellationToken cancellationToken)
        {
            try
            {
       
                var patient = new Patient
                {
                    Name = request.Name,
                    Age = request.Age,
                    DOB = request.DOB,
                    Phone = request.Phone,
                };

                await _repo.AddPatient(patient);
                return "Patient registration success";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }
    }
}

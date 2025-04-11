using MediatR;
using PatientManagementSystem.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementSystem.Application.Commands.Handler
{
    public class DeletePatientCommandHandler : IRequestHandler<DeletePatientCommand, string>
    {
        private readonly IPatientRepo _repo;
        public DeletePatientCommandHandler(IPatientRepo repo)
        {
            _repo = repo;
        }

        public async Task<string> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _repo.DeletePatient(request.id);
                return "Patient deleted successfully";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }
    }
}

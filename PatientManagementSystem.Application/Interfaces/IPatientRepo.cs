using PatientManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementSystem.Application.Interfaces
{
    public interface IPatientRepo
    {
        Task<bool> AddPatient(Patient patient);
        Task<List<Patient>> GetAllPatients();
        Task<Patient> GetPatientById(Guid id);
        Task<bool> DeletePatient(Guid id);
        Task<List<Patient>> SearchPatient(string? name, int? age, string? phoneNumber);
    }
}

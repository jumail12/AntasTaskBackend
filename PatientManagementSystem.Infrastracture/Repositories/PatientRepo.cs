using PatientManagementSystem.Application.Interfaces;
using PatientManagementSystem.Domain.Entities;
using System.Reflection.Metadata.Ecma335;


namespace PatientManagementSystem.Infrastracture.Repositories
{
    public class PatientRepo : IPatientRepo
    {
        private readonly List<Patient> _patients = new List<Patient>()
        {
             new Patient {Id = Guid.NewGuid(),Name = "John Doe",Age = 30,DOB = new DateTime(1995, 5, 15),Phone = "9876543210",IsDelete=false},
             new Patient {Id = Guid.NewGuid(),Name = "Alice Smith",Age = 25,DOB = new DateTime(1999, 3, 10),Phone = "9123456789",IsDelete=false},
        };

        public async Task<bool> AddPatient(Patient patient)
        {
            try
            {
                if (patient == null)
                {
                    throw new Exception("Patient not be null here");
                }

                _patients.Add(patient);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<List<Patient>> GetAllPatients()
        {
            try
            {
                return _patients.Where(a=>!a.IsDelete).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<Patient> GetPatientById(Guid id)
        {
            try
            {
                var res=  _patients.FirstOrDefault(a=>a.Id==id && !a.IsDelete);
                return res;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<bool> DeletePatient(Guid id)
        {
            try
            {
                var patient=_patients.FirstOrDefault(a=>a.Id==id);

                if (patient == null)
                {
                    throw new Exception("Patient not found");
                }

                if (patient.IsDelete)
                {
                    return true; 
                }

                patient.IsDelete = true; 
                patient.UpdatedAt = DateTime.UtcNow;
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }

        public async Task<List<Patient>> SearchPatient(string? name, int? age, string? phoneNumber)
        {
            try
            {
                return _patients.Where(p =>
                          (!string.IsNullOrEmpty(name) && p.Name.Contains(name, StringComparison.OrdinalIgnoreCase)) ||
                          (age.HasValue && p.Age == age.Value) ||
                          (!string.IsNullOrEmpty(phoneNumber) && p.Phone.Contains(phoneNumber)))
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }
    }
}

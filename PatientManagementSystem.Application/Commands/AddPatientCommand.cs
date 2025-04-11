using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementSystem.Application.Commands
{
    public record AddPatientCommand : IRequest<string>
    {
        public string Name { get; set; }
        [Required(ErrorMessage = "Age is required")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Date Of Birth is required")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Mobile number is required")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number must be exactly 10 digits")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must contain only digits")]
        public string Phone { get; set; }
    }
}

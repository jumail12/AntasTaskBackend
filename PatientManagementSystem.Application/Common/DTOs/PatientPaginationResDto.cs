using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementSystem.Application.Common.DTOs
{
    public class PatientPaginationResDto
    {
        public int total_pages { get; set; }
        public List<PatientResDto> items { get; set; }
    }
}

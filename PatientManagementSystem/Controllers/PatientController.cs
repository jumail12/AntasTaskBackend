using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientManagementSystem.ApiResponseClass;
using PatientManagementSystem.Application.Commands;
using PatientManagementSystem.Application.Common.DTOs;
using PatientManagementSystem.Application.Quries;
using System.ComponentModel.DataAnnotations;

namespace PatientManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly ISender _sender;
        public PatientController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddPatient([FromBody]AddPatientCommand addPatientCommand)
        {
            try
            {
                var res = await _sender.Send(addPatientCommand);
                return Ok(new ApiResponse<string>(201, "success",res,null));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>(500, "An Internal Error occurred", null, ex.Message));
            }
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll(int pageNumber, int pageSize)
        {
            try
            {
                var res = await _sender.Send(new GetAllPatientQuery(pageNumber,pageSize));
                return Ok(new ApiResponse<PatientPaginationResDto>(201, "success", res, null));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>(500, "An Internal Error occurred", null, ex.Message));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var res = await _sender.Send(new PatientByIdQuery(id));
                if (res == null)
                {
                    return NotFound(new ApiResponse<string>(404, "Patient not found", null, null));
                }
                return Ok(new ApiResponse<PatientResDto>(201, "success", res, null));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>(500, "An Internal Error occurred", null, ex.Message));
            }
        }

        [HttpDelete("delete-patient")]
        public async Task<IActionResult> DeletePatient(Guid id)
        {
            try
            {
                var res= await _sender.Send(new DeletePatientCommand(id));
                return Ok(new ApiResponse<string>(201, "success", res, null));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>(500, "An Internal Error occurred", null, ex.Message));
            }
        }

        [HttpPatch("update-patient")]
        public async Task<IActionResult> UpdatePatient([FromBody] UpdatePatientCommand cmd)
        {
            try
            {
                var res = await _sender.Send(cmd);
                return Ok(new ApiResponse<string>(201, "success", res, null));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>(500, "An Internal Error occurred", null, ex.Message));
            }
        }

        [HttpPost("search")]
        public async Task<IActionResult> SearchPatient([FromBody]SearchPatientQuery searchPatient)
        {
            try
            {
                var res= await _sender.Send(searchPatient);
                return Ok(new ApiResponse<PatientPaginationResDto>(201, "success", res, null));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>(500, "An Internal Error occurred", null, ex.Message));
            }
        }
    }
}

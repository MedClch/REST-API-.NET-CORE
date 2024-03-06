using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs.Employees;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("/api/emps")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpGet("find/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
            {
                ModelState.AddModelError("ID value error", "Id must be greater than 0 !");
                return BadRequest(ModelState);
            }

            try
            {
                var data = await _service.getById(id);
                if (data != null)
                    return Ok(data);
                else
                    return NotFound($"Employee number {id} not found !");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("cin/{cin}")]
        public async Task<IActionResult> GetByCin(string cin)
        {
            try
            {
                var data = await _service.getByCin(cin);
                if (data != null)
                    return Ok(data);
                else
                    return NotFound($"Employee with CIN {cin} not found !");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var data = await _service.getAll();
                if (data != null && data.Count > 0)
                    return Ok(data);
                else
                    return NotFound("No data found !");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] EmployeeDTO employeeDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var success = await _service.create(employeeDTO);
                if (success)
                    return Ok();
                else
                    return BadRequest("Failed to add this new employee !");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EditEmployeeDTO editEmployeeDTO)
        {
            if (id <= 0)
            {
                ModelState.AddModelError("ID value error", "Id must be greater than 0 !");
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var success = await _service.update(id, editEmployeeDTO);
                if (success)
                    return Ok();
                else
                    return BadRequest($"Failed to edit employee number {id} !");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody] PatchEmployeeDTO patchEmployeeDTO)
        {
            if (id <= 0)
            {
                ModelState.AddModelError("ID value error", "Id must be greater than 0 !");
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var success = await _service.patch(id, patchEmployeeDTO);
                if (success)
                    return Ok();
                else
                    return BadRequest($"Failed to edit employee number {id}'s status !");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                ModelState.AddModelError("ID value error", "Id must be greater than 0 !");
                return BadRequest(ModelState);
            }
            try
            {
                var success = await _service.delete(id);
                if (success)
                    return Ok();
                else
                    return BadRequest($"Failed to delete employee number {id} !");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }

}

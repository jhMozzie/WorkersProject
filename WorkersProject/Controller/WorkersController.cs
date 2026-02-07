using Microsoft.AspNetCore.Mvc;
using WorkersProject.Model.Requests.Worker;
using WorkersProject.Model.Responses.Worker;
using WorkersProject.Services.Interfaces;

namespace WorkersProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkersController : ControllerBase
    {
        private readonly IWorkerService _workerService;

        public WorkersController(IWorkerService workerService)
        {
            _workerService = workerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var workers = await _workerService.GetAllAsync();
            return Ok(workers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var worker = await _workerService.GetByIdAsync(id);
            if (worker == null) return NotFound();
            return Ok(worker);
        }

        [HttpPost]
        public async Task<ActionResult<WorkerResponse>> Create([FromBody] CreateWorkerRequest request)
        {
            var result = await _workerService.CreateWorkerAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WorkerResponse>> Update([FromRoute] int id, [FromBody] UpdateWorkerRequest request)
        {
            if(id != request.Id) return BadRequest("ID mismatch");
            var result = await _workerService.UpdateWorkerAsync(id, request);
            if(result == null) return NotFound(new { message = "Worker not found with the provided ID" });
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existing = await _workerService.GetByIdAsync(id);
            if (existing == null) return NotFound(new { message = "Worker not found" });

            await _workerService.DeleteWorkerAsync(id);
            return NoContent();
        }
    }
}


using ArisNotices.Domain.AggregatesModel.ApplicationRegisteration;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ArisNotices.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationRegisterController : ControllerBase
    {
        private readonly IApplicationRegisterRepository repository;

        public ApplicationRegisterController(IApplicationRegisterRepository repository)
        {
            this.repository = repository;
        }
        // GET: api/<ServiceController>
        [HttpGet]
        public async Task<IEnumerable<ApplicationRegister<Service>>> GetAllApps()
        {
            var service = await repository.FindAllAsync();
            return service;

        }

        // GET api/<ServiceController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppById(Guid id)
        {
            var service = await repository.FindByIdAsync(id);
            if (service is not null)
            {
                return Ok(id);
            }
            else
                return NotFound(id);
        }

        // POST api/<ServiceController>
        [HttpPost("create/")]
        public async Task<IActionResult> Create([FromForm] ApplicationRegisterDto app)
        {
            if (app is not null)
            {
                var appAdd = await repository.AddAsync(app);
                if (appAdd is not null)
                    return Ok(appAdd);
                else return BadRequest();
            }
            else
                return BadRequest();
        }

        // PUT api/<ServiceController>/5
        [HttpPut("update/")]
        public async Task<IActionResult> Update([FromForm] ApplicationRegisterDto appDto)
        {
            if (appDto is not null)
            {
                var appUpdate = await repository.UpdateAsync(appDto);
                if (appUpdate is not null)
                    return Ok(appUpdate);
                else
                    return NotFound(appDto.Id);
            }
            else
                return BadRequest();
        }

        // DELETE api/<ServiceController>/5
        [HttpDelete("delete/")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (await repository.DeleteByIdAsync(id))
                return Ok(id);
            else
                return NotFound(id);
        }
    }
}

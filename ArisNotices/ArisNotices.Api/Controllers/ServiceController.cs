
using ArisNotices.Domain.AggregatesModel.NoticeService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ArisNotices.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceRepository repository;

        public ServiceController(IServiceRepository repository)
        {
            this.repository = repository;
        }
        // GET: api/<ServiceController>
        [HttpGet]
        public async Task<IEnumerable<Service>> GetAllService()
        {
            var service = await repository.FindAllAsync();
            return service;

        }

        // GET api/<ServiceController>/5
        [HttpGet("id")]
        public async Task<IActionResult> GetServiceById(Guid id)
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
        public async Task<IActionResult> Create([FromForm] ServiceDto service)
        {
            if (service is not null)
            {
                var serviceAdd = await repository.AddAsync(service);
                if (serviceAdd is not null)
                    return Ok(serviceAdd);
                else return BadRequest();
            }
            else
                return BadRequest();
        }

        // PUT api/<ServiceController>/5
        [HttpPut("update/")]
        public async Task<IActionResult> Update([FromForm] ServiceDto serviceDto)
        {
            if (serviceDto is not null)
            {
                var NoticeUpdate = await repository.UpdateAsync(serviceDto);
                if (NoticeUpdate is not null)
                    return Ok(NoticeUpdate);
                else
                    return NotFound(serviceDto.Id);
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

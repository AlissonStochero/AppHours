using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CollaboratorController : Controller
    {
        private readonly ICollaboratorService service;
        public CollaboratorController(ICollaboratorService _service)
        {
            service = _service;
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Save(Collaborator collaborator)
        {
            try
            {
                var collaboratorCreated = service.Save(collaborator);
                return Ok(collaboratorCreated);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CollaboratorController : Controller
    {
        private readonly ICollaboratorService service;
        private readonly IValidator<Collaborator> _collaboratorValidator;
        public CollaboratorController(ICollaboratorService _service, IValidator<Collaborator>  collaboratorValidator)
        {
            service = _service;
            _collaboratorValidator = collaboratorValidator;
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Save(Collaborator collaborator)
        {
            try
            {
                var validationResult = _collaboratorValidator.Validate(collaborator);
                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors);
                }
                var collaboratorCreated = await service.Save(collaborator);
                return Ok(collaboratorCreated);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var collaborators = await service.GetAll();
                return Ok(collaborators);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

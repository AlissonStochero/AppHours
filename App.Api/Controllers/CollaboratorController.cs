﻿using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using App.Domain.RequestValidators;
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
        private readonly IValidator<Guid> _guidValidator;
        public CollaboratorController(ICollaboratorService _service, IValidator<Collaborator>  collaboratorValidator, IValidator<Guid> guidValidator)
        {
            service = _service;
            _collaboratorValidator = collaboratorValidator;
            _guidValidator = guidValidator;
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
        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(Guid Id)
        {
            try
            {
                var validationResult = _guidValidator.Validate(Id);
                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors);
                }
                var collaborator = await service.Get(Id);
                return Ok(collaborator);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("/guid")]
        public async Task<IActionResult> GetGuid()
        {
            try
            {
                return Ok(Guid.Empty);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

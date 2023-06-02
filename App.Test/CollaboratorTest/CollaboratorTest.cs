using App.Application.Services;
using App.Domain.Entities;
using App.Domain.Interfaces.Repositories;
using App.Domain.RequestValidators;
using App.Domain.ValueObjects;
using FluentValidation;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace App.Test.CollaboratorTest
{
    public class CollaboratorTest
    {
        [Fact]
        public void Save_ValidCollaborator_ReturnsCollaboratorSaved()
        {
            var collaboratorValidator = new CollaboratorValidator();
            // Arrange
            var collaborator = new Collaborator
            {
                Id = Guid.NewGuid(),
                Name = new Name("John", "Doe"),
                Email = new Email("john.doe@example.com"),
                KeyPassword = new Password("Abc123!"),
                Company = new Company()
            };

            var validation = collaboratorValidator.Validate(collaborator);

            Assert.True(validation.IsValid);
        }
    }
}

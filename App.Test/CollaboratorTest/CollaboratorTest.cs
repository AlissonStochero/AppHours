using App.Domain.Entities;
using App.Domain.RequestValidators;
using App.Domain.ValueObjects;
using App.Test.CollaboratorTest.UtilitiesCollaboratorTest;
using Bogus;
using FluentAssertions;

namespace App.Test.CollaboratorTest
{
    public class CollaboratorTest
    {
        #region Tests Use Cases
        //[Fact]
        //public void Save_Valid_Collaborator_UseCase()
        //{
        //    var collaboratorValidator = new CollaboratorValidator();

        //    var collaborator = RequestCollaborator.MakeCollaboratorRequest();

        //    var validation = collaboratorValidator.Validate(collaborator);

        //    validation.IsValid.Should().BeTrue();
        //}
        #endregion

        #region Tests Request
        [Fact]
        public void Save_Valid_Collaborator_Request()
        {
            var collaboratorValidator = new CollaboratorValidator();

            var collaborator = RequestCollaborator.MakeCollaboratorRequest();

            var validation = collaboratorValidator.Validate(collaborator);

            validation.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Save_Invalid_Empty_Name_Collaborator_Request()
        {
            var collaboratorValidator = new CollaboratorValidator();

            var collaborator = RequestCollaborator.MakeCollaboratorRequest();
            collaborator.Name.FullName = string.Empty;

            var validation = collaboratorValidator.Validate(collaborator);

            validation.IsValid.Should().BeFalse();
            validation.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals("Name is required."));
        }
        [Fact]
        public void Save_Invalid_Large_Name_Collaborator_Request()
        {
            var collaboratorValidator = new CollaboratorValidator();

            var collaborator = RequestCollaborator.MakeCollaboratorRequest();
            collaborator.Name.FullName = new Faker().Random.String2(150);

            var validation = collaboratorValidator.Validate(collaborator);

            validation.IsValid.Should().BeFalse();
            validation.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals("Name is greater than 100 characters."));
        }
        [Fact]
        public void Save_Invalid_Empty_Email_Collaborator_Request()
        {
            var collaboratorValidator = new CollaboratorValidator();

            var collaborator = RequestCollaborator.MakeCollaboratorRequest();
            collaborator.Email.Address = string.Empty;

            var validation = collaboratorValidator.Validate(collaborator);

            validation.IsValid.Should().BeFalse();
            validation.Errors.Should().Contain(error => error.ErrorMessage.Equals("Email address is required."));
        }
        [Fact]
        public void Save_Invalid_Large_Email_Collaborator_Request()
        {
            var collaboratorValidator = new CollaboratorValidator();

            var collaborator = RequestCollaborator.MakeCollaboratorRequest();
            collaborator.Email.Address = new Faker().Random.String2(150) + collaborator.Email.Address;

            var validation = collaboratorValidator.Validate(collaborator);

            validation.IsValid.Should().BeFalse();
            validation.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals("Email address is greater than 100 characters."));
        }
        [Fact]
        public void Save_Invalid_Email_Collaborator_Request()
        {
            var collaboratorValidator = new CollaboratorValidator();

            var collaborator = RequestCollaborator.MakeCollaboratorRequest();
            collaborator.Email.Address = collaborator.Email.Address.Replace("@", "");

            var validation = collaboratorValidator.Validate(collaborator);

            validation.IsValid.Should().BeFalse();
            validation.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals("Invalid email address."));
        }
        [Fact]
        public void Save_Invalid_Empty_Password_Collaborator_Request()
        {
            var collaboratorValidator = new CollaboratorValidator();

            var collaborator = RequestCollaborator.MakeCollaboratorRequest();
            collaborator.KeyPassword.Key = string.Empty;

            var validation = collaboratorValidator.Validate(collaborator);

            validation.IsValid.Should().BeFalse();
            validation.Errors.Should().Contain(error => error.ErrorMessage.Equals("Key is required."));
            validation.Errors.Should().Contain(error => error.ErrorMessage.Equals("password is less than 6 characters."));
            validation.Errors.Should().Contain(error => error.ErrorMessage.Equals("Password is not valid."));
        }
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void Save_Invalid_Small_Password_Collaborator_Request(int lenthPassword)
        {
            var collaboratorValidator = new CollaboratorValidator();

            var collaborator = RequestCollaborator.MakeCollaboratorRequest();
            collaborator.KeyPassword.Key = RequestCollaborator.GenerateRandomPassword(lenthPassword);

            var validation = collaboratorValidator.Validate(collaborator);

            validation.IsValid.Should().BeFalse();
            validation.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals("password is less than 6 characters."));
        }
        [Fact]
        public void Save_Invalid_TooLarge_Password_Collaborator_Request()
        {
            var collaboratorValidator = new CollaboratorValidator();

            var collaborator = RequestCollaborator.MakeCollaboratorRequest();
            collaborator.KeyPassword.Key = RequestCollaborator.GenerateRandomPassword(21);

            var validation = collaboratorValidator.Validate(collaborator);

            validation.IsValid.Should().BeFalse();
            validation.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals("Key is greater than 20 characters."));
        }
        [Fact]
        public void Save_Invalid_Password_Collaborator_Request()
        {
            var collaboratorValidator = new CollaboratorValidator();

            var collaborator = RequestCollaborator.MakeCollaboratorRequest();
            collaborator.KeyPassword.Key = "Test123";

            var validation = collaboratorValidator.Validate(collaborator);

            validation.IsValid.Should().BeFalse();
            validation.Errors.Should().ContainSingle().And.Contain(error => error.ErrorMessage.Equals("Password is not valid."));
        }
        #endregion
    }
}

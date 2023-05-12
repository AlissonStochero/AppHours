using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using App.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Test.Tests
{
    public class CollaboratorTest
    {
        ICollaboratorService _service;
        public CollaboratorTest(ICollaboratorService service)
        {
            _service= service;
        }
        //[Fact]
        //public void SaveTest()
        //{
        //    var collaborator = new Collaborator(Guid.NewGuid(), 
        //        new Name("Alisson", "Stochero"),
        //        new Email("alissonstochero"),
        //        new Password("Teste@123"));

        //    var returnSave = _service.Save(collaborator);

        //    Assert.True(returnSave.IsCompleted);
        //}
    }
}

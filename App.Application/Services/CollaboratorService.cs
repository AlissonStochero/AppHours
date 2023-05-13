using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using App.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Services
{
    public class CollaboratorService : ICollaboratorService
    {
        private IRepositoryBase<Collaborator> _repository { get; set; }
        public CollaboratorService(IRepositoryBase<Collaborator> repository)
        {
            _repository = repository;
        }

        public async Task<Collaborator> Save(Collaborator collaborator)
        {
            if (!collaborator.KeyPassword.Validate())
            {
                throw new ArgumentException("Password is not valid.");
            }

            var collaboratorSaved = await _repository.SaveAsync(collaborator);
            _repository.SaveChanges();

            return collaboratorSaved;
        }
        public Task<List<Collaborator>> GetAll()
        {
            return _repository.Query(x => x.Id != null).ToListAsync();
        }
    }
}
